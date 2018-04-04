using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuseMenu : MonoBehaviour {

    public static bool GamePused = false;

    public GameObject puseMenuUI;

    // Update is called once per frame
    void Update ()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (GamePused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
        	
	}
   public void Resume()
    {

        puseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePused = false;

    }

   public void Pause()
    {

        puseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePused = true;

    }

    public void loadMenu()
    {

        SceneManager.LoadScene("mainMenu");

    }

    public void Restart()
    {

        SceneManager.LoadScene("dancs");

    }

    public void Quit()
    {

        Debug.Log("im reach bitch");
        Application.Quit();

    }


}
