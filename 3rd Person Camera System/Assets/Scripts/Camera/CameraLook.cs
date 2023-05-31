using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private Transform playerHeadTransform;

    void LateUpdate()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        transform.LookAt(playerHeadTransform.position);
    }
}
