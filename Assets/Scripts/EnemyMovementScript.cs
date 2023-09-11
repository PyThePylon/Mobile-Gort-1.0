using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementScript : MonoBehaviour
{
    [Header("Types of Gorts")]
    public GameObject gortTypes;

    [Header("PointB Position")]
    public GameObject destination;

    [Header("NavMeshAgent")]
    private NavMeshAgent eneMesh;

    public float enemyDetectRange = 15f;
    public Transform closestTower;


    private Transform player;
    private float chaseRange;
    public float chasePlayer = 15f;
    bool grabPlayer = false;

    void Awake()
    {
        eneMesh = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        nearestTower();

        playerDist();

        if (closestTower == null && !grabPlayer)
        {
            eneMesh.SetDestination(destination.transform.position);
            return;
        }
    }

    void nearestTower()
    {
        GameObject[] towerInRange = GameObject.FindGameObjectsWithTag("Tower");
        float closetEnemy = Mathf.Infinity;
        GameObject closeTarget = null;
        foreach (GameObject tower in towerInRange)
        {
            float enemyDist = Vector3.Distance(transform.position, tower.transform.position);
            if (enemyDist < closetEnemy)
            {
                closetEnemy = enemyDist;
                closeTarget = tower;
            }
        }

        if (closeTarget != null && closetEnemy <= enemyDetectRange)
        {
            closestTower = closeTarget.transform;
            eneMesh.SetDestination(closestTower.transform.position);
        }
        else
        {
            closestTower = null;
        }
    }

    void playerDist()
    {
        chaseRange = Vector3.Distance(player.position, transform.position);

        if(chaseRange <= chasePlayer)
        {
            grabPlayer = true;
            eneMesh.SetDestination(player.transform.position);
        }
        else
        {
            grabPlayer = false;
        }

    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.name == "BaseColTest")
        {
            Destroy(gameObject);
        }
    }
}
