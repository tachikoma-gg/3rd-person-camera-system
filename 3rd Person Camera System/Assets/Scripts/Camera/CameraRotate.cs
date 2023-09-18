using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private Transform playerTransform, cameraLockPoint;
    [SerializeField] private int rotationSpeed, snapSpeed;
    [SerializeField] private float mouseSensitivity;

    void Update()
    {
        bool cameraFollow = GetComponent<CameraModeToggle>().CameraFollow();

        if(cameraFollow)
        {
            RotateCamera();
        }
        else if(!cameraFollow)
        {
            LockCameraRotation();
        }
    }

    void RotateCamera()
    {
        float inputX = Input.GetAxis("Horizontal_2");
        float rotate = (rotationSpeed * inputX) * Time.deltaTime;
        transform.RotateAround(playerTransform.position, Vector3.up, rotate);
    }

    void LockCameraRotation()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        float targetX = cameraLockPoint.position.x;
        float targetY = cameraLockPoint.position.y;
        float targetZ = cameraLockPoint.position.z;

        float currentX = Mathf.Lerp(x, targetX, snapSpeed * Time.deltaTime);
        float currentY = Mathf.Lerp(y, targetY, snapSpeed * Time.deltaTime);
        float currentZ = Mathf.Lerp(z, targetZ, snapSpeed * Time.deltaTime);

        transform.position = new Vector3(currentX, currentY, currentZ);

        float checkSet = currentX + currentY + currentZ;
        if(checkSet < 0.01f)
        {
            GetComponent<CameraModeToggle>().RotationSet(true);
        }
    }

    public float RotationSpeed()
    {
        return rotationSpeed;
    }
}
