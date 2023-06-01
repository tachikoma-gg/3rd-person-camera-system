using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModeToggle : MonoBehaviour
{
    [SerializeField] Transform cameraLockPoint;
    
    private bool ready = true;

    private bool heightSet = true;
    private bool rotationSet = true;

    void Update()
    {
        IsCameraFollowingPlayer();
    }

    void IsCameraFollowingPlayer()
    {
        float trigger = Input.GetAxis("Trigger_Left");
        CameraHeight cameraHeight = GetComponent<CameraHeight>();
        CameraRotate cameraRotate = GetComponent<CameraRotate>();

        if(trigger > 0.19f && ready)
        {
            cameraHeight.TriggerCameraLock(true);
            cameraRotate.TriggerCameraLock(true);
            HeightSet(false);
            ready = false;
        }
        else if(trigger < 0.19 && !ready)
        {
            cameraHeight.TriggerCameraLock(false);
            cameraRotate.TriggerCameraLock(false);
            ready = true;
        }
        else if(heightSet && rotationSet)
        {
            cameraHeight.TriggerCameraLock(false);
            cameraRotate.TriggerCameraLock(false);
        }
    }

    public void HeightSet(bool input)
    {
        heightSet = input;
    }

    public void RotationSet(bool input)
    {
        rotationSet = input;
    }
}
