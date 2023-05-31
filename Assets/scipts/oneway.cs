using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneway : MonoBehaviour
{
    private GameObject current_way;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (current_way != null)
            {
                Destroy(current_way);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("tp"))
        {
            current_way = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("tp"))
        {
            current_way = null;
        }
    }
}
