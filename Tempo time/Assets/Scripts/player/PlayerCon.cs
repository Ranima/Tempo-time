﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerCon : MonoBehaviour {

    public int playerId = 0;

    public float moveSpeed = 3.0f;
    public float gravity = 5.0f;
    public float jump = 3.0f;
    public float fallAcceleration = 1;
    public GameObject hitbox;
    public Animator anim;
    public float knockDuration;
    public float punchDuration;
    //public Vector3 PDM;

    private CharacterController cc;
    private Vector3 moveVector;
    private float maxFallSpeed;
    private bool isHit;
   // private Transform PT;

    private Player player;

    void OnEnable()
    {
        cc = GetComponent<CharacterController>();
        maxFallSpeed = gravity;
 //       PT.position = PDM;
    }

    void Update()
    {
        player = ReInput.players.GetPlayer(playerId);

        if (!ReInput.isReady) return;
        if (player == null) return;

        GetInput();
        ProcessInput();
        KnockDown();
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
        if(player.GetButtonDown("PunchAndThrow"))
        {
            PunchAndThrow();
        }

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

    private void PunchAndThrow()
    {
        for (float p = 0; p <= knockDuration; p += Time.deltaTime)
        {
            Instantiate<GameObject>(hitbox, transform);
            anim.SetBool("hit", true);
            return;
        }
        anim.SetBool("hit", false);
    }


    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "hitBox")
        {
            isHit = true;
        }
    }

    private void KnockDown()
    {
        if (isHit == true)
        {
            for (float i = 0; i <= knockDuration; i += Time.deltaTime)
            {
                moveVector = Vector3.zero;
                anim.SetBool("hit", true);
                return;
            }
        }
        anim.SetBool("hit", false);
    }
}
