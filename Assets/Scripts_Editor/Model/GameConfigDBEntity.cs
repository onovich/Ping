using MortiseFrame.LitIO;

namespace Ping.Editor {

    public struct GameConfigDBEntity {

        // Field
        public Vector2 fieldBoundMax;
        public Vector2 fieldBoundMin;
        public Vector2 player1PaddleSpawnPos;
        public Vector2 player2PaddleSpawnPos;

        // Ball
        public float ballMoveSpeed;
        public float ballMoveSpeedMax;
        public float ballRadius;
        public float ballSpawnAngleRange;

        // Paddle
        public float paddleMoveSpeed;
        public float paddleMoveSpeedMax;
        public Vector2 paddleSize;

        public void WriteTo(byte[] dst, ref int offset) {

            ByteWritter.Write<Vector2>(dst, fieldBoundMax, ref offset);
            ByteWritter.Write<Vector2>(dst, fieldBoundMin, ref offset);
            ByteWritter.Write<Vector2>(dst, player1PaddleSpawnPos, ref offset);
            ByteWritter.Write<Vector2>(dst, player2PaddleSpawnPos, ref offset);
            ByteWritter.Write<float>(dst, ballMoveSpeed, ref offset);
            ByteWritter.Write<float>(dst, ballMoveSpeedMax, ref offset);
            ByteWritter.Write<float>(dst, ballRadius, ref offset);
            ByteWritter.Write<float>(dst, ballSpawnAngleRange, ref offset);
            ByteWritter.Write<float>(dst, paddleMoveSpeed, ref offset);
            ByteWritter.Write<float>(dst, paddleMoveSpeedMax, ref offset);
            ByteWritter.Write<Vector2>(dst, paddleSize, ref offset);

        }

        public void FromBytes(byte[] src, ref int offset) {

            fieldBoundMax = ByteReader.Read<Vector2>(src, ref offset);
            fieldBoundMin = ByteReader.Read<Vector2>(src, ref offset);
            player1PaddleSpawnPos = ByteReader.Read<Vector2>(src, ref offset);
            player2PaddleSpawnPos = ByteReader.Read<Vector2>(src, ref offset);
            ballMoveSpeed = ByteReader.Read<float>(src, ref offset);
            ballMoveSpeedMax = ByteReader.Read<float>(src, ref offset);
            ballRadius = ByteReader.Read<float>(src, ref offset);
            ballSpawnAngleRange = ByteReader.Read<float>(src, ref offset);
            paddleMoveSpeed = ByteReader.Read<float>(src, ref offset);
            paddleMoveSpeedMax = ByteReader.Read<float>(src, ref offset);
            paddleSize = ByteReader.Read<Vector2>(src, ref offset);

        }

    }

}