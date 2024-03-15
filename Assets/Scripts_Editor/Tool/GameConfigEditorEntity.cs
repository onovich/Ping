#if UNITY_EDITOR
using UnityEngine;
using TriInspector;
using Ping.Editor;
using UnityEditor;
using MortiseFrame.Abacus;

namespace Ping.Modifier {

    public class GameConfigEditorEntity : MonoBehaviour {

        [SerializeField] GameConfig clientTM;

        const long len = 2048;
        byte[] buffer = new byte[len];

        [Button("Save")]
        public void Save() {

            SaveDB();

        }

        public void SaveDB() {

            var dbEntity = new GameConfigDBEntity();

            dbEntity.wall0Pos = new FVector2(clientTM.wall0Pos.x, clientTM.wall0Pos.y);
            dbEntity.wall0Size = new FVector2(clientTM.wall0Size.x, clientTM.wall0Size.y);
            dbEntity.wall1Pos = new FVector2(clientTM.wall1Pos.x, clientTM.wall1Pos.y);
            dbEntity.wall1Size = new FVector2(clientTM.wall1Size.x, clientTM.wall1Size.y);

            dbEntity.gate0Pos = new FVector2(clientTM.gate0Pos.x, clientTM.gate0Pos.y);
            dbEntity.gate0Size = new FVector2(clientTM.gate0Size.x, clientTM.gate0Size.y);
            dbEntity.gate1Pos = new FVector2(clientTM.gate1Pos.x, clientTM.gate1Pos.y);
            dbEntity.gate1Size = new FVector2(clientTM.gate1Size.x, clientTM.gate1Size.y);

            dbEntity.ballMoveSpeed = clientTM.ballMoveSpeed;
            dbEntity.ballMoveSpeedMax = clientTM.ballMoveSpeedMax;
            dbEntity.ballRadius = clientTM.ballRadius;
            dbEntity.ballSpawnAngleRange = clientTM.ballSpawnAngleRange;

            dbEntity.player0PaddleSpawnPos = new FVector2(clientTM.player0PaddleSpawnPos.x, clientTM.player0PaddleSpawnPos.y);
            dbEntity.player1PaddleSpawnPos = new FVector2(clientTM.player1PaddleSpawnPos.x, clientTM.player1PaddleSpawnPos.y);
            dbEntity.paddleMoveSpeed = clientTM.paddleMoveSpeed;
            dbEntity.paddleMoveSpeedMax = clientTM.paddleMoveSpeedMax;
            dbEntity.paddleSize = new FVector2(clientTM.paddleSize.x, clientTM.paddleSize.y);

            dbEntity.constraint0Pos = new FVector2(clientTM.constraint0Pos.x, clientTM.constraint0Pos.y);
            dbEntity.constraint0Size = new FVector2(clientTM.constraint0Size.x, clientTM.constraint0Size.y);
            dbEntity.constraint1Pos = new FVector2(clientTM.constraint1Pos.x, clientTM.constraint1Pos.y);
            dbEntity.constraint1Size = new FVector2(clientTM.constraint1Size.x, clientTM.constraint1Size.y);

            int offset = 0;
            dbEntity.WriteTo(buffer, ref offset);
            FileHelper.SaveBytes("GameConfig.bytes", buffer, offset);

        }

        [Button("Load")]
        public void Load() {

            LoadDB();
            UnityEditor.EditorUtility.SetDirty(clientTM);
            AssetDatabase.SaveAssets();

        }

        public void LoadDB() {

            if (FileHelper.Exists("GameConfig.bytes")) {
                FileHelper.LoadBytes("GameConfig.bytes", buffer);
            } else {
                PLog.LogError("GameConfig.bytes not found");
            }

            GameConfigDBEntity dbEntity = new GameConfigDBEntity();
            int offset = 0;
            dbEntity.FromBytes(buffer, ref offset);

            clientTM.wall0Pos = new UnityEngine.Vector2(dbEntity.wall0Pos.x, dbEntity.wall0Pos.y);
            clientTM.wall0Size = new UnityEngine.Vector2(dbEntity.wall0Size.x, dbEntity.wall0Size.y);
            clientTM.wall1Pos = new UnityEngine.Vector2(dbEntity.wall1Pos.x, dbEntity.wall1Pos.y);
            clientTM.wall1Size = new UnityEngine.Vector2(dbEntity.wall1Size.x, dbEntity.wall1Size.y);

            clientTM.gate0Pos = new UnityEngine.Vector2(dbEntity.gate0Pos.x, dbEntity.gate0Pos.y);
            clientTM.gate0Size = new UnityEngine.Vector2(dbEntity.gate0Size.x, dbEntity.gate0Size.y);
            clientTM.gate1Pos = new UnityEngine.Vector2(dbEntity.gate1Pos.x, dbEntity.gate1Pos.y);
            clientTM.gate1Size = new UnityEngine.Vector2(dbEntity.gate1Size.x, dbEntity.gate1Size.y);

            clientTM.ballMoveSpeed = dbEntity.ballMoveSpeed;
            clientTM.ballMoveSpeedMax = dbEntity.ballMoveSpeedMax;
            clientTM.ballRadius = dbEntity.ballRadius;
            clientTM.ballSpawnAngleRange = dbEntity.ballSpawnAngleRange;

            clientTM.player0PaddleSpawnPos = new UnityEngine.Vector2(dbEntity.player0PaddleSpawnPos.x, dbEntity.player0PaddleSpawnPos.y);
            clientTM.player1PaddleSpawnPos = new UnityEngine.Vector2(dbEntity.player1PaddleSpawnPos.x, dbEntity.player1PaddleSpawnPos.y);
            clientTM.paddleMoveSpeed = dbEntity.paddleMoveSpeed;
            clientTM.paddleMoveSpeedMax = dbEntity.paddleMoveSpeedMax;
            clientTM.paddleSize = new UnityEngine.Vector2(dbEntity.paddleSize.x, dbEntity.paddleSize.y);

            clientTM.constraint0Pos = new UnityEngine.Vector2(dbEntity.constraint0Pos.x, dbEntity.constraint0Pos.y);
            clientTM.constraint0Size = new UnityEngine.Vector2(dbEntity.constraint0Size.x, dbEntity.constraint0Size.y);
            clientTM.constraint1Pos = new UnityEngine.Vector2(dbEntity.constraint1Pos.x, dbEntity.constraint1Pos.y);
            clientTM.constraint1Size = new UnityEngine.Vector2(dbEntity.constraint1Size.x, dbEntity.constraint1Size.y);

            PLog.Log("GameConfig loaded");

        }

    }

}
#endif