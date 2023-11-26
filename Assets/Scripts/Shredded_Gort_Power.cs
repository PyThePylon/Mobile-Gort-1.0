using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredded_Gort_Power : MonoBehaviour
{
    public AudioClip powerAudio;
    public GameObject meteorAOEPrefab;
    public float meteorAOESpawnRadius = 50f;
    public float powerDuration = 5f;  // Duration of the power in seconds
    public float powerInterval = 300f;  // 300 seconds = 5 minutes

    private AudioSource audioSource;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private float nextPowerTime;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        nextPowerTime = Time.time + powerInterval;
    }

    void Update()
    {
        if (Time.time >= nextPowerTime)
        {
            StartCoroutine(ActivatePower());
            nextPowerTime = Time.time + powerInterval;
        }
    }

    IEnumerator ActivatePower()
    {
        // Play the power audio
        if (audioSource != null && powerAudio != null)
        {
            audioSource.PlayOneShot(powerAudio);
        }

        // Stop the movement
        if (navMeshAgent != null)
        {
            navMeshAgent.isStopped = true;
        }

        // Spawn meteor AOE's
        SpawnMeteorAOEs();

        // Wait for the power duration
        yield return new WaitForSeconds(powerDuration);

        // Resume movement
        if (navMeshAgent != null)
        {
            navMeshAgent.isStopped = false;
        }
    }

    void SpawnMeteorAOEs()
    {
        // Spawn meteor AOE's around the enemy
        for (int i = 0; i < 5; i++)  // Adjust the number of meteors as needed
        {
            // Use Random.onUnitSphere to get a random direction in 3D space
            Vector3 randomDirection = Random.onUnitSphere;

            // Scale the random direction by the spawn radius
            Vector3 randomOffset = randomDirection * meteorAOESpawnRadius;

            // Add an additional distance factor to move the meteors farther away
            float distanceFactor = 2.5f; // Adjust this value as needed
            randomOffset *= distanceFactor;

            // Use the enemy's position as the center and add the random offset
            Vector3 spawnPosition = transform.position + randomOffset;

            // Ensure the Y-coordinate is within a specific range (e.g., 0.5 to 1.5)
            spawnPosition.y = Mathf.Clamp(spawnPosition.y, 0.5f, 1.5f);

            Instantiate(meteorAOEPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
