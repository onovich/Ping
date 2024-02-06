using System;
using UnityEngine;

namespace Ping {

    public class BallEntity : MonoBehaviour {

        // Attr
        float moveSpeed;
        float moveSpeedMax;

        // FSM
        BallFSMComponent fsmCom;

        // Physics
        [SerializeField] Rigidbody2D rb;

        public void Ctor() {
            fsmCom = new BallFSMComponent();
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
        public Vector2 Move_GetVelocity() {
            return rb.velocity;
        }

        public void Move_ByDir(Vector2 dir, float dt) {
            Move_Apply(dir, Attr_GetMoveSpeed(), dt);
        }

        public void Move_Stop() {
            Move_Apply(Vector2.zero, 0, 0);
        }

        void Move_Apply(Vector2 dir, float moveSpeed, float fixdt) {
            rb.velocity = dir.normalized * moveSpeed;
        }

        // FSM
        public void FSM_EnterIdle() {
            fsmCom.EnterIdle();
        }

        public void FSM_EnterMoving() {
            fsmCom.EnterMoving();
        }

        public void FSM_EnterDead() {
            fsmCom.EnterDead();
        }

        public BallFSMStatus FSM_GetStatus() {
            return fsmCom.status;
        }

        public BallFSMComponent FSM_GetComponent() {
            return fsmCom;
        }

        public void TearDown() {
            Destroy(gameObject);
        }

    }

}