using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {

    public string nextLevel;

    public void Replay()
    {
        FindObjectOfType<gamemanager>().Replay();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
