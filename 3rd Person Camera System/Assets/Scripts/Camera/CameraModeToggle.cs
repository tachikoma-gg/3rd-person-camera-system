using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModeToggle : MonoBehaviour
{
    [SerializeField] private Transform cameraFreeTransform;
    
    
    void Update()
    {
        transform.position = cameraFreeTransform.position;
        transform.rotation = cameraFreeTransform.rotation;
    }
}
