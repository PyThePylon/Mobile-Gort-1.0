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
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Debug.Log("Rotate CAM!");
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            horizRot -= mouseY * mouseSense;
            horizRot = Mathf.Clamp(horizRot, -90f, 90f);

            transform.localRotation = Quaternion.Euler(horizRot, 0, 0);
            transform.parent.rotation *= Quaternion.Euler(0, mouseX * mouseSense, 0);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Debug.Log("DONT ROTATE CAM!");
        }
    }
}
