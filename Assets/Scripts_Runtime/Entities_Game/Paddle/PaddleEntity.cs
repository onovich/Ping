using System;
using UnityEngine;

namespace Ping {

    public class PaddleEntity : MonoBehaviour {

        // Base Info
        public int playerID;

        // Attr
        public float moveSpeed;
        public float moveSpeedMax;

        // Score
        public int score;

        // Input
        public PaddleInputComponent inputCom;

        // Physics
        [SerializeField] Rigidbody2D rb;

        public void Ctor() {
            inputCom = new PaddleInputComponent();
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
        public void Move_Move(float dt) {
            Move_Apply(inputCom.moveAxis.normalized, Attr_GetMoveSpeed(), dt);
        }

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