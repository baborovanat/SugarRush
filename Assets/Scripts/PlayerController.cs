using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
  
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;
    public PlayerManager playerManager;
    public ScorePerSecond scorePerSecond;
    public ScorePerSecondLevel1 scorePerSecondLevel1;
    public ScorePerSecondLevel2 scorePerSecondLevel2;

    private int desiredLane = 1;
    public float laneDistance = 4;

    public float jumpForce;
    public float Gravity = -20;
    bool toggle = false;
    int stopky;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Time.timeScale = 1.2f;

        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        scorePerSecond = GameObject.FindGameObjectWithTag("ScorePerSecond").GetComponent<ScorePerSecond>();

    }

    private void FixedUpdate()
    {
        if (!PlayerManager.isGameStarted || PlayerManager.gameOver)
            return;

        //Increase Speed
        if (toggle)
        {
            toggle = false;
            if (forwardSpeed < maxSpeed)
                forwardSpeed += 0.1f * Time.fixedDeltaTime;
        }
        else
        {
            toggle = true;
            if (Time.timeScale < 2f)
                Time.timeScale += 0.005f * Time.fixedDeltaTime;
        }

       

    }
    // Update is called once per framel1
    void Update()
    {





        if (!PlayerManager.isGameStarted || PlayerManager.gameOver)
            return;

        forwardSpeed += 0.1f * Time.deltaTime;
        animator.SetBool("isGameStarted", true);
        direction.z = forwardSpeed;



        if (controller.isGrounded)
        {
          
            if (SwipeManager.swipeUp)
            {
                Jump();
            }
        }
        else
        {
            direction.y += Gravity * Time.deltaTime;
        }
        if (SwipeManager.swipeDown)
        {
            StartCoroutine(Slide());
            

        }
      

        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        if (transform.position != targetPosition)
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 30 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.magnitude)
                controller.Move(moveDir);
            else
                controller.Move(diff);
        }
      


        controller.Move(direction * Time.fixedDeltaTime);

      

    }


    private void Jump()
    {
        direction.y = jumpForce;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            //PlayerManager.SaveCoins();
            PlayerManager.gameOver = true;
            playerManager.SaveCoins();
            if(ScorePerSecondLevel2.scoreAmount > ScorePerSecond.scoreAmount)
            {
                scorePerSecondLevel2.SaveScore();
                scorePerSecondLevel2.NewScore2();
            }
            else if (ScorePerSecondLevel1.scoreAmount > ScorePerSecond.scoreAmount)
            {
                scorePerSecondLevel1.SaveScore();
                scorePerSecondLevel1.NewScore1();
            }
            else
            {
                scorePerSecond.SaveScore();
                scorePerSecond.NewScore();
            }

            
            
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
        }
    }

    

    private IEnumerator Slide()
    {
        animator.SetBool("isSliding", true);
        yield return new WaitForSeconds(1.3f);
        animator.SetBool("isSliding", false);
    }

    
}
