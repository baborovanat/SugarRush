using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapes : MonoBehaviour
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
        transform.Rotate(0, 40 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player.currentHealth += 45.05f; //85f;
            FindObjectOfType<AudioManager>().PlaySound("PickUpCoin");
            PlayerManager.numberOfBananas += 1;
            // player.TakeDamage(100f);//nove
            StartCoroutine(player.TakeDamageForSeconds(7, 5));
            Destroy(gameObject);

        }
    }
}
