using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string scene;

    void Awake()
    {
        PlayGame();
    }

    public void PlayGame()
    {

        SceneManager.LoadScene(scene);

    }

    public void Quit()
    {
        Debug.Log("im reach bitch");
        Application.Quit();

    }
}
