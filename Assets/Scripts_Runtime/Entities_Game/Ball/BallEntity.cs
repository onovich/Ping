using System;
using UnityEngine;

namespace Ping {

    public class BallEntity : MonoBehaviour {

        // Base Info
        public int playerID;

        // Attr
        public float moveSpeed;

        // FSM
        public BallFSMComponent fsmCom;

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
            return moveSpeed;
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

        public void TearDown() {
            Destroy(gameObject);
        }

    }

}