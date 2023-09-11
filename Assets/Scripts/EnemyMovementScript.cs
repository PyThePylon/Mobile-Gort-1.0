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
    void Awake()
    {
        eneMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nearestTower();

        if (closestTower == null)
        {
            eneMesh.SetDestination(destination.transform.position);
            return;
        }
    }

    void nearestTower()
    {
        Debug.Log("RUN!");

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

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.name == "BaseColTest")
        {
            Destroy(gameObject);
        }
    }
}
