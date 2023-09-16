using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHealthBar : MonoBehaviour
{
    public float towerHP;
    public float maxHP = 100;
    public Slider healthBar;

    bool continuousDmg = false;

    void Start()
    {
        healthBar.minValue = 0;
        healthBar.maxValue = maxHP;
        towerHP = maxHP;
    }

    void Update()
    {
        healthBar.value = towerHP;

        Boom();
    }

    void Boom()
    {
        if(towerHP <= 0 )
        {
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "EnemyCube")
        {
            Debug.Log("Opening!");
            if (!continuousDmg)
            {
                Debug.Log("Touched!");
                StartCoroutine(damageDelay());
            }
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag == "EnemyCube")
        {
            if (continuousDmg)
            {
                StopCoroutine(damageDelay());
            }
        }
    }

    IEnumerator damageDelay()
    {
        continuousDmg = true;
        while (towerHP > 0)
        {
            towerHP -= 10;
            yield return new WaitForSeconds(3f);
        }

        continuousDmg = false;

        Destroy(gameObject);
    }
    
}
