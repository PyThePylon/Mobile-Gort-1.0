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

    void Awake()
    {
        eneMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        eneMesh.SetDestination(destination.transform.position);

    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.name == "BaseColTest")
        {
            Destroy(gameObject);
        }
    }
}
