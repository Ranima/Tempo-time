using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {



    public Text player1T;
    public Slider player1S;
    public Text player2T;
    public Slider player2S;
    public Text player3T;
    public Slider player3S;
    public Text player4T;
    public Slider player4S;
    public GameObject winObject;
    public int ScoreToWin = 10;
    public GameObject DanceFloor;

    public int[] playerScore;
    public bool hasWon = false;

    void Awake(){
        playerScore = new int[gameObject.GetComponent<PlayerSpawn>().players];
    }

    public void IncrementScore(int player){
        playerScore[player] += 1;
        if (player == 0)
        {
            player1T.text = "" + playerScore[player];
            player1S.value = playerScore[player];
        }
        if (player == 1)
        {
            player2T.text = "" + playerScore[player];
            player2S.value = playerScore[player];
        }
        if (player == 2)
        {
            player3T.text = "" + playerScore[player];
            player3S.value = playerScore[player];
        }
        if (player == 3)
        {
            player4T.text = "" + playerScore[player];
            player4S.value = playerScore[player];
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
        winObject.SetActive(true);
        winObject.GetComponentInChildren<Text>().text = ("Player " + (i + 1) + " WINS!");
        hasWon = true;
        Debug.Log("Player " + (i + 1) + " WINS!");
    }

    void TieState()
    {
        winObject.SetActive(true);
        winObject.GetComponentInChildren<Text>().text = ("TIE!");
        hasWon = true;
        Debug.Log("TIE! UNFRIGINBELIEVABLE");
    }

    bool ArrayAgainstPartOfSelf(int[] array, int check)
    {
        bool skip = false;
        for (int i = 0; i < array.Length; i++)
        {
            if (i == check)
                skip = true;
            if (!skip && array[check] <= array[i])
                return true;
            skip = false;
        }
        return false;
    }
}
