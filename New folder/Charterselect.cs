using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Charterselect : MonoBehaviour {

    List<GameObject> PlayerList;



    private GameObject[] Charterlist;
    private int index;
    SceneManager current;

    // Use this for initialization
    void Start()
    {

        index = PlayerPrefs.GetInt("LoadScrean");

        Charterlist = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            Charterlist[i] = transform.GetChild(i).gameObject;

        }

        foreach (GameObject go in Charterlist)
        {
            go.SetActive(false);
        }

        if (Charterlist[index])
        {
            Charterlist[index].SetActive(true);
        }

    }


    public void leftArrow()
    {

        Charterlist[index].SetActive(false);

        index--;
        if (index < 0)
        {
            index = Charterlist.Length - 1;

        }

        Charterlist[index].SetActive(true);
    }

    public void rightArrow()
    {

        Charterlist[index].SetActive(false);

        index++;
        if (index == Charterlist.Length)
        {
            index = 0;

        }

        Charterlist[index].SetActive(true);
    }

    public void selectButtton()
    {
        PlayerPrefs.SetInt("LoadScrean", index);
        PlayerPrefs.Save();
    }

    public void select(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
    }

}
