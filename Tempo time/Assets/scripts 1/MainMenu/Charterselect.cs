using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Charterselect : MonoBehaviour {

    public GameObject player;
    public int playerId = 0;

    private Object[] Charterlist;
    private int index;

    // Use this for initialization
    void Start()
    {
        index = 0;
        Charterlist = Resources.LoadAll("PlayerSkins", typeof(Material));
        rightArrow();
    }


    public void leftArrow()
    {
        index--;
        if (index < 0)
        {
            index = Charterlist.Length - 1;

        }

        player.GetComponent<Renderer>().material = (Material)Charterlist[index];
        selectButtton();
    }

    public void rightArrow()
    {
        index++;
        if (index >= Charterlist.Length)
        {
            index = 0;

        }

        player.GetComponent<Renderer>().material = (Material)Charterlist[index];
        selectButtton();
    }

    public void selectButtton()
    {
        staticPlayerInfo.playerMaterials[playerId] = (Material)Charterlist[index];
    }
}
