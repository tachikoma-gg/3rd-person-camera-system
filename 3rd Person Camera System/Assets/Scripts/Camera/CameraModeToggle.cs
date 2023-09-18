using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModeToggle : MonoBehaviour
{
    [SerializeField] Transform cameraLockPoint;
    [SerializeField] private bool toggleHoldCamera;
    
    private bool ready = true;

    private bool heightSet = true;
    private bool rotationSet = true;
    private bool cameraFollow = true;
    private bool cameraHold = false;

    void Update()
    {
        CheckTrigger();
        CheckShoulder();
    }

    void CheckTrigger()
    {
        float trigger = Input.GetAxis("Trigger_Left");
        CameraHeight cameraHeight = GetComponent<CameraHeight>();
        CameraRotate cameraRotate = GetComponent<CameraRotate>();

        if((trigger > 0.19f) && ready)
        {
            HeightSet(false);
            cameraFollow = false;
            ready = false;
        }
        else if((trigger < 0.19) && !ready)
        {
            cameraFollow = true;
            ready = true;
        }
        else if(heightSet && rotationSet)
        {
            // cameraFollow = true;
        }
    }

    void CheckShoulder()
    {
        if(Input.GetKeyDown(KeyCode.P) || (Input.GetKeyUp(KeyCode.P) && toggleHoldCamera))
        {   
            cameraHold = !cameraHold;
        }
    }

    void CheckFollowState()
    {
        if(heightSet && rotationSet)
        {
            cameraFollow = true;
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

    public bool HeightFollow()
    {
        return heightSet;
    }

    public bool CameraFollow()
    {
        return cameraFollow;
    }

    public bool CameraHold()
    {
        return cameraHold;
    }
}
