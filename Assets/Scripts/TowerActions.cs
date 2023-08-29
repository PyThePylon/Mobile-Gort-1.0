using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerActions : MonoBehaviour
{
    [Header("Tower attack Distance")]
    public float towerAttackDist = 20f;

    [Header("Enemy Layer")]
    public LayerMask enemyOverLap;

    [Header("Single Target")]
    private GameObject selectedTarget;

    void Update()
    {

        //Need to have a physics.raycast for 360 rotation!

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, towerAttackDist);
    }
}
