using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBaseLock : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    void Update()
    {
        SnapToPlayerPosition();
        // SnapToPlayerRotation();
        // RotateAroundPlayer();
    }

    void SnapToPlayerPosition()
    {
        transform.position = playerTransform.position;
    }

    void SnapToPlayerRotation()
    {
        bool cameraHold = FindObjectOfType<CameraModeToggle>().CameraHold();

        if(cameraHold)
        {
            Debug.Log(cameraHold);
            transform.rotation = playerTransform.rotation;
        }
    }

    void RotateAroundPlayer()
    {
        bool cameraHold = FindObjectOfType<CameraModeToggle>().CameraHold();

        if(!cameraHold)
        {
            float input = Input.GetAxis("Horizontal_2");
            float rotationSpeed = FindObjectOfType<CameraRotate>().RotationSpeed();
            float rotate = rotationSpeed * input * Time.deltaTime;
            transform.Rotate(Vector3.up * rotate * Time.deltaTime);
            Debug.Log(cameraHold + ", " + rotationSpeed);
        }
    }
}
