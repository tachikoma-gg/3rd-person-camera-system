using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private Transform playerHeadTransform;

    void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
    }

    void LateUpdate()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        transform.LookAt(playerHeadTransform.position);
    }
}
