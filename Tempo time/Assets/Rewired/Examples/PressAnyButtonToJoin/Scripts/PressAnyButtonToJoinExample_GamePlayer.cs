// Copyright (c) 2017 Augie R. Maddox, Guavaman Enterprises. All rights reserved.

using UnityEngine;
using System.Collections;

namespace Rewired.Demos {

    [AddComponentMenu("")]
    [RequireComponent(typeof(CharacterController))]
    public class PressAnyButtonToJoinExample_GamePlayer : MonoBehaviour {

        public int playerId = 0;

        public float moveSpeed = 3.0f;
        public float gravity = 5.0f;

        private CharacterController cc;
        private Vector3 moveVector;

        private Rewired.Player player { get { return ReInput.isReady ? ReInput.players.GetPlayer(playerId) : null; } }

        void OnEnable() {
            cc = GetComponent<CharacterController>();
        }

        void Update() {
            if(!ReInput.isReady) return;
            if(player == null) return;

            GetInput();
            ProcessInput();
            Gravity();
        }

        private void GetInput() {

            moveVector.x = player.GetAxis("MoveHorizontal");
            moveVector.z = player.GetAxis("MoveVertical");
        }

        private void ProcessInput() {
            if(moveVector.x != 0.0f || moveVector.z != 0.0f) {
                cc.Move(moveVector * moveSpeed * Time.deltaTime);
            }
        }

        private void Gravity()  {
            if(!cc.isGrounded)
            moveVector.y = -gravity;
            cc.Move(moveVector * moveSpeed * Time.deltaTime);
        }
    }
}