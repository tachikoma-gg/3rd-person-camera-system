using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float speed;

    private float inputX, inputY;

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        RotatePlayer();
        MovePlayer();
    }

    void RotatePlayer()
    {
        float rotationY = Mathf.Atan2(inputX, inputY) * Mathf.Rad2Deg;  // Inverse Tangent. Convert Radians to Degrees.

        transform.rotation = Quaternion.Euler(0, rotationY, 0);         // Rotate player.
        
    }

    void MovePlayer()
    {
        float input = Mathf.Sqrt(Mathf.Pow(inputX, 2) + Mathf.Pow(inputY, 2));  // Pythagorean Theorem.
        
        transform.Translate(Vector3.forward * input * speed * Time.deltaTime);  // Translate player forward. Not relative to camera.
        animator.SetFloat("Speed_f", input * 2);
    }
}
