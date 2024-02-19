using System;
using TriInspector;
using UnityEngine;

namespace Ping {

    [CreateAssetMenu(fileName = "SO_GameConfig", menuName = "Ping/GameConfig")]
    public class GameConfig : ScriptableObject {

        [Title("Field")]
        public Vector2 fieldBoundMax;
        public Vector2 fieldBoundMin;
        public Vector2 player1PaddleSpawnPos;
        public Vector2 player2PaddleSpawnPos;

        [Title("Ball")]
        public float ballMoveSpeed;
        public float ballMoveSpeedMax;
        public float ballRadius;
        public float ballSpawnAngleRange;

        [Title("Paddle")]
        public float paddleMoveSpeed;
        public float paddleMoveSpeedMax;
        public Vector2 paddleSize;

    }

}