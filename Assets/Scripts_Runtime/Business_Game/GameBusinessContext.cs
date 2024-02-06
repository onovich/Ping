using UnityEngine;

namespace Ping.Business.Game {

    public class GameBusinessContext {

        // Entity
        public GameEntity gameEntity;

        public InputEntity inputEntity;

        public FieldEntity fieldEntity;
        public BallEntity ballEntity;
        public PaddleEntity player1PaddleEntity;
        public PaddleEntity player2PaddleEntity;

        // UI
        public UIAppContext uiAppContext;

        // Camera
        public Camera mainCamera;

        // Service
        public IDRecordService idRecordService;

        // Infra
        public TemplateInfraContext templateInfraContext;
        public AssetsInfraContext assetsInfraContext;

        public GameBusinessContext() {
            gameEntity = new GameEntity();
            idRecordService = new IDRecordService();
        }

        public void Reset() {
            fieldEntity = null;
            ballEntity = null;
            player1PaddleEntity = null;
            player2PaddleEntity = null;
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
            if (paddleEntity.playerID == 1) {
                player1PaddleEntity = paddleEntity;
            } else {
                player2PaddleEntity = paddleEntity;
            }
        }

        public PaddleEntity Paddle_Get(int playerID) {
            if (playerID == 1) {
                return player1PaddleEntity;
            } else {
                return player2PaddleEntity;
            }
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