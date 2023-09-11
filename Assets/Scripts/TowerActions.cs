using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerActions : MonoBehaviour
{

    public float towerRange = 15f;

    [Header("Single Target")]
    public Transform selectedTarget;

    void Update()
    {
        detectedEnemy();

        if (selectedTarget == null)
        {
            return;
        }
    }

    void detectedEnemy()
    {
        GameObject[] enemiesInRange = GameObject.FindGameObjectsWithTag("EnemyCube");
        float closetEnemy = Mathf.Infinity;
        GameObject closeTarget = null;
        foreach (GameObject enemy in enemiesInRange)
        {
            float enemyDist = Vector3.Distance(transform.position, enemy.transform.position);
            if (enemyDist < closetEnemy)
            {
                closetEnemy = enemyDist;
                closeTarget = enemy;
            }
        }

        if (closeTarget != null && closetEnemy <= towerRange)
        {
            selectedTarget = closeTarget.transform;
        }
        else
        {
            selectedTarget = null;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, towerRange);
    }


}
