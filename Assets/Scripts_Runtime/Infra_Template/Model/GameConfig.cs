using System;
using UnityEngine;

namespace Ping {

    [CreateAssetMenu(fileName = "SO_GameConfig", menuName = "Ping/GameConfig")]
    public class GameConfig : ScriptableObject {

        // Field
        public Vector2Int fieldBoundMax;
        public Vector2Int fieldBoundMin;
        public Vector2Int player1PaddleSpawnPos;
        public Vector2Int player2PaddleSpawnPos;

        // Ball
        public float ballMoveSpeed;
        public float ballMoveSpeedMax;

        // Paddle
        public float paddleMoveSpeed;
        public float paddleMoveSpeedMax;

    }

}