using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceFloor : MonoBehaviour {

    public float DanceTime = 10;
    public float ScoreTime = 10;
    public float TransTime = 0.5f;
    public int players = 1;

    private bool DanceOver = false;
    private GameObject[] tiles;
    public Object[] mats;
    public Object off;
    public Object score;
    public float danceTimeOver = 0;
    private bool scorePhaseUninit = true;
    private float MyFuckingFloat = 0;

    void Awake () {
        GetTiles();
        LoadMaterials();
    }
	
	// Update is called once per frame
	void Update () {
        if (danceTimeOver < DanceTime)
        {
            if (MyFuckingFloat > TransTime)
            {
                //Probably do nothing while the players dance around
                ChangeAllTiles(tiles);
                MyFuckingFloat = 0;
            }
            MyFuckingFloat += Time.deltaTime;
            danceTimeOver += Time.deltaTime;
        }
        else
        {
            //we just need to trigger this once so use a bool
            if (scorePhaseUninit)
            {
                DanceFloorOff(tiles);
                DanceFloorScore(tiles);
                scorePhaseUninit = false;
            }

            if (danceTimeOver > DanceTime + ScoreTime)
            {
                danceTimeOver = 0;
                scorePhaseUninit = true;
            }
            danceTimeOver += Time.deltaTime;
        }



        //if (!DanceOver)
        //    DanceFaze();
        //if (DanceOver)
        //    ScoreFaze();
	}

    //Gets all tiles on the dance floor.
    void GetTiles() {
        tiles = new GameObject[transform.childCount];
        Debug.Log(GetComponentsInChildren<Transform>().Length);
        for (int i = 0; i < GetComponentsInChildren<Transform>().Length-1 ; i++)
        {
            //tiles[i] = transform.GetChild(i).gameObject;

            
            tiles[i] = GetComponentsInChildren<Transform>()[i].gameObject;
        }
    }

    //loads all materials
    void LoadMaterials() {
        mats = Resources.LoadAll("DanceFloorColors", typeof(Material));
        off = Resources.Load("DanceFloorMisc/black", typeof(Material));
        score = Resources.Load("DanceFloorMisc/Yellow", typeof(Material));
    }

    //Gets a material from the loaded materials
    Material GetMaterial()  {
        return (Material)mats[Random.Range(0, mats.Length)];
    }

    //Changes Material on a tile
    void ChangeTile(GameObject T, Material M) {
        T.GetComponent<Renderer>().material = M;
    }

    //Changes Materials on all the tiles
    void ChangeAllTiles(GameObject[] T)
    {
        for (int i = 1; i < T.Length; i++)
        {
            ChangeTile(T[i], GetMaterial());
        }
    }

    //Turns the whole dance floor black
    void DanceFloorOff(GameObject[] T)
    {
        for(int i = 1; i < T.Length; i++)
        {
            ChangeTile(T[i], (Material)off);
        }
    }

    //Sets 1 less than the amount of players tiles to score
    void DanceFloorScore(GameObject[] T)
    {
        List<int> poolOfIndexes = new List<int>();
        for (int i = 0; i < T.Length; i++)
            poolOfIndexes.Add(i);

            //poolOfIndexes[i] = i;

        List<int> selectedIndexes = new List<int>();

        for(int i = 0; i < players-1; i++)
        {
            int r = Random.Range(0, poolOfIndexes.Count - 1);
            selectedIndexes.Add(poolOfIndexes[r]);
            poolOfIndexes.Remove(r);  
        }
        //selectedIndexes now contains 1,2,3 or 4 random unique numbers in the range of 0-39
        //which we can now use to identify 1,2,3 or 4 gameobjects in the children array
        for (int i = 0; i < players-1; i++)
        {
            Debug.Log(T[selectedIndexes[i]].name);
            ChangeTile(T[selectedIndexes[i]], (Material)score);
        }
    }

    //Dance Faze; cannot score, dance floor flashes.
    void DanceFaze(){
        
        for(float i = 0; i <= DanceTime;)
        {
            //ChangeAllTiles(tiles);
            i += Time.deltaTime;
            if (i >= DanceTime)
                DanceOver = true;
        }
    }

    //Score Faze; can score, dance floor does not flash.
    void ScoreFaze(){
        
        for(float i = 0; i <= ScoreTime;)
        {
            if (i > 0)
            {
                //DanceFloorOff(tiles);
                DanceFloorScore(tiles);
            }
            i += Time.deltaTime;
            if (i >= ScoreTime)
                DanceOver = false;
        }
    }
}
