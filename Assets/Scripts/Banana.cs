using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
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
        transform.Rotate(0, 0, 40 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player.currentHealth += 24f;
            FindObjectOfType<AudioManager>().PlaySound("PickUpCoin");
            PlayerManager.numberOfBananas += 1;

            Destroy(gameObject);

        }
    }
}
