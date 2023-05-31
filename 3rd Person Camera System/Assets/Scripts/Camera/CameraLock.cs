using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float offset;

    void Update()
    {
        Vector3 offsetVector = new Vector3(0, 0, offset);
        transform.position = playerTransform.position + offsetVector;
    }
}
