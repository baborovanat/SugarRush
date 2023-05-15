using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange : MonoBehaviour

{

    public HealthBar healthBar;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        var playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 40 * Time.deltaTime);
    }

     private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player.currentHealth += 4.73f;// 11f;
            FindObjectOfType<AudioManager>().PlaySound("PickUpCoin");
            PlayerManager.numberOfBananas += 1;

            Destroy(gameObject);

        }
    }
}
