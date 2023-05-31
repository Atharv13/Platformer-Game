using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformpatroller : MonoBehaviour {
	public float movespeed;
	public float raylength;
	private bool moveleft;
	public Transform contactchecker;

	void Start()
	{
		moveleft = true;
	}

	// Update is called once per frame
	void Update()
	{
		transform.Translate(Vector2.left * movespeed * Time.deltaTime);
	}

	private void FixedUpdate()
	{
		int layerMask = 1 << 10;
		layerMask = ~layerMask;

		RaycastHit2D contactCheck = Physics2D.Raycast(contactchecker.position, Vector2.down, raylength,layerMask);
		Debug.DrawRay(contactchecker.position, Vector2.down * raylength, Color.red);
		if (contactCheck == false)
		{
			if (moveleft == true)
			{
				transform.eulerAngles = new Vector2(0, -180);
				moveleft = false;
			}
			else
			{
				transform.eulerAngles = new Vector2(0, 0);
				moveleft = true;
			}
		}
	}
}

