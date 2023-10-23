using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Wave_Test : MonoBehaviour
{
    //Use wave number increment to spawn 2+ enemies
    [Header("Wave Counter")]
    public TextMeshProUGUI waveTxt;
    float waveCounter = 0;

    [Header("Wave Timer")]
    float waveTimer;
    float maxTimer = 10;

    public Slider waveTSlider;
    public bool waveActive = true;

    [Header("EnemySpawnScript")]
    public EnemySpawnScript eSS;

    void Start()
    {
        waveCounter = 1;
        waveTxt.text = "Wave #: " + waveCounter;

        waveTimer = maxTimer;
        waveTSlider.minValue = 0;
        waveTSlider.maxValue = maxTimer;
    }

    void Update()
    {
        if (waveActive)
        {
            if (waveTimer > 0)
            {
                waveTimer -= Time.deltaTime;
                waveTSlider.value = waveTimer;

                if (!eSS.spawning)
                {
                    eSS.spawningEnemies();
                }
            }
            else
            {
                waveCounter += 1;
                waveActive = false;
                eSS.endSpawning();
                StartCoroutine(resetTimer());
            }
        }

    }

    IEnumerator resetTimer()
    {
        yield return new WaitForSeconds(2f);
        waveTimer = maxTimer;
        waveActive = true;
        WaveCounterUpdate();
    }

    void WaveCounterUpdate()
    {
        waveTxt.text = "Wave #: " + waveCounter;
    }
}
