using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System.Linq;


public class DanceFloorManeger : MonoBehaviour {

    public Material[] mat;
    GameObject[] floor;
    GameObject curentFloor;

    public int scoreValue;
    int index;
    int ind;
    int dancefloorTiles;

    public float colorTime;
    public float timer;

    public float scoreTime;
    public Renderer[] FloorRenderers;
    Renderer ren; 
    // Use this for initialization
    void Start () {
        //floor = GameObject.FindGameObjectsWithTag("floor");
        //index = Random.Range(0, floor.Length);
        //curentFloor = floor[index];

        for (int ind = 0; ind < floor.Length; ind++)
        {
            FloorRenderers[ind] = floor[ind].GetComponent<Renderer>();
            FloorRenderers[ind].enabled = true;
        }


    }

    // Update is called once per frame
    void Update () {

         floor = GameObject.FindGameObjectsWithTag("floor");
        index = Random.Range(0, floor.Length);
        curentFloor = floor[index];

        timer += Time.deltaTime;

        curentFloor.GetComponent<Renderer>().material.color = Color.red;

        curentFloor.GetComponent<Collider>();
        if (curentFloor &&  timer >= scoreTime)
        {
            timer = 0;
           

        }

       

        //if (timer >= colorTime)
        //{
        //   timer = 0;
        //    index = Random.Range(0, mat.Length);
        //    ren.sharedMaterial = mat[ind];
        //    Debug.Log("you in");

        //}

    }
    void OnTriggerEnter(Collider col)
    {
        if (curentFloor == floor[index])
        {
            Debug.Log(col.name + "you in");
            score();
        }
    }
    public void score()
    {
        //scorManager.score += scoreValue;
    }

}
