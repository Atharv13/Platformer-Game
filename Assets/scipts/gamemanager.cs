using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour {
	public playercontroller theplayer;
	private Vector2 playerstart;

	public GameObject VictoryScreen;
	public GameObject GameOverScreen;

	public string MainMenu;

	public void Start () {
		playerstart = theplayer.transform.position;
	}
	
	public void Victory()
    {
        FindObjectOfType<soundmanager>().Play("iitaalap");
        VictoryScreen.SetActive(true);
		theplayer.gameObject.SetActive(false);
    }
	public void GameOver()
	{
        GameOverScreen.SetActive(true);
        theplayer.gameObject.SetActive(false);
		StartCoroutine("GameReset");
        thememanagertrigger.unlock = false;
	}

	IEnumerator GameReset()
    {
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene(MainMenu);
    }
	public void Replay()
	{
		VictoryScreen.SetActive(false);
		GameOverScreen.SetActive(false);
		theplayer.gameObject.SetActive(true);
		theplayer.transform.position = playerstart;
    }

}
