using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBaseLock : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    void Update()
    {
        SnapToPlayerPosition();
        SnapToPlayerRotation();
        RotateAroundPlayer();
    }

    void SnapToPlayerPosition()
    {
        transform.position = playerTransform.position;
    }

    void SnapToPlayerRotation()
    {
        bool cameraFollow = FindObjectOfType<CameraModeToggle>().CameraFollow();

        if(cameraFollow)
        {
            Debug.Log(cameraFollow);
            transform.rotation = playerTransform.rotation;
        }
    }

    void RotateAroundPlayer()
    {
        bool cameraFollow = FindObjectOfType<CameraModeToggle>().CameraFollow();

        if(!cameraFollow)
        {
            float input = Input.GetAxis("Horizontal_2");
            float rotationSpeed = GetComponent<CameraRotate>().RotationSpeed();
            float rotate = rotationSpeed * input * Time.deltaTime;
            transform.Rotate(Vector3.up * rotate * Time.deltaTime);
            Debug.Log(cameraFollow + ", " + rotationSpeed);
        }
    }
}
