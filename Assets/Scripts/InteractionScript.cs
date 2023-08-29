using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    [Header("Distance of Interaction")]
    private float interactionDist = 2f;

    [Header("Tower object")]
    public GameObject towerHolder;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;

            if(Physics.Raycast(transform.position, transform.forward, out hit, interactionDist))
            {
                if(hit.collider != null)
                {
                    Instantiate(towerHolder, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
