using MortiseFrame.LitIO;
using MortiseFrame.Abacus;

namespace Ping.Editor {

    public struct GameConfigDBEntity {

        // Wall
        public FVector2 wall0Pos;
        public FVector2 wall0Size;
        public FVector2 wall1Pos;
        public FVector2 wall1Size;

        // Gate
        public FVector2 gate1Pos;
        public FVector2 gate1Size;
        public FVector2 gate2Pos;
        public FVector2 gate2Size;

        // Ball
        public float ballMoveSpeed;
        public float ballMoveSpeedMax;
        public float ballRadius;
        public float ballSpawnAngleRange;

        // Paddle
        public FVector2 player1PaddleSpawnPos;
        public FVector2 player2PaddleSpawnPos;
        public float paddleMoveSpeed;
        public float paddleMoveSpeedMax;
        public FVector2 paddleSize;

        // Constraint
        public FVector2 constraint1Pos;
        public FVector2 constraint1Size;
        public FVector2 constraint2Pos;
        public FVector2 constraint2Size;

        public void WriteTo(byte[] dst, ref int offset) {

            ByteWriter.Write<FVector2>(dst, wall0Pos, ref offset);
            ByteWriter.Write<FVector2>(dst, wall0Size, ref offset);
            ByteWriter.Write<FVector2>(dst, wall1Pos, ref offset);
            ByteWriter.Write<FVector2>(dst, wall1Size, ref offset);

            ByteWriter.Write<FVector2>(dst, gate1Pos, ref offset);
            ByteWriter.Write<FVector2>(dst, gate1Size, ref offset);
            ByteWriter.Write<FVector2>(dst, gate2Pos, ref offset);
            ByteWriter.Write<FVector2>(dst, gate2Size, ref offset);

            ByteWriter.Write<float>(dst, ballMoveSpeed, ref offset);
            ByteWriter.Write<float>(dst, ballMoveSpeedMax, ref offset);
            ByteWriter.Write<float>(dst, ballRadius, ref offset);
            ByteWriter.Write<float>(dst, ballSpawnAngleRange, ref offset);

            ByteWriter.Write<FVector2>(dst, player1PaddleSpawnPos, ref offset);
            ByteWriter.Write<FVector2>(dst, player2PaddleSpawnPos, ref offset);
            ByteWriter.Write<float>(dst, paddleMoveSpeed, ref offset);
            ByteWriter.Write<float>(dst, paddleMoveSpeedMax, ref offset);
            ByteWriter.Write<FVector2>(dst, paddleSize, ref offset);

            ByteWriter.Write<FVector2>(dst, constraint1Pos, ref offset);
            ByteWriter.Write<FVector2>(dst, constraint1Size, ref offset);
            ByteWriter.Write<FVector2>(dst, constraint2Pos, ref offset);
            ByteWriter.Write<FVector2>(dst, constraint2Size, ref offset);

        }

        public void FromBytes(byte[] src, ref int offset) {

            wall0Pos = ByteReader.Read<FVector2>(src, ref offset);
            wall0Size = ByteReader.Read<FVector2>(src, ref offset);
            wall1Pos = ByteReader.Read<FVector2>(src, ref offset);
            wall1Size = ByteReader.Read<FVector2>(src, ref offset);

            gate1Pos = ByteReader.Read<FVector2>(src, ref offset);
            gate1Size = ByteReader.Read<FVector2>(src, ref offset);
            gate2Pos = ByteReader.Read<FVector2>(src, ref offset);
            gate2Size = ByteReader.Read<FVector2>(src, ref offset);

            ballMoveSpeed = ByteReader.Read<float>(src, ref offset);
            ballMoveSpeedMax = ByteReader.Read<float>(src, ref offset);
            ballRadius = ByteReader.Read<float>(src, ref offset);
            ballSpawnAngleRange = ByteReader.Read<float>(src, ref offset);

            player1PaddleSpawnPos = ByteReader.Read<FVector2>(src, ref offset);
            player2PaddleSpawnPos = ByteReader.Read<FVector2>(src, ref offset);
            paddleMoveSpeed = ByteReader.Read<float>(src, ref offset);
            paddleMoveSpeedMax = ByteReader.Read<float>(src, ref offset);
            paddleSize = ByteReader.Read<FVector2>(src, ref offset);

            constraint1Pos = ByteReader.Read<FVector2>(src, ref offset);
            constraint1Size = ByteReader.Read<FVector2>(src, ref offset);
            constraint2Pos = ByteReader.Read<FVector2>(src, ref offset);
            constraint2Size = ByteReader.Read<FVector2>(src, ref offset);

        }

    }

}