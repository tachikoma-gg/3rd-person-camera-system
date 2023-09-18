using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    [SerializeField] private float min, max;
    [SerializeField] private GameObject mesh;

    private bool meshOn = true;
    private float timeCurrent;
    private float timeMax;

    void Update()
    {
        timeCurrent += Time.deltaTime;

        if(timeCurrent >= timeMax)
        {
            meshOn = !meshOn;           // Toggle on/off state of player mesh.
            mesh.SetActive(meshOn);
            timeMax = RandomTime();
            timeCurrent = 0;
        }
    }

    // single line

    float RandomTime()
    {
        float random = Random.Range(min, max);
        return random;
    }
}
