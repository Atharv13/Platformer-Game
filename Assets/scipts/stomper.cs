using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stomper : MonoBehaviour {

	public float bounceforce;

	private Rigidbody2D rb;
	public int damage;


	void Start() {
		rb = transform.parent.GetComponent<Rigidbody2D>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy"&&rb.velocity.y<0.005f){
            FindObjectOfType<soundmanager>().Play("boona_bye");
            other.gameObject.GetComponent<Enemyhp>().takedamage(damage);
			rb.AddForce(transform.up * bounceforce, ForceMode2D.Impulse);
		}
	}
}
