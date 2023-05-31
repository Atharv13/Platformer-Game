using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moneymanager : MonoBehaviour
{

	public livesmanager lm;

	public int moneycounter;

	public Text moneyText;

	private gamemanager gm;

	//public playercontroller pc;

	void Start()
	{
		moneycounter = PlayerPrefs.GetInt("Currentmoney");
		gm = FindObjectOfType<gamemanager>();
		lm = FindObjectOfType<livesmanager>();
		//pc = FindObjectOfType<playercontroller>();
	}

	// Update is called once per frame
	void Update()
	{
		moneyText.text = "Rs" + moneycounter;

	}

	public void takemoney()
	{
		moneycounter-=100;
		PlayerPrefs.SetInt("Currentmoney", moneycounter);

	}

	public void addmoney()
	{
		moneycounter+=100;
        FindObjectOfType<soundmanager>().Play("cash");
        PlayerPrefs.SetInt("Currentmoney", moneycounter);

	}

	IEnumerator QueueGameOver()
	{
		yield return new WaitForSeconds(1.5f);
		gm.GameOver();
	}
}

