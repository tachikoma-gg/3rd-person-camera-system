using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float cameraSpeed;
    [SerializeField] private float cameraMaxDistance, cameraMinDistance;

    void Update()
    {
        transform.position = playerTransform.position;

        /*
        if(Vector3.Distance(transform.position, playerTransform.position) > cameraMaxDistance)
        {
            MoveTowardsPlayer();
        }
        else if(Vector3.Distance(transform.position, playerTransform.position) < cameraMinDistance)
        {
            MoveAwayFromPlayer();
        }
        */
    }

    void MoveTowardsPlayer()
    {
        transform.LookAt(playerTransform.position);
        transform.Translate(Vector3.forward * cameraSpeed * Time.deltaTime);
    }

    void MoveAwayFromPlayer()
    {
        transform.LookAt(playerTransform.position);
        transform.Translate(Vector3.forward * -cameraSpeed * Time.deltaTime);
    }
}
