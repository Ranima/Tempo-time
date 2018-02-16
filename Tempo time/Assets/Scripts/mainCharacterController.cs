using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class mainCharacterController : MonoBehaviour {

    public int playerId = 0;

    public float forceMultiplier = 10;
    public float rotSpeed = 10;
    public Rewired.Player player;
    private float x = 0;
    private float y = 0;
    private Quaternion oldvar;
    Quaternion newvar;
    
    void Awake()
    {
        player = ReInput.players.GetPlayer(playerId);
    }

    void Update ()
    {

        x = player.GetAxis("Move Horizontal") * forceMultiplier;
        y = player.GetAxis("Move Vertical") * forceMultiplier;

        if (GetComponent<Rigidbody>().velocity.magnitude > 0.5f)
        {
            oldvar = transform.rotation;
            transform.LookAt(GetComponent<Rigidbody>().velocity + transform.position - new Vector3(0, GetComponent<Rigidbody>().velocity.y, 0));
            newvar = transform.rotation;
            transform.rotation = Quaternion.Lerp(oldvar, newvar, rotSpeed);
            //transform.LookAt(GetComponent<Rigidbody>().velocity + transform.position - new Vector3(0, GetComponent<Rigidbody>().velocity.y, 0));
        }
        GetComponent<Rigidbody>().AddForce(x, 0, y);
    }
}
