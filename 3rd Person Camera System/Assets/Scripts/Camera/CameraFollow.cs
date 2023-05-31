using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float cameraAcceleration;
    [SerializeField] private float cameraMaxDistance, cameraMinDistance;

    private float cameraSpeedCurrent;

    void Update()
    {
        PointTowardsPlayer();
        CalculateCameraSpeed();
        MoveCamera();
        LevelWithPlayer();
    }

    void PointTowardsPlayer()
    {
        transform.LookAt(playerTransform.position);
    }

    void MoveCamera()
    {
        transform.Translate(Vector3.forward * cameraSpeedCurrent * Time.deltaTime);
    }

    void CalculateCameraSpeed()
    {
        float cameraSpeedMax = FindObjectOfType<PlayerController>().PlayerSpeed();

        if(DistanceFromPlayer() > cameraMaxDistance && Mathf.Abs(cameraSpeedCurrent) < cameraSpeedMax)
        {
            cameraSpeedCurrent += cameraAcceleration * Time.deltaTime;
        }
        else if(DistanceFromPlayer() < cameraMinDistance && Mathf.Abs(cameraSpeedCurrent) < cameraSpeedMax)
        {
            cameraSpeedCurrent -= cameraAcceleration * Time.deltaTime;
        }
        else if(DistanceFromPlayer() < cameraMaxDistance && DistanceFromPlayer() > cameraMinDistance && cameraSpeedCurrent != 0)
        {
            cameraSpeedCurrent -= cameraAcceleration * cameraSpeedCurrent/Mathf.Abs(cameraSpeedCurrent) * Time.deltaTime;
        }
    }

    void LevelWithPlayer()
    {
        float x = transform.position.x;
        float y = playerTransform.position.y;
        float z = transform.position.z;

        Vector3 level = new Vector3(x, y, z);

        transform.position = level;
    }

    float DistanceFromPlayer()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        
        return distance;
    }
}
