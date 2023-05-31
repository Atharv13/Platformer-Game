using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cc : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    [Range(1, 5)]
    public float smoothFactor;
    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 targetpostion = player.position + offset;
        transform.position = targetpostion;
    }
}
