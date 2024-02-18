using System;
using UnityEngine;

namespace Ping {

    [CreateAssetMenu(fileName = "SO_GameConfig", menuName = "Ping/GameConfig")]
    public class GameConfig : ScriptableObject {

        // Field
        public Vector2 fieldBoundMax;
        public Vector2 fieldBoundMin;
        public Vector2 player1PaddleSpawnPos;
        public Vector2 player2PaddleSpawnPos;

        // Ball
        public float ballMoveSpeed;
        public float ballMoveSpeedMax;
        public float ballRadius;

        // Paddle
        public float paddleMoveSpeed;
        public float paddleMoveSpeedMax;
        public Vector2 paddleSize;

    }

}