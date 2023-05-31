using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float speed, rotateSpeed;

    void Update()
    {
        RotatePlayer();
        MovePlayer();
    }

    void RotatePlayer()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        if(inputX != 0 || inputY != 0)
        {
            float rotationY = Mathf.Atan2(inputX, inputY) * Mathf.Rad2Deg;
            float cameraRotationY = FindObjectOfType<CameraFollow>().GetComponent<Transform>().eulerAngles.y;
            float targetAngle = rotationY += cameraRotationY;
            float currentAngle = Mathf.LerpAngle(transform.eulerAngles.y, targetAngle, rotateSpeed * Time.deltaTime);

            transform.rotation = Quaternion.Euler(0, currentAngle, 0);
        }
    }

    void MovePlayer()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        float input = Mathf.Sqrt(Mathf.Pow(inputX, 2) + Mathf.Pow(inputY, 2));

        transform.Translate(Vector3.forward * input * speed * Time.deltaTime);

        animator.SetFloat("Speed_f", input * 2);
    }

    public float PlayerSpeed()
    {
        return speed;
    }
}
