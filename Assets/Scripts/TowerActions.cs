using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerActions : MonoBehaviour
{

    [Header("Bullet Variables")]
    public GameObject towerBullet;
    public GameObject bulletLoc;

    [Header("Single Target")]
    private GameObject selectedTarget;
    private string targetName;

    
    void Update()
    {
        if(selectedTarget != null)
        {
            Vector3 targetDirection = selectedTarget.transform.position - bulletLoc.transform.position;

            bulletLoc.transform.LookAt(selectedTarget.transform.position);

            Vector3 frontSpawn = bulletLoc.transform.position + bulletLoc.transform.forward * 3.2f;

            GameObject spawn = Instantiate(towerBullet, frontSpawn, bulletLoc.transform.rotation);
            spawn.GetComponent<Rigidbody>().velocity += targetDirection.normalized * 10f;
            Destroy(spawn, 4f);
            Debug.Log(selectedTarget.name);
        }
    }

    IEnumerator fire()
    {
        yield return new WaitForSeconds(2f);




    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyCube"))
        {
            selectedTarget = other.gameObject;
            targetName = other.gameObject.name;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("EnemyCube") && other.gameObject.name == targetName)
        {
            selectedTarget = null;
        }
    }

}
