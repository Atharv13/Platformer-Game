using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string lvltoload;
    public string Scene1;
    public string Scene2;
    public int dfltlives;
    public int dfltmoney;
    

    private void Start()
    {
        PlayerPrefs.SetInt("Currentlives", dfltlives);
        PlayerPrefs.SetInt("Currentmoney", dfltmoney);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(lvltoload);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GotoScene1()
    {
        SceneManager.LoadScene(Scene1);
    }

    public void GotoScene2()
    {
        SceneManager.LoadScene(Scene2);
    }
}
