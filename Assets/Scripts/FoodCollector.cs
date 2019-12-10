using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  //needed for changing scenes

/// <summary>
/// controls ...
/// </summary>
public class FoodCollector : MonoBehaviour
{
    public static int playerHealth = 100; //initial player health value
    public Text healthText;

    SuperFruitScript superFruit;

    public bool superOn = false;
    float superTime = 20.0f;
    float superReset = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        //displays the initial value of the player's health
        healthText.text = "Foo Health: " + playerHealth.ToString();

        superFruit = GetComponent<SuperFruitScript>();
        superFruit.enabled = false;
    }

    private void Update()
    {
        if(playerHealth <= 0)
        {
            CompleteGame();
        }

        //superClock.text = "SUPER MODE ACTIVE!"; //+ Mathf.Round(superTime).ToString() + "s";
    }

    /// <summary>
    /// called when ...
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        //increases the player's health by 5 (default)
        //occurs when a player comes into contact with a fruit
        if (other.gameObject.CompareTag("Fruit"))
        {
            playerHealth += 5;  //change value based on the fruit
            healthText.text = "Foo Health: " + playerHealth.ToString(); //display health value
        }

        //decreases player's health whenever he comes into contact with junk food
        if (other.gameObject.CompareTag("Junk_Food") && superOn == false)
        {
            playerHealth -= 5;
            healthText.text = "Foo Health: " + playerHealth.ToString();
        }

        if (other.gameObject.CompareTag("EnemyBullet") && superOn == false)
        {
            playerHealth -= 5; //change val based on food type
            healthText.text = "Foo Health: " + playerHealth.ToString(); //display new health val.
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            CompleteGame();
        }

        if (other.gameObject.CompareTag("Super_Fruit"))
        {
            superTime = superReset;
            if(superTime > 0)
            {
                superOn = true;
                superFruit.enabled = true;
                superTime -= Time.deltaTime;
                //superClock.text = "SUPER MODE ACTIVE! "; //+ Mathf.Round(superTime).ToString() + "s";
            }
            else
            {
                superFruit.enabled = false;
                //superTime = superReset;
                superOn = false;
            }

        }
    }



    /// <summary>
    /// called when ...
    /// </summary>
    void CompleteGame()
    {
        SceneManager.LoadScene("Game Over");
    }
}
