using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerCon : MonoBehaviour {

    public int playerId = 0;

    public float moveSpeed = 3.0f;
    public float gravity = 5.0f;
    public float jump = 3.0f;
    public float fallAcceleration = 1;
    public Animator anim;

    private CharacterController cc;
    private Vector3 moveVector;
    private float maxFallSpeed;

    private Rewired.Player player { get { return ReInput.isReady ? ReInput.players.GetPlayer(playerId) : null; } }

    void OnEnable()
    {
        cc = GetComponent<CharacterController>();
        maxFallSpeed = gravity;
    }

    void Update()
    {
        if (!ReInput.isReady) return;
        if (player == null) return;

        GetInput();
        ProcessInput();
        Gravity();
    }

    private void GetInput()
    {

        moveVector.x = player.GetAxis("MoveHorizontal");
        moveVector.z = player.GetAxis("MoveVertical");
    }

    private void ProcessInput()
    {
        if (moveVector.x != 0.0f || moveVector.z != 0.0f)
        {
            cc.Move(moveVector * moveSpeed * Time.deltaTime);
            anim.SetFloat("speed", moveVector.magnitude);
        }
        else
            anim.SetFloat("speed", 0);
    }

    private void Gravity()
    {
        //if (jumpTimer <= 10)
        //    jumpTimer += JTI;
        //if (!cc.isGrounded && jumpTimer > 10)
        //    moveVector.y = -gravity;
        //if (player.GetButtonDown("Jump") && cc.isGrounded)
        //{ moveVector.y = jump; jumpTimer = 0; }

        if (!cc.isGrounded)
        {
            gravity += fallAcceleration * Time.deltaTime;
            if (gravity > maxFallSpeed)
                gravity = maxFallSpeed;
        }
        else
        {
            gravity = 1;
        }
        if (player.GetButtonDown("Jump") && cc.isGrounded)
            gravity = -jump;
        moveVector.y = -gravity;

        cc.Move(moveVector * Time.deltaTime);

        Vector3 velo = cc.velocity;
        velo.y -= velo.y;
        cc.transform.LookAt(cc.transform.position + velo);
    }
}
