using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Sensitivity")]
    float mouseSense = 6f;

    [Header("XRotation")]
    float horizRot = 0f;

    void LateUpdate()
    {

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        horizRot -= mouseY * mouseSense;
        horizRot = Mathf.Clamp(horizRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(horizRot, 0, 0);
        transform.parent.rotation *= Quaternion.Euler(0, mouseX * mouseSense, 0);
    }
}
