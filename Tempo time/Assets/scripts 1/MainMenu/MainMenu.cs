using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject firstMain;
    public GameObject secondMain;
    public string gameScene;

    void Awake()
    {
        staticPlayerInfo.playerMaterials = new Material[4];
    }

    public void PlayGame()
    {
        firstMain.SetActive(!firstMain.activeSelf);
        secondMain.SetActive(!secondMain.activeSelf);
    }

    public void LoadGamplay()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void Quit()
    {
        Debug.Log("I quit");
        Application.Quit();

    }
}
