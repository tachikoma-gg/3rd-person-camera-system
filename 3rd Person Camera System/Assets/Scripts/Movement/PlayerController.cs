using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float speed, rotateSpeed, turnSpeed;

    public float test;

    void Update()
    {
        test = Input.GetAxis("Horizontal_2");

        bool cameraFollow = FindObjectOfType<CameraModeToggle>().CameraFollow();

        if(cameraFollow)
        {
            RotatePlayer();
            MovePlayer();
        }
        else if(!cameraFollow)
        {
            MovementLock();
        }
        
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

    void MovementLock()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 input = new Vector3(inputX, 0, inputY);

        transform.Translate(input * speed * Time.deltaTime);

        float currentSpeed = Mathf.Sqrt(Mathf.Pow(inputX, 2) + Mathf.Pow(inputY, 2));

        animator.SetFloat("Speed_f", currentSpeed * 2);

        float inputX_2 = Input.GetAxis("Horizontal_2");

        transform.Rotate(Vector3.up * inputX_2 * turnSpeed * Time.deltaTime);
    }

    public float PlayerSpeed()
    {
        return speed;
    }
}
