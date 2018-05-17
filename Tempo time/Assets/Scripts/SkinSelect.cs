using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class SkinSelect : MonoBehaviour {

    public int playerId = 0;

    public Button up;
    public Button down;

    public float switchIntervul = 0.5f;
    private float timer = 0;

    private Player player;

	// Use this for initialization
	void Awake()
    {
        player = ReInput.players.GetPlayer(playerId);
    }
	
	// Update is called once per frame
	void Update () {
		if(player.GetAxis("MoveVertical") > 0 && timer > switchIntervul)
        {
            up.onClick.Invoke();
            timer = 0;
        }
        if (player.GetAxis("MoveVertical") < 0 && timer > switchIntervul)
        {
            down.onClick.Invoke();
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
