using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    //  public static bool isGameStarted;
    public float maxHealth = 100f;
    public static float currentHealth;
    //public GameObject apple;
    GamePreferencesManager gamePreferencesManager;

    // public GameObject gameOverPanel;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerManager.isGameStarted == false)
        {
            currentHealth = 25f;
            healthBar.SetHealth(25f);

        }

        if (PlayerManager.isGameStarted == true)
        {
            currentHealth = 25f;
            healthBar.SetMaxHealth(25f);

        }
        //else
        //{
        //    currentHealth = maxHealth;
        //}

        // StartCoroutine(TakeDamageForSeconds(20, 5));
        gamePreferencesManager.LoadPrefs();

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.isGameStarted == true)
            TakeDamage(3f);

        //nefunguje take damage u nezdraveho ovoce hrozny, zmrzka a burger

        if (!PlayerManager.isGameStarted || PlayerManager.gameOver)
            return;
        Debug.Log(currentHealth);
        //OnCollisionEnter(apple);
        Die();
        gamePreferencesManager.SavePrefs();
    }

    public void TakeDamage(float damage) //za sekundu take damage
    {
        currentHealth -= damage * Time.deltaTime;
        healthBar.SetHealth(currentHealth);

        Debug.Log($"Damage: {damage} HP: {currentHealth}");
    }

    public IEnumerator TakeDamageForSeconds(float damage, float duration)
    {
        var remaningDuration = duration;
        var dpf = (damage / duration) * Time.deltaTime; //x damage za sekundu

        while (remaningDuration > 0)
        {
            currentHealth -= dpf;
            healthBar.SetHealth(currentHealth);
            remaningDuration -= Time.deltaTime;

        }
        yield return new WaitForEndOfFrame();
    }

    private void Die()
    {
        if (currentHealth < 0f || currentHealth > 100f)  //hypo a hyperglykemie
        {
          //  PlayerManager.SaveCoins();
            PlayerManager.gameOver = true;
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
        }
    }

}