using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_Spell : MonoBehaviour
{
    public GameObject iceCirclePrefab;  // Reference to the ice circle prefab
    public GameObject iceSpellPrefab;   // Reference to the ice spell prefab
    public int abilityDamage = 10;       // Amount of damage to deal
    public float castingRange = 30f;     // Range at which the abilities can be cast

    private GameObject player;           // Reference to the player GameObject

    private static bool canCastIceSpell = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
        if (canCastIceSpell)
        {
            StartCoroutine(WaitBeforeCasting());
        }
        else
        {
            return;
        }
    }

    IEnumerator WaitBeforeCasting()
    {
        yield return new WaitForSeconds(1f);

        // Start the casting loop after waiting
        if (canCastIceSpell)
        {
            StartCoroutine(CastAbilities());
        }
    }

    IEnumerator CastAbilities()
    {
        while (true)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            Debug.Log("Distance to Player: " + distanceToPlayer);

            if (distanceToPlayer <= castingRange)
            {
                SummonIceCircle();
                SummonIceSpell();

                // Your existing code for casting abilities

                // Set the flag to false to prevent further casting
                canCastIceSpell = false;

                // Wait for 5 seconds
                yield return new WaitForSeconds(30f);

                // Set the flag to true to allow casting after waiting
                canCastIceSpell = true;
            }
        }
    }

    // Function to summon an ice circle
    void SummonIceCircle()
    {
        GameObject iceCircle = Instantiate(iceCirclePrefab, transform.position, Quaternion.identity);

        Destroy(iceCircle, 4f);
    }

    // Function to deal damage to objects with a specific tag
    void DamageObjectsWithTag(string tag)
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject target in targets)
        {
            // Assuming the objects with the specified tag have a script that handles taking damage
            // You might need to adjust this part based on how your player and tower objects are set up

            PlayerHealth healthScript = target.GetComponent<PlayerHealth>();
            TowerHealthBar tHealthScript = target.GetComponent<TowerHealthBar>();

            if (healthScript != null && tag == "player")
            {
                // Ensure that playerHP is not clamped or restricted from going below 0
                healthScript.playerHP -= abilityDamage;
            }

            if (tHealthScript != null && tag == "tower")
            {
                // Ensure that towerHP is not clamped or restricted from going below 0
                tHealthScript.towerHP -= (int)(abilityDamage * 1.5);
            }
        }
    }

    void SummonIceSpell()
    {
        // Get the player GameObject
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // Get the positions of the player and tower
        Vector3 playerPosition = player.transform.position;
        Vector3 targetPosition;

        // Calculate distances to the player and tower
        float playerDistance = Vector3.Distance(transform.position, playerPosition);

        float towerDistance;

        // Check if the tower exists
        GameObject tower = GameObject.FindGameObjectWithTag("Tower");

        if (tower != null)
        {
            towerDistance = Vector3.Distance(transform.position, tower.transform.position);
        }
        else
        {
            towerDistance = float.MaxValue;
        }

        GameObject target = null;

        // Use an if statement to determine the target based on proximity
        if (playerDistance < towerDistance)
        {
            target = player;
            targetPosition = playerPosition;
        }
        else
        {
            target = tower;
            targetPosition = tower.transform.position;
        }

        if (target != null)
        {
            // Spawn the ice spell prefab at the target's position
            GameObject iceSpell = Instantiate(iceSpellPrefab, targetPosition, Quaternion.identity);

            // Deal damage to objects with the "player" or "tower" tag
            DamageObjectsWithTag(target.tag);

            // Destroy the ice spell after 5 seconds (adjust the time as needed)
            Destroy(iceSpell, 5f);
        }
        DamageObjectsWithTag(target.tag);
    }
}
