using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class MenuControls : MonoBehaviour {

    private Player player;

    public Button play;
    public Button exit;
    void Awake()
    {
        player = ReInput.players.GetPlayer(0);
    }
	void Update () {
		if(player.GetButtonDown("PunchAndThrow"))
        {
            exit.onClick.Invoke();
        }

        if (player.GetButtonDown("Jump"))
        {
            play.onClick.Invoke();
        }
    }
}
