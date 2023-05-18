using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerAngle;

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        transform.localPosition = new Vector3(inputX, 0, inputY);

        SetRotation();
        SetPosition();
        SetPlayerAngle();
    }

    void SetRotation()
    {
        float yRotation = cameraTransform.rotation.y;

        transform.eulerAngles = new Vector3(transform.rotation.x, yRotation, transform.rotation.z);
    }

    void SetPosition()
    {
        transform.position = player.position;
    }

    void SetPlayerAngle()
    {
        // playerAngle.LookAt(transform.position);
    }
}
