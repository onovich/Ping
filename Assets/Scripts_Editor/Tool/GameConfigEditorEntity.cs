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

            dbEntity.gate1Pos = new FVector2(clientTM.gate1Pos.x, clientTM.gate1Pos.y);
            dbEntity.gate1Size = new FVector2(clientTM.gate1Size.x, clientTM.gate1Size.y);
            dbEntity.gate2Pos = new FVector2(clientTM.gate2Pos.x, clientTM.gate2Pos.y);
            dbEntity.gate2Size = new FVector2(clientTM.gate2Size.x, clientTM.gate2Size.y);

            dbEntity.ballMoveSpeed = clientTM.ballMoveSpeed;
            dbEntity.ballMoveSpeedMax = clientTM.ballMoveSpeedMax;
            dbEntity.ballRadius = clientTM.ballRadius;
            dbEntity.ballSpawnAngleRange = clientTM.ballSpawnAngleRange;

            dbEntity.player1PaddleSpawnPos = new FVector2(clientTM.player1PaddleSpawnPos.x, clientTM.player1PaddleSpawnPos.y);
            dbEntity.player2PaddleSpawnPos = new FVector2(clientTM.player2PaddleSpawnPos.x, clientTM.player2PaddleSpawnPos.y);
            dbEntity.paddleMoveSpeed = clientTM.paddleMoveSpeed;
            dbEntity.paddleMoveSpeedMax = clientTM.paddleMoveSpeedMax;
            dbEntity.paddleSize = new FVector2(clientTM.paddleSize.x, clientTM.paddleSize.y);

            dbEntity.constraint1Pos = new FVector2(clientTM.constraint1Pos.x, clientTM.constraint1Pos.y);
            dbEntity.constraint1Size = new FVector2(clientTM.constraint1Size.x, clientTM.constraint1Size.y);
            dbEntity.constraint2Pos = new FVector2(clientTM.constraint2Pos.x, clientTM.constraint2Pos.y);
            dbEntity.constraint2Size = new FVector2(clientTM.constraint2Size.x, clientTM.constraint2Size.y);

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

            clientTM.gate1Pos = new UnityEngine.Vector2(dbEntity.gate1Pos.x, dbEntity.gate1Pos.y);
            clientTM.gate1Size = new UnityEngine.Vector2(dbEntity.gate1Size.x, dbEntity.gate1Size.y);
            clientTM.gate2Pos = new UnityEngine.Vector2(dbEntity.gate2Pos.x, dbEntity.gate2Pos.y);
            clientTM.gate2Size = new UnityEngine.Vector2(dbEntity.gate2Size.x, dbEntity.gate2Size.y);

            clientTM.ballMoveSpeed = dbEntity.ballMoveSpeed;
            clientTM.ballMoveSpeedMax = dbEntity.ballMoveSpeedMax;
            clientTM.ballRadius = dbEntity.ballRadius;
            clientTM.ballSpawnAngleRange = dbEntity.ballSpawnAngleRange;

            clientTM.player1PaddleSpawnPos = new UnityEngine.Vector2(dbEntity.player1PaddleSpawnPos.x, dbEntity.player1PaddleSpawnPos.y);
            clientTM.player2PaddleSpawnPos = new UnityEngine.Vector2(dbEntity.player2PaddleSpawnPos.x, dbEntity.player2PaddleSpawnPos.y);
            clientTM.paddleMoveSpeed = dbEntity.paddleMoveSpeed;
            clientTM.paddleMoveSpeedMax = dbEntity.paddleMoveSpeedMax;
            clientTM.paddleSize = new UnityEngine.Vector2(dbEntity.paddleSize.x, dbEntity.paddleSize.y);

            clientTM.constraint1Pos = new UnityEngine.Vector2(dbEntity.constraint1Pos.x, dbEntity.constraint1Pos.y);
            clientTM.constraint1Size = new UnityEngine.Vector2(dbEntity.constraint1Size.x, dbEntity.constraint1Size.y);
            clientTM.constraint2Pos = new UnityEngine.Vector2(dbEntity.constraint2Pos.x, dbEntity.constraint2Pos.y);
            clientTM.constraint2Size = new UnityEngine.Vector2(dbEntity.constraint2Size.x, dbEntity.constraint2Size.y);

            PLog.Log("GameConfig loaded");

        }

    }

}
#endif