using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Speed")]
    public float mS = 15f;

    public  GameObject grabObj;
    public  Vector3 pos;

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        Vector3 playerMove = new Vector3(hInput, 0f, vInput);

        transform.Translate(playerMove * mS * Time.deltaTime);
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
