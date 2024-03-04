using System;
using UnityEngine;

namespace Ping {

    public class PaddleEntity : MonoBehaviour {

        // Base Info
        int playerIndex;

        // FSM
        PaddleFSMComponent fsmCom;

        // Input
        PaddleInputComponent inputCom;

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

        public Vector2 Input_GetMoveAxis() {
            return inputCom.moveAxis;
        }

        // Sync
        public void Sync_RecordSyncTargetPos(Vector2 pos) {
            syncTargetPos = pos;
        }

        public void Sync_Move() {
            Pos_SetPos(syncTargetPos);
        }

    }

}