using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public GameObject grabCanvas;

    [Header("Player Fire")]
    public GameObject pellet;
    public Transform fireLoc;
    public float bulletSpeed;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {
        if (!grabCanvas.activeSelf)
        {
            GameObject newPel = Instantiate(pellet, fireLoc.position, pellet.transform.rotation);

            Rigidbody pelRB = newPel.GetComponent<Rigidbody>();
            pelRB.AddForce(fireLoc.forward * bulletSpeed, ForceMode.Impulse);

            Destroy(newPel, 4f);
        }
    }
}
