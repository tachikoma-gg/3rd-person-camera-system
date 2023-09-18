using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookShot : MonoBehaviour
{
    [SerializeField] private GameObject hook;
    [SerializeField] private float hookSpeed, hookLength;
    
    private bool hookArmed = true;

    void Update()
    {
        if((Input.GetKeyDown(KeyCode.E) || Input.GetAxis("Fire1") > 0.19f) && hookArmed)
        {
            hookArmed = false;
            FireHook();
        }

        if((Input.GetKeyUp(KeyCode.E) || Input.GetAxis("Fire1") < 0.19f) && !hookArmed)
        {
            hookArmed = true;
        }
    }

    void FireHook()
    {
        hook.SetActive(true);
        FindObjectOfType<HookMovement>().HookFire(hookSpeed, hookLength);
    }





    private bool IsEven(int number)
    {
        if(number % 2 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }







}
