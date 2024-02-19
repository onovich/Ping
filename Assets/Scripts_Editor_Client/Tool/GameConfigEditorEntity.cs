#if UNITY_EDITOR
using UnityEngine;
using TriInspector;
using Ping.Server;
using UnityEditor;

namespace Ping.Modifier {

    public class GameConfigEditorEntity : MonoBehaviour {

        [SerializeField] GameConfig clientTM;

        const long len = 1024;
        byte[] buffer = new byte[len];

        [Button("Save")]
        public void Save() {

            SaveDB();

        }

        public void SaveDB() {

            var dbEntity = new GameConfigDBEntity();
            dbEntity.fieldBoundMax = new Ping.Server.Vector2(clientTM.fieldBoundMax.x, clientTM.fieldBoundMax.y);
            dbEntity.fieldBoundMin = new Ping.Server.Vector2(clientTM.fieldBoundMin.x, clientTM.fieldBoundMin.y);
            dbEntity.player1PaddleSpawnPos = new Ping.Server.Vector2(clientTM.player1PaddleSpawnPos.x, clientTM.player1PaddleSpawnPos.y);
            dbEntity.player2PaddleSpawnPos = new Ping.Server.Vector2(clientTM.player2PaddleSpawnPos.x, clientTM.player2PaddleSpawnPos.y);
            dbEntity.ballMoveSpeed = clientTM.ballMoveSpeed;
            dbEntity.ballMoveSpeedMax = clientTM.ballMoveSpeedMax;
            dbEntity.ballRadius = clientTM.ballRadius;
            dbEntity.ballSpawnAngleRange = clientTM.ballSpawnAngleRange;
            dbEntity.paddleMoveSpeed = clientTM.paddleMoveSpeed;
            dbEntity.paddleMoveSpeedMax = clientTM.paddleMoveSpeedMax;
            dbEntity.paddleSize = new Ping.Server.Vector2(clientTM.paddleSize.x, clientTM.paddleSize.y);

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

            clientTM.fieldBoundMax = new UnityEngine.Vector2(dbEntity.fieldBoundMax.x, dbEntity.fieldBoundMax.y);
            clientTM.fieldBoundMin = new UnityEngine.Vector2(dbEntity.fieldBoundMin.x, dbEntity.fieldBoundMin.y);
            clientTM.player1PaddleSpawnPos = new UnityEngine.Vector2(dbEntity.player1PaddleSpawnPos.x, dbEntity.player1PaddleSpawnPos.y);
            clientTM.player2PaddleSpawnPos = new UnityEngine.Vector2(dbEntity.player2PaddleSpawnPos.x, dbEntity.player2PaddleSpawnPos.y);
            clientTM.ballMoveSpeed = dbEntity.ballMoveSpeed;
            clientTM.ballMoveSpeedMax = dbEntity.ballMoveSpeedMax;
            clientTM.ballRadius = dbEntity.ballRadius;
            clientTM.ballSpawnAngleRange = dbEntity.ballSpawnAngleRange;
            clientTM.paddleMoveSpeed = dbEntity.paddleMoveSpeed;
            clientTM.paddleMoveSpeedMax = dbEntity.paddleMoveSpeedMax;
            clientTM.paddleSize = new UnityEngine.Vector2(dbEntity.paddleSize.x, dbEntity.paddleSize.y);

            PLog.Log("GameConfig loaded");

        }

    }

}
#endif