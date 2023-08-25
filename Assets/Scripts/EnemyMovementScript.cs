using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    [Header("Types of Gorts")]
    public GameObject gortTypes;

    [Header("PointB Position")]
    public GameObject destination;

    // Update is called once per frame
    void Update()
    {
        Vector3 setYPosition = new Vector3(transform.position.x, 0.5f, transform.position.z);

        Vector3 moveTo = Vector3.MoveTowards(setYPosition, destination.transform.position, 5f * Time.deltaTime);
        transform.position = moveTo;
  

    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.name == "BaseColTest")
        {
            Destroy(gameObject);
        }
    }
}
