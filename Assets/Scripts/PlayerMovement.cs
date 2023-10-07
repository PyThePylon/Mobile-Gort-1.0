using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")]
    public float mS = 15f;
    public float rS = 90f;


    public  GameObject grabObj;
    public  Vector3 pos;

    private Rigidbody playerRB;

    [Header("JoyStick")]
    public FixedJoystick jStickMovement;
    public FixedJoystick jStickRotation;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float vInput = jStickMovement.Vertical;

        Vector3 playerMove = transform.forward * vInput;

        Vector3 moveP = playerMove * mS;

        playerRB.velocity = moveP;

        float hInput = jStickRotation.Horizontal;

        float rotation = hInput * rS * Time.fixedDeltaTime;

        transform.Rotate(Vector3.up * rotation);

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
