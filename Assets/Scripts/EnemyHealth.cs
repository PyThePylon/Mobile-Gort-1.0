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
    }
}
