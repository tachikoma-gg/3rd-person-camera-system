using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] GameObject aimPointIndicator;
    [SerializeField] private Transform aimPoint;

    public Vector3 AimPoint()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitData;
        Physics.Raycast(ray, out hitData);

        aimPointIndicator.transform.position = hitData.point;
        return hitData.point;
    }
}
