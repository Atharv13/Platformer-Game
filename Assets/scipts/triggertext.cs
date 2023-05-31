using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggertext : MonoBehaviour {

    public GameObject text;
	void Start ()
    {
        text.SetActive(false);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text.SetActive(true);
            StartCoroutine("Papa");
        }
    }

    IEnumerator Papa()
    {
        yield return new WaitForSeconds(2);
        Destroy(text);
        Destroy(gameObject);
        
    }
}
