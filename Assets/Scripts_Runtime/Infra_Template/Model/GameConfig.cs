using System;
using UnityEngine;

namespace Ping {

    [CreateAssetMenu(fileName = "SO_GameConfig", menuName = "Ping/GameConfig")]
    public class GameConfig : ScriptableObject {

        // Field
        public Vector2Int max;
        public Vector2Int min;
        public Vector2Int player1PaddleSpawnPos;
        public Vector2Int player2PaddleSpawnPos;

        // Ball
        public float ballMoveSpeed;

        // Paddle
        public float paddleMoveSpeed;

    }

}