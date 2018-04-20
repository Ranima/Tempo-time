using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerSpawn : MonoBehaviour {

    public int players;
    public GameObject player;
    public Transform[] spawnPoints;
    public Material defMat;

	void Awake()
    {
        SetSpawns();
        SpawnPlayers();
    }
	
    void SpawnPlayer(Transform spawnPoint)
    {
        Instantiate(player, spawnPoint.position, spawnPoint.rotation, transform);
    }

    void SpawnPlayers()
    {
        for(int i = 0; i < players; i++)
        {
            GameObject TempPlayer = Instantiate(player, spawnPoints[i + 1].position, spawnPoints[i + 1].rotation, transform);
            TempPlayer.GetComponent<PlayerCon>().playerId = i;
          
            if (staticPlayerInfo.playerMaterials[i] != null)
            { TempPlayer.GetComponent<RendererHolder>().actualRender.material = staticPlayerInfo.playerMaterials[i]; }
            else
                TempPlayer.GetComponent<RendererHolder>().actualRender.material = defMat;
        }
    }

    void SetSpawns()
    {
            spawnPoints = GetComponentsInChildren<Transform>();
    }
}
