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
    public GameObject hitbox;
    public Animator anim;
    public float knockDuration;
    public float punchDuration;

    private CharacterController cc;
    private Vector3 moveVector;
    private float maxFallSpeed;
    private bool isHit;

    private float timer;

    private Player player;

    void OnEnable()
    {
        cc = GetComponent<CharacterController>();
        maxFallSpeed = gravity;
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
        //timer = 0;
        //while (timer <= punchDuration)
        //{
        //    if (anim.GetBool("punch") == false)
        //    {
        //        Instantiate<GameObject>(hitbox, transform);
        //        anim.SetBool("punch", true);
        //    }
        //    timer += Time.deltaTime;
        //}
        //if (timer >= punchDuration)
        //{
        //    anim.SetBool("punch", false);
        //}

        if (!anim.GetBool("punch"))
        {
            Transform t = transform;
            t.position += transform.forward;
            Instantiate<GameObject>(hitbox, t);
            anim.SetBool("punch", true);
        }

         Invoke("ResetPunch", punchDuration);

    }

    public void ResetPunch()
    {
        anim.SetBool("punch", false);
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
        if (!anim.GetBool("hit"))
        {
            //timer = 0;
            //for (float i = 0; i <= knockDuration; i += Time.deltaTime)
            //{
            //    moveVector = Vector3.zero;
            //    anim.SetBool("hit", true);
            //    timer += Time.deltaTime;
            //}
            anim.SetBool("hit", true);
        }
        Invoke("ResetHit", knockDuration);
    }

    public void ResetHit()
    {
        anim.SetBool("hit", false);
    }

    public void StopMovement()
    {
        moveVector = Vector3.zero;
    }
}
