using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Player Object")]
    public GameObject player;

    [Header("Offset")]
    public Vector3 camOffset;

    void LateUpdate()
    {

        Vector3 camPost = player.transform.position + camOffset;
        transform.position = camPost;

        transform.LookAt(player.transform);
    }
}
