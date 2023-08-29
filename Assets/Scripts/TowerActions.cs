using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerActions : MonoBehaviour
{

    [Header("Single Target")]
    private GameObject selectedTarget;

    
    void Update()
    {
        if(selectedTarget == null)
        {
            Debug.Log("Name is missing!");
        }
        else
        {
            Debug.Log(selectedTarget.name);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(selectedTarget == null)
        {
            selectedTarget = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(selectedTarget != null)
        {
            selectedTarget = null;
        }
    }

}
