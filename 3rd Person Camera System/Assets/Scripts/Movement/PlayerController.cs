using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform playerTarget;
    [SerializeField] private float speed;

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        
        float input = Mathf.Sqrt(inputX * inputY);

        animator.SetFloat("Speed_f", input * 2);

        transform.LookAt(playerTarget.position);
        // MovePlayer(input, speed);
        
    }

    void MovePlayer(float input, float speed)
    {
        // transform.Translate(Vector3.forward * input * speed * Time.deltaTime);
    }
}
