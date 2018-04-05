using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class load : MonoBehaviour {
    public GameObject loadingscreen;

    public Slider slider;
    public Text progressText;

    public void loadLevel(int sceneIndex)
    {

        StartCoroutine(loadAs(sceneIndex));

    }

    IEnumerator loadAs(int sceneIndex)
    {

        AsyncOperation oper = SceneManager.LoadSceneAsync(sceneIndex);
        loadingscreen.SetActive(true);

        while (!oper.isDone)
        {
            
            float progress = Mathf.Clamp01(oper.progress / .9f);
            slider.value = progress;
            progressText.text = progress * 100f + "%";
            yield return null;
        }

    }
}
