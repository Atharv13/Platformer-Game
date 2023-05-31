using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class livesmanager : MonoBehaviour {

	
	public int livescounter;

	public Text livesText;

	private gamemanager gm;

	void Start () {
		livescounter = PlayerPrefs.GetInt("Currentlives");
		gm = FindObjectOfType<gamemanager>();
	}
	
	// Update is called once per frame
	void Update () {
		livesText.text = "x " + livescounter;

		if (livescounter < 1)
        {
			StartCoroutine("QueueGameOver");
        }
	}

	public void takelife()
    {
		livescounter--;
		PlayerPrefs.SetInt("Currentlives", livescounter);
    }

	public void addlife()
    {
		livescounter++;
		PlayerPrefs.SetInt("Currentlives", livescounter);

	}

	IEnumerator QueueGameOver()
    {
		yield return new WaitForSeconds(1.5f);
		gm.GameOver();
    }
}
