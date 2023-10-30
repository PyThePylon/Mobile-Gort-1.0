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

    private Vector3 prevPos;
    private Vector3 currPos;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        prevPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float vInput = jStickMovement.Vertical;

        Vector3 playerMove = transform.forward * vInput;

        currPos = transform.position;

        RaycastHit h;
        if(Physics.Raycast(transform.position, playerMove, out h, playerMove.magnitude *1.5f))
        {
            if(h.collider.gameObject.tag == "invisWall")
            {
                transform.position = prevPos;
                return;
            }
        }

        Vector3 moveP = playerMove * mS;

        playerRB.velocity = moveP;

        float hInput = jStickRotation.Horizontal;

        float rotation = hInput * rS * Time.fixedDeltaTime;

        transform.Rotate(Vector3.up * rotation);

        prevPos = currPos;

    }


    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Buildable")
        {
            grabObj = collision.gameObject;
            pos = collision.gameObject.transform.position;
            Debug.Log("name is: " + grabObj.name + " " + grabObj.transform.position);
        }

        if(collision.gameObject.tag == "invisWall")
        {
            Debug.Log("Hello!");

        }
    }

}
