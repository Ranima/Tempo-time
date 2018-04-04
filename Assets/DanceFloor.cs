//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class DanceFloor : MonoBehaviour {
//    [Header ("Array" )]
//    public Material[] Mat;
//    GameObject[] Floor;

//    [Header("Timer")]
//    public float setTime;
//    public float TimerCountDown;



//    // other varables
//    public GameObject CurrentFloor;
//    int index;

//    //int[] i = {1,2,3,4,5,6,7,8,9 };
//    Renderer ren;
//    //Collider col;

//   public void changeColor(floorTile tile)
//    {
//        //tile.GetComponent<Renderer>().sharedMaterial=

//    }
//    // Use this for initialization
//    void Start () {
       
//       Floor = GameObject.FindGameObjectsWithTag("floor");
//       index = Random.Range(0, Floor.Length);
//       CurrentFloor = Floor[index];

//       ren = CurrentFloor.GetComponent<Renderer>();
//        ren.enabled = true;
//        //col = CurrentFloor.GetComponent<Collider>();
//        //ren = Floor[].GetComponent<Renderer>();
        

        
//    }

//    // Update is called once per frame
//    void Update ()
//    {

//        TimerCountDown += Time.deltaTime;

//        if (TimerCountDown >= setTime && CurrentFloor)
//        {
            
//            TimerCountDown = 0;
//            index = Random.Range(0, Mat.Length);
//            ren.sharedMaterial = Mat[index];
//            score();
           
            
//        }
      
//    }



//    public void score()
//    {
//        //scorManager.score += scoreValue;
//    }

