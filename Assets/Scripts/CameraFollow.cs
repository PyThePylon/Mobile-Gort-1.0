using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject grabCanvas;

    [Header("Sensitivity")]
    float mouseSense = 6f;

    [Header("XRotation")]
    float horizRot = 0f;


    void LateUpdate()
    {


        if (!grabCanvas.activeSelf)
        {
            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;

            //float mouseX = Input.GetAxis("Mouse X");

            //horizRot -= mouseX * mouseSense;
            //horizRot = Mathf.Clamp(horizRot, -90f, 90f);

            //transform.localRotation = Quaternion.Euler(horizRot, 0, 0);
            //transform.rotation *= Quaternion.Euler(0, horizRot, 0);
        }
    }
}
