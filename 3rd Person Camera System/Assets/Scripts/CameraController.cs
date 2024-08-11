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

    private Vector3 input;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        transform.position = playerTransform.position + targetDirection * distance;
        transform.LookAt(cameraLookTarget);
    }
}
