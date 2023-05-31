using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private int rotationSpeed;

    void Update()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        float inputX = Input.GetAxis("Horizontal_2");
        float rotate = rotationSpeed * inputX * Time.deltaTime;
        transform.RotateAround(playerTransform.position, Vector3.up, rotate);
    }
}
