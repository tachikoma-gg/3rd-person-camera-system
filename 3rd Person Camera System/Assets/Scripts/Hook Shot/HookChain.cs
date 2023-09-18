using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookChain : MonoBehaviour
{
    [SerializeField] private GameObject[] hookLinks;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject hookAnchor;

    void Update()
    {
        hookAnchor.transform.LookAt(player.transform.position + new Vector3(0, 2, 0));

        float distance = Vector3.Distance(transform.position, player.transform.position);
        float segmentLength = distance / hookLinks.Length;

        for(int i = 0; i < hookLinks.Length; i++)
        {
            float z = segmentLength * i * 2;
            hookLinks[i].transform.localPosition = new Vector3(0, 0, z);
        }
    }
}
