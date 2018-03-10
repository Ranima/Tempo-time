using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class colorswich : MonoBehaviour
{
    public Material[] mat;
    int index;

    bool matiral = false;
    public int scoreValue;
    Renderer ren;

    public float timer;
    public float time;
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
        if (ren.sharedMaterial == mat[0])
        {
            Debug.Log(col.name + "you in");
            score();
        }
    }

    public void score()
    {
        scorManager.score += scoreValue;
    }

}
