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
        if((Input.GetAxis("Fire2") > 0.19f || Input.GetKeyDown(KeyCode.Space)) && grounded && jumpReady)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            grounded = false;
            jumpReady = false;
        }

        if(Input.GetAxis("Fire1") < 0.19f || Input.GetKeyUp(KeyCode.Space))
        {
            jumpReady = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 7)
        {
            grounded = true;
        }
    }
}
