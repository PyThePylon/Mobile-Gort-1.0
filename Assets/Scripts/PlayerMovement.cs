using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Speed")]
    public float mS = 15f;


    public  GameObject grabObj;
    public  Vector3 pos;

    private Rigidbody playerRB;

    [Header("JoyStick")]
    public FixedJoystick jStick;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //joyStickControl = true;
        playerRB.velocity = new Vector3(jStick.Horizontal * 5f, GetComponent<Rigidbody>().velocity.y, jStick.Vertical * 5f);

        if (jStick.Horizontal != 0 || jStick.Vertical != 0)
        {
            float angle = Mathf.Atan2(jStick.Horizontal, jStick.Vertical) * Mathf.Rad2Deg;

            Quaternion targetRotation = Quaternion.Euler(0f, angle, 0f);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
        
    }



    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Buildable")
        {
            grabObj = collision.gameObject;
            pos = collision.gameObject.transform.position;
            Debug.Log("name is: " + grabObj.name + " " + grabObj.transform.position);
        }
    }
}
