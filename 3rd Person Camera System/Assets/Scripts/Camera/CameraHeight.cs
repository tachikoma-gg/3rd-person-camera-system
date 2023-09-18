using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHeight : MonoBehaviour
{
    [SerializeField] private Transform cameraPlayer, cameraLockPoint;
    [SerializeField] private int cameraHeightMin, cameraHeightMax;
    [SerializeField] private int cameraSpeed;
    [SerializeField] private float mouseSensitivity;

    void Update()
    {
        bool heightFollow = GetComponent<CameraModeToggle>().HeightFollow();

        if(heightFollow)
        {
            SetCameraHeight();
        }
        else if(!heightFollow)
        {
            LockCameraHeight();
        }
        
    }

    void SetCameraHeight()
    {
        float inputY = Input.GetAxis("Vertical_2");

        float x = cameraPlayer.position.x;
        float y = cameraPlayer.position.y;
        float z = cameraPlayer.position.z;

        y += (inputY * cameraSpeed) * Time.deltaTime;
        y = Mathf.Clamp(y, cameraHeightMin, cameraHeightMax);

        Vector3 positionNew = new Vector3(x, y, z);

        cameraPlayer.position = positionNew;
    }

    void LockCameraHeight()
    {
        float x = cameraPlayer.position.x;
        float y = cameraPlayer.position.y;
        float z = cameraPlayer.position.z;

        float targetY = cameraLockPoint.position.y;

        float currentY = Mathf.Lerp(y, targetY, cameraSpeed * Time.deltaTime);

        cameraPlayer.position = new Vector3(x, currentY, z);

        float checkY= Mathf.Abs(targetY - y);
        if(checkY < 0.01f)
        {
            GetComponent<CameraModeToggle>().HeightSet(true);
        }
    }
}
