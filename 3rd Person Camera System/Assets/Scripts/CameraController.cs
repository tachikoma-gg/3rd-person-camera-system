using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Parameters")]
    [SerializeField] private float distance;
    [SerializeField] private float lerpSpeed;

    private Vector3 targetDirection = new Vector3(0, 1, -1).normalized;
    private Vector3 targetPosition;

    [Header("Components")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform cameraLookTarget;

    void Update()
    {
        SetTarget();
        RotateCamera();
        MoveCamera();
    }

    void LateUpdate()
    {
        transform.LookAt(cameraLookTarget);
    }

    void SetTarget()
    {
        targetPosition = playerTransform.position + targetDirection * distance;
    }

    void MoveCamera()
    {
        float x = targetPosition.x + Mathf.Pow(transform.position.x - targetPosition.x, -lerpSpeed * Time.deltaTime);
        float y = targetPosition.y + Mathf.Pow(transform.position.y - targetPosition.y, -lerpSpeed * Time.deltaTime);
        float z = targetPosition.z + Mathf.Pow(transform.position.z - targetPosition.z, -lerpSpeed * Time.deltaTime);

        transform.position = new (x, y, z);
    }

    void RotateCamera()
    {

    }

    
}
