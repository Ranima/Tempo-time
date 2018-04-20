using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuseMenu : MonoBehaviour {

    public static bool GamePaused = false;
    public ScoreManager manager;
    public string scene;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update ()
    {

        if (Input.GetKeyDown(KeyCode.Escape) || pauseMenuUI.activeInHierarchy)
        {

            if (GamePaused && Input.GetKeyDown(KeyCode.Escape) && !manager.hasWon)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
        Debug.Log(Time.timeScale);	
	}
   public void Resume()
    {

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;

    }

   public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void loadMenu()
    {
        SceneManager.LoadScene(scene);
        Resume();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Resume();
    }

    public void Quit()
    {
        Debug.Log("goodbye");
        Application.Quit();
    }


}
