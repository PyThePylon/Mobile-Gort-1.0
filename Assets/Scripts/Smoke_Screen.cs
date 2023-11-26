using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Smoke_Screen : MonoBehaviour
{
    public GameObject smokeScreenPrefab;
    public AudioClip smokeBombSound;
    public float halfHealthTrigger = 0.5f;

    private bool droppedHalfHealth = false;
    private EnemyHealth enemyHealth;
    private NavMeshAgent navMeshAgent;
    private AudioSource audioSource;

    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();

        navMeshAgent = GetComponent<NavMeshAgent>();
        if (navMeshAgent == null)
        {
            return;
        }

        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        if (enemyHealth.enemyHP < enemyHealth.maxHP * halfHealthTrigger && !droppedHalfHealth)
        {
            SpawnSmokeScreen();
            IncreaseNavMeshAgentSpeed();
            PlaySmokeBombSound();
            droppedHalfHealth = true;
        }
    }

    void SpawnSmokeScreen()
    {
        Vector3 spawnPosition = transform.position - Vector3.up * 0.1f;

        GameObject smokeScreen = Instantiate(smokeScreenPrefab, spawnPosition, Quaternion.identity);

        if (smokeBombSound != null)
        {
            float soundDuration = smokeBombSound.length;

            Destroy(smokeScreen, soundDuration);
        }
    }

    void IncreaseNavMeshAgentSpeed()
    {
        if (navMeshAgent != null)
        {
            navMeshAgent.speed = 10f;
        }
    }

    void PlaySmokeBombSound()
    {
        if (audioSource != null && smokeBombSound != null)
        {
            // Play the smoke bomb sound
            audioSource.PlayOneShot(smokeBombSound);
        }
    }
}
