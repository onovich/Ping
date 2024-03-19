using UnityEngine;
using System.Collections.Generic;
using MortiseFrame.Rill;
using Ping.Requests;

namespace Ping.Business.Game {

    public class GameBusinessContext {

        // Entity
        public GameEntity gameEntity;
        public InputEntity inputEntity;

        public FieldEntity fieldEntity;
        public BallEntity ballEntity;
        SortedList<int, PaddleEntity> playerPaddles;

        // TEMP
        public Collider2D[] overlapTemp;
        public RaycastHit2D[] raycastTemp;

        // UI
        public UIAppContext uiAppContext;

        // Camera
        public Camera mainCamera;

        // Infra
        public TemplateInfraContext templateInfraContext;
        public AssetsInfraContext assetsInfraContext;

        // Main
        public MainContext mainContext;

        // Request
        public RequestInfraContext reqInfraContext;

        public GameBusinessContext() {
            gameEntity = new GameEntity();
            overlapTemp = new Collider2D[1000];
            raycastTemp = new RaycastHit2D[1000];
            playerPaddles = new SortedList<int, PaddleEntity>(2);
        }

        public void Clear() {
            fieldEntity = null;
            ballEntity = null;
            playerPaddles.Clear();
        }

        // Player
        public PlayerEntity Player_Get(int index) {
            return mainContext.Player_Get(index);
        }

        public PlayerEntity Player_GetOwner() {
            return mainContext.Player_Get(mainContext.ownerIndex);
        }

        public int Player_GetOwnerIndex() {
            return mainContext.ownerIndex;
        }

        // Ball
        public void Ball_Set(BallEntity ballEntity) {
            this.ballEntity = ballEntity;
        }

        public BallEntity Ball_Get() {
            return ballEntity;
        }

        // Paddle
        public void Paddle_Set(PaddleEntity paddleEntity) {
            playerPaddles[paddleEntity.GetPlayerIndex()] = paddleEntity;
        }

        public void Paddle_Clear(PaddleEntity paddleEntity) {
            playerPaddles.Remove(paddleEntity.GetPlayerIndex());
        }

        public PaddleEntity Paddle_Get(int playerIndex) {
            var has = playerPaddles.ContainsKey(playerIndex);
            if (!has) {
                PLog.LogError("PaddleEntity is null, index = " + playerIndex);
            }
            var paddleEntity = playerPaddles[playerIndex];
            return paddleEntity;
        }

        public PaddleEntity Paddle_GetLocalOwner() {
            var ownerID = gameEntity.GetLocalOwnerPlayerIndex();
            return Paddle_Get(ownerID);
        }

        // Field
        public void Field_Set(FieldEntity fieldEntity) {
            this.fieldEntity = fieldEntity;
        }

        public FieldEntity Field_Get() {
            return fieldEntity;
        }

    }

}