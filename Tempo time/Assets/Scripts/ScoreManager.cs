using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text player1;
    public Text player2;
    public Text player3;
    public Text player4;

    private int[] playerScore;

    void Awake(){
        playerScore = new int[gameObject.GetComponent<PlayerSpawn>().players];
    }

    void IncrementScore(int player){
        playerScore[player] += 1;
        if (player == 0)
        {
            player1.text = ""+playerScore[player];
        }
        if (player == 1)
        {
            player1.text = "" + playerScore[player];
        }
        if (player == 2)
        {
            player1.text = "" + playerScore[player];
        }
        if (player == 3)
        {
            player1.text = "" + playerScore[player];
        }
    }
}
