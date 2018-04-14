using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text player1;
    public Text player2;
    public Text player3;
    public Text player4;
    public int ScoreToWin = 10;
    public GameObject DanceFloor;

    public int[] playerScore;

    void Awake(){
        playerScore = new int[gameObject.GetComponent<PlayerSpawn>().players];
    }

    public void IncrementScore(int player){
        playerScore[player] += 1;
        if (player == 0)
        {
            player1.text = "" + playerScore[player];
        }
        if (player == 1)
        {
            player2.text = "" + playerScore[player];
        }
        if (player == 2)
        {
            player3.text = "" + playerScore[player];
        }
        if (player == 3)
        {
            player4.text = "" + playerScore[player];
        }
        ScoreCheck();
    }

    void ScoreCheck(){
        //JON:Made the loop not go upto i<= but < as =4 results in exceeded bounds
        for (int i = 0; i < DanceFloor.GetComponent<DanceFloor>().players; i++)
        {
            bool check = true;

            if (playerScore[i] >= ScoreToWin)
            {
                if (check)
                {
                    if (ArrayAgainstPartOfSelf(playerScore, i))
                    {
                        TieState();
                        break;
                    }
                    check = false;
                }
                WinState(i);
                break;
            }
        }

    }

    void WinState(int i)
    {
        Debug.Log("Player " + (i + 1) + " WINS!");
    }

    void TieState()
    {
        Debug.Log("UNFRIGINBELIEVABLE");
    }

    bool ArrayAgainstPartOfSelf(int[] array, int check)
    {
        bool skip = false;
        for (int i = 0; i <= array.Length; i++)
        {
            if (i == check)
                skip = true;
            if (!skip && array[check] <= array[i])
                return true;
        }
        return false;
    }
}
