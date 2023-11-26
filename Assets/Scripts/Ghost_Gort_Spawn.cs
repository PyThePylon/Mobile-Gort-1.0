using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_Gort_Spawn : MonoBehaviour
{
    public GameObject smallGhostPrefab;
    public float spawnDistance = 2f;

    private bool hasSpawned = false;

    void Start()
    {
        if (!hasSpawned)
        {
            SpawnSmallGhosts();
        }
    }

    void SpawnSmallGhosts()
    {
        // Calculate the spawn position in front of the ghost
        Vector3 spawnPosition = transform.position + transform.forward * spawnDistance;

        // Spawn the first small ghost
        GameObject smallGhost1 = Instantiate(smallGhostPrefab, spawnPosition, Quaternion.identity);
        smallGhost1.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); // Adjust the scale as needed

        // Spawn the second small ghost
        GameObject smallGhost2 = Instantiate(smallGhostPrefab, spawnPosition, Quaternion.identity);
        smallGhost2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); // Adjust the scale as needed

        // Disable the script on the spawned small ghosts
        smallGhost1.GetComponent<Ghost_Gort_Spawn>().enabled = false;
        smallGhost2.GetComponent<Ghost_Gort_Spawn>().enabled = false;

        // You can further customize the small ghosts here
        // For example, you might want to add some behavior or effects to them

        hasSpawned = true;
    }
}
