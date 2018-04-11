using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class colorswich : MonoBehaviour
{
    public Material[] mat;
    int index;
     
    //bool matiral = false;
    //public int scoreValue;
    Renderer ren;

    public float timer;
    public float time;

    public float Scoretimer;
    public float ScoreSetTime;
    // Use this for initialization
    void Start()
    {
        ren = GetComponent<Renderer>();
        ren.enabled = true;

    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= time)
        {
            timer = 0;
            index = Random.Range(0, mat.Length);
            ren.sharedMaterial = mat[index];
        }
       
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "scoreBAll")
        {
            GetComponent<Renderer>().material.color = Color.black;
            Debug.Log("DEAD");   
        }
    }   
}
