using System;
using UnityEngine;

namespace Ping {

    public class BallEntity : MonoBehaviour {

        // Attr
        float moveSpeed;
        float moveSpeedMax;
        float radius;

        // Sync
        Vector2 syncTargetPos;

        // FSM
        BallFSMComponent fsmCom;

        // Trail
        [SerializeField] TrailRenderer trail;

        public void Ctor() {
            fsmCom = new BallFSMComponent();
        }

        // Trail
        public void Reset() {
            trail.Clear();
            transform.position = Vector2.zero;
            trail.Clear();
        }

        // Pos
        public void Pos_SetPos(Vector2 pos) {
            transform.position = pos;
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

        public void Attr_SetRadius(float radius) {
            this.radius = radius;
        }

        public float Attr_GetRadius() {
            return radius;
        }

        // Move

        public void Move_Sync() {
            Pos_SetPos(syncTargetPos);
        }

        public void Reset_Sync() {
            syncTargetPos = Vector2.zero;
            PLog.Log("BallEntity.Reset_Sync");
        }

        // FSM
        public BallFSMStatus FSM_GetStatus() {
            return fsmCom.status;
        }

        public BallFSMComponent FSM_GetComponent() {
            return fsmCom;
        }

        // Sync
        public void Sync_RecordSyncTargetPos(Vector2 pos) {
            syncTargetPos = pos;
        }

        public void TearDown() {
            Destroy(gameObject);
        }

    }

}