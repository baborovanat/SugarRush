using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Apple : MonoBehaviour
{
    public HealthBar healthBar;
    private Player player;

    void Start()
    {
        var playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 40 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player.currentHealth += 5.4f; 
            FindObjectOfType<AudioManager>().PlaySound("PickUpCoin");
            PlayerManager.numberOfA += 1;
            Debug.Log("Apples: " + PlayerManager.numberOfA);
            Destroy(gameObject);

        }
    }
}
