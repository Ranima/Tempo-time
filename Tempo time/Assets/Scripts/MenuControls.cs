using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class MenuControls : MonoBehaviour {

    private Player player;

    public Button play;
    public Button exit;

	void Update () {
		if(player.GetButtonDown("PunchAndThrow"))
        {
            play.Select();
        }
	}
}
