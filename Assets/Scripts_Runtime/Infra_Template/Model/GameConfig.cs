using System;
using TriInspector;
using UnityEngine;

namespace Ping {

    [CreateAssetMenu(fileName = "SO_GameConfig", menuName = "Ping/GameConfig")]
    public class GameConfig : ScriptableObject {

        [Title("Field")]
        public Vector2 fieldBoundMax;
        public Vector2 fieldBoundMin;

        [Title("Wall")]
        public Vector2 wall0Start;
        public Vector2 wall0End;
        public Vector2 wall1Start;
        public Vector2 wall1End;

        [Title("Gate")]
        public Vector2 gate0Start;
        public Vector2 gate0End;
        public Vector2 gate1Start;
        public Vector2 gate1End;

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