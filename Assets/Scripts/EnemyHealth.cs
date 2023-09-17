using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHP;
    public float maxHP = 100;
    public Slider healthBar;

    void Start()
    {
        healthBar.minValue = 0;
        healthBar.maxValue = maxHP;
        enemyHP = maxHP;
    }

    void Update()
    {
        healthBar.value = enemyHP;

        Poof();
    }

    void Poof()
    {
        if(enemyHP <= 0 )
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pellet"))
        {
            enemyHP -= 10;
            Destroy(other.gameObject);
        }else if(other.gameObject.CompareTag("Spikes"))
        {
            enemyHP -= 15f;
        }else if(other.gameObject.CompareTag("Giant_Ball"))
        {
            enemyHP -= 5f;
            Destroy(other.gameObject);
        }
    }
}
