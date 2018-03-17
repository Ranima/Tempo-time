using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerSpawn : MonoBehaviour {

    public int players;
    public GameObject player;
    public Transform[] spawnPoints;

	void Awake()
    {
        SetSpawns();
        SpawnPlayers();
    }
	
    void SpawnPlayer(Transform spawnPoint)
    {
        Instantiate(player, spawnPoint.position, spawnPoint.rotation);
    }

    void SpawnPlayers()
    {
        for(int i = 0; i < players; i++)
        {
            SpawnPlayer(spawnPoints[i + 1]);
            player.GetComponent<PlayerCon>().playerId = i;
            
        }
    }

    void SetSpawns()
    {
            spawnPoints = GetComponentsInChildren<Transform>();
    }
}
