using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private Animator animator;

    private bool grounded = true;
    private bool jumpReady = true;

    void Start()
    {
        Physics.gravity *= 9.8f;
    }

    void FixedUpdate()
    {
        JumpCheck();
    }

    void JumpCheck()
    {
        if(Input.GetAxis("Fire1") > 0.19f && grounded && jumpReady)
        {
            Debug.Log("Jump");
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            grounded = false;
            jumpReady = false;
        }

        if(Input.GetAxis("Fire1") < 0.19f)
        {
            jumpReady = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collide");

        if(collision.gameObject.layer == 7)
        {
            Debug.Log("Grounded");
            grounded = true;
        }
    }
}
