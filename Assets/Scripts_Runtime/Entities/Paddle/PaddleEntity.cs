using System;
using UnityEngine;

namespace Ping {

    public class PaddleEntity : MonoBehaviour {

        // Base Info
        int playerIndex;

        // Attr
        float moveSpeed;
        float moveSpeedMax;
        Vector2 size;

        // FSM
        PaddleFSMComponent fsmCom;

        // Input
        PaddleInputComponent inputCom;

        // Physics
        [SerializeField] Rigidbody2D rb;

        // Sync
        Vector2 syncTargetPos;

        public void Ctor() {
            inputCom = new PaddleInputComponent();
            fsmCom = new PaddleFSMComponent();
        }

        // Base Info
        public void SetPlayerIndex(int id) {
            playerIndex = id;
        }

        public int GetPlayerIndex() {
            return playerIndex;
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

        public void Attr_SetSize(Vector2 size) {
            this.size = size;
        }

        // Move
        public void Move_Sync() {
            Pos_SetPos(syncTargetPos);
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

        // Sync
        public void Sync_RecordSyncTargetPos(Vector2 pos) {
            syncTargetPos = pos;
        }

    }

}