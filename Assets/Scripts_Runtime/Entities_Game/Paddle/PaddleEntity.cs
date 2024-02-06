using System;
using UnityEngine;

namespace Ping {

    public class PaddleEntity : MonoBehaviour {

        // Base Info
        int playerID;

        // Attr
        float moveSpeed;
        float moveSpeedMax;

        // FSM
        PaddleFSMComponent fsmCom;

        // Score
        int score;

        // Input
        PaddleInputComponent inputCom;

        // Physics
        [SerializeField] Rigidbody2D rb;

        public void Ctor() {
            inputCom = new PaddleInputComponent();
            fsmCom = new PaddleFSMComponent();
        }

        // Base Info
        public void SetPlayerID(int id) {
            playerID = id;
        }

        public int GetPlayerID() {
            return playerID;
        }

        // Pos
        public void Pos_SetPos(Vector2 pos) {
            transform.position = pos;
        }

        public Vector2 Pos_GetPos() {
            return transform.position;
        }

        public Vector2 Pos_GetVolecity() {
            return rb.velocity;
        }

        // Attr
        public float Attr_GetMoveSpeed() {
            return Mathf.Clamp(moveSpeed, 0, moveSpeedMax);
        }

        public void Attr_SetMoveSpeed(float speed) {
            moveSpeed = speed;
        }

        public float Attr_GetMoveSpeedMax() {
            return moveSpeedMax;
        }

        public void Attr_SetMoveSpeedMax(float speed) {
            moveSpeedMax = speed;
        }

        // Move
        public void Move_Move(float dt) {
            Move_Apply(inputCom.moveAxis.normalized, Attr_GetMoveSpeed(), dt);
        }

        public Vector2 Move_GetVelocity() {
            return rb.velocity;
        }

        public void Move_Stop() {
            Move_Apply(Vector2.zero, 0, 0);
        }

        void Move_Apply(Vector2 dir, float moveSpeed, float fixdt) {
            rb.velocity = dir.normalized * moveSpeed;
        }

        // FSM
        public void FSM_EnterMoving() {
            fsmCom.Moving_Enter();
        }

        public PaddleFSMStatus FSM_GetStatus() {
            return fsmCom.status;
        }

        public PaddleFSMComponent FSM_GetComponent() {
            return fsmCom;
        }

        public void TearDown() {
            Destroy(gameObject);
        }

        // Input
        public void Input_SetMoveAxis(Vector2 axis) {
            inputCom.moveAxis = axis;
        }

    }

}