using System;
using TriInspector;
using UnityEngine;

namespace Ping {

    [CreateAssetMenu(fileName = "SO_GameConfig", menuName = "Ping/GameConfig")]
    public class GameConfig : ScriptableObject {

        [Title("Wall")]
        public Vector2 wall0Pos;
        public Vector2 wall0Size;
        public Vector2 wall1Pos;
        public Vector2 wall1Size;

        [Title("Gate")]
        public Vector2 gate1Pos;
        public Vector2 gate1Size;
        public Vector2 gate2Pos;
        public Vector2 gate2Size;

        [Title("Ball")]
        public float ballMoveSpeed;
        public float ballMoveSpeedMax;
        public float ballRadius;
        public float ballSpawnAngleRange;

        [Title("Paddle")]
        public Vector2 player1PaddleSpawnPos;
        public Vector2 player2PaddleSpawnPos;
        public float paddleMoveSpeed;
        public float paddleMoveSpeedMax;
        public Vector2 paddleSize;

        [Title("Constraint")]
        public Vector2 constraint1Pos;
        public Vector2 constraint1Size;
        public Vector2 constraint2Pos;
        public Vector2 constraint2Size;

    }

}