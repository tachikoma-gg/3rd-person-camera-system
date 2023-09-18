using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour
{
    private bool isMoving;
    private float hookSpeed;
    private float hookSpeedReturn;
    private float hookLength;

    [SerializeField] private Collider playerCollider;

    private GameObject hookedObject;
    private bool hooked = false;

    private Transform playerTransform;
    private Vector3 hookDirection;

    void Start()
    {
        Collider collider = GetComponent<Collider>();
        Physics.IgnoreCollision(collider, playerCollider);
        playerTransform = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        if(isMoving)
        {
            HookMove();
        }
    }

    void HookMove()
    {
        // transform.LookAt(hookDirection);
        transform.Translate(Vector3.forward * hookSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, playerTransform.position) >= hookLength)
        {
            HookReset();
        }
    }

    public void HookFire(float speed, float length)
    {
        if(!isMoving)
        {
            transform.SetParent(null);
            hookDirection = FindObjectOfType<Aim>().AimPoint();
            transform.LookAt(hookDirection);
            hookLength = length;
            hookSpeed = speed;
            isMoving = true;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        hooked = true;
        hookedObject = collider.gameObject;
        hookedObject.transform.SetParent(transform);
        HookReset();
    }

    void HookReset()
    {
        isMoving = false;
        transform.SetParent(playerTransform);
        transform.localPosition = new Vector3(0, 2, 0);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        if(hooked)
        {
            hookedObject.transform.SetParent(null);
        }
        hooked = false;
        hookedObject = null;
        gameObject.SetActive(false);
    }
}
