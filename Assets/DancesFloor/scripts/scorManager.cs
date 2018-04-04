using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scorManager : MonoBehaviour
{
    
    public Text Scoretext;
    int count;
    // Use this for initialization
    void Start()
    {
        count = 0;
        ScoreCount();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "scoreBAll")
        {
            count++;
            ScoreCount();
            Destroy(GameObject.FindGameObjectWithTag("scoreBAll"));
        }

    }
    void ScoreCount()
    { Scoretext.text = "score" + count.ToString(); }
}