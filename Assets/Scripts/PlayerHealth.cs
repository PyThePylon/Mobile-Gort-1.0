using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float playerHP;
    public float maxHP = 100;
    public Slider healthBar;

    public GameObject explosionPrefab;

    bool continuousDmg = false;

    //set the player min and max hp values along with the player HPbar
    void Start()
    {
        healthBar.minValue = 0;
        healthBar.maxValue = maxHP;
        playerHP = maxHP;
    }
    //load set the health bar to the player health and send the player to
    //the game over scene when their hp reaches 0
    void Update()
    {
        healthBar.value = playerHP;

        if(playerHP == 0)
        {
            SceneManager.LoadScene(2);
        }
    }
    //load game again
    public void restart()
    {
        SceneManager.LoadScene(1);
    }
    //load main menu
    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //cause continuous dmg to the player every 1 second
    IEnumerator continueDmg()
    {


        while(continuousDmg)
        {
            yield return new WaitForSeconds(1.5f);
            playerHP -= 10f;
        } 


    }
    
    //Causes continous dmg by calling the continueDmg method when the enemy
    //enters the trigger area. Also stops the enemy movement as well
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EnemyCube")
        {
            if(other.GetComponent<EnemyMovementScript>() != null)
            {
                other.GetComponent<EnemyMovementScript>().enteredPlayerArea = true;

                if (!continuousDmg)
                {
                    continuousDmg = true;
                    StartCoroutine(continueDmg());
                }
            }
        }


        if(other.gameObject.tag == "snowAOE")
        {
            playerHP -= 10f;
        }

        if(other.gameObject.tag == "meteorAOE")
        {
            GameObject exPF = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            playerHP -= .001f;
            Destroy(exPF, 1);
        }
    }

    //Stops the continuous dmg once the enemy leaves the player area
    //or if the player moves away from the enemy, and continues the enemy movement
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "EnemyCube")
        {
            Debug.Log("Stop");
            other.GetComponent<EnemyMovementScript>().enteredPlayerArea = false;
            continuousDmg = false;
            StopCoroutine(continueDmg());
        }
    }
    

}
