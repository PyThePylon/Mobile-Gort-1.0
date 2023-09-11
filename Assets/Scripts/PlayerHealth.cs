using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float playerHP;
    public float maxHP = 100;
    public Slider healthBar;

    //bool continuousDmg = false;

    /*
    //continuousDmg for when the player gets stuck between enemies and a wall or just enemies
    //bool continuousDmg = false;
    */

    void Start()
    {
        healthBar.minValue = 0;
        healthBar.maxValue = maxHP;
        playerHP = maxHP;
    }

    void Update()
    {
        healthBar.value = playerHP;
    }

    /*
    IEnumerator continueDmg()
    {
        yield return new WaitForSeconds(3f);

        continuousDmg = true;

    }
    */

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EnemyCube")
        {
            playerHP -= 10f;

        }
    }

    /* To stop the continuousDmg
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "EnemyCube")
        {

        }
    }
    */

}
