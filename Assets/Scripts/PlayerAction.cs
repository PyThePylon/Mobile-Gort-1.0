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
    public AudioSource firePellet;

    [Header("JoyStick")]
    public FixedJoystick jStickMovement;




    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (jStickMovement.Horizontal == 0 || jStickMovement.Vertical == 0)
            {
                Touch fir = Input.GetTouch(0);
                if (fir.phase == TouchPhase.Began)
                {
                    firePellet.Play();
                    Fire();
                }
            }
        }
        
        if (Input.touchCount >= 2)
        {
            Touch sec = Input.touches[1];
            if (sec.phase == TouchPhase.Began)
            {
                firePellet.Play();
                Fire();
            }
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
