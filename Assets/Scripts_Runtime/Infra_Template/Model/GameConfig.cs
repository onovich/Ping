using System;
using TriInspector;
using UnityEngine;

namespace Ping {

    [CreateAssetMenu(fileName = "SO_GameConfig", menuName = "Ping/GameConfig")]
    public class GameConfig : ScriptableObject {

        [Title("Field")]
        public Vector2 fieldPos;
        public Vector2 fieldSize;

        [Title("Wall")]
        public Vector2 wall0Pos;
        public Vector2 wall0Size;
        public Vector2 wall1Pos;
        public Vector2 wall1Size;

        [Title("Gate")]
        public Vector2 gate0Pos;
        public Vector2 gate0Size;
        public Vector2 gate1Pos;
        public Vector2 gate1Size;

        [Title("Ball")]
        public float ballMoveSpeed;
        public float ballMoveSpeedMax;
        public float ballRadius;
        public float ballSpawnAngleRange;

        [Title("Paddle")]
        public Vector2 player0PaddleSpawnPos;
        public Vector2 player1PaddleSpawnPos;
        public float paddleMoveSpeed;
        public float paddleMoveSpeedMax;
        public Vector2 paddleSize;

    }

}