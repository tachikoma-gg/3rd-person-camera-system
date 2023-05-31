using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHeight : MonoBehaviour
{
    [SerializeField] private Transform cameraFreeTransform;
    [SerializeField] private int cameraHeightMin, cameraHeightMax;
    [SerializeField] private int cameraSpeed;

    void Update()
    {
        SetCameraHeight();
    }

    void SetCameraHeight()
    {
        float inputY = Input.GetAxis("Vertical_2");

        float x = cameraFreeTransform.position.x;
        float y = cameraFreeTransform.position.y;
        float z = cameraFreeTransform.position.z;

        y += inputY * cameraSpeed * Time.deltaTime;
        y = Mathf.Clamp(y, cameraHeightMin, cameraHeightMax);

        Vector3 positionNew = new Vector3(x, y, z);

        cameraFreeTransform.position = positionNew;
    }
}
