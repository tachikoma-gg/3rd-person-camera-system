using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private GameObject targetObject;
    private GameObject objectHeld;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && objectHeld == null && targetObject != null)
        {
            objectHeld = targetObject;
            objectHeld.transform.SetParent(transform);
            objectHeld.transform.localPosition = Vector3.zero;
        }
        else if(Input.GetKeyDown(KeyCode.Q) && objectHeld != null)
        {
            objectHeld.transform.SetParent(null);
            objectHeld = null;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.layer == 9 && targetObject == null)
        {
            targetObject = collider.gameObject;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.layer == 9)
        {
            targetObject = null;
        }
    }
}
