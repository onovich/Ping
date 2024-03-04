#if UNITY_EDITOR
using UnityEngine;
using TriInspector;
using Ping.Editor;
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
            dbEntity.fieldBoundMax = new MortiseFrame.Abacus.Vector2(clientTM.fieldBoundMax.x, clientTM.fieldBoundMax.y);
            dbEntity.fieldBoundMin = new MortiseFrame.Abacus.Vector2(clientTM.fieldBoundMin.x, clientTM.fieldBoundMin.y);

            dbEntity.wall0Start = new MortiseFrame.Abacus.Vector2(clientTM.wall0Start.x, clientTM.wall0Start.y);
            dbEntity.wall0End = new MortiseFrame.Abacus.Vector2(clientTM.wall0End.x, clientTM.wall0End.y);
            dbEntity.wall1Start = new MortiseFrame.Abacus.Vector2(clientTM.wall1Start.x, clientTM.wall1Start.y);
            dbEntity.wall1End = new MortiseFrame.Abacus.Vector2(clientTM.wall1End.x, clientTM.wall1End.y);

            dbEntity.gate0Start = new MortiseFrame.Abacus.Vector2(clientTM.gate0Start.x, clientTM.gate0Start.y);
            dbEntity.gate0End = new MortiseFrame.Abacus.Vector2(clientTM.gate0End.x, clientTM.gate0End.y);
            dbEntity.gate1Start = new MortiseFrame.Abacus.Vector2(clientTM.gate1Start.x, clientTM.gate1Start.y);
            dbEntity.gate1End = new MortiseFrame.Abacus.Vector2(clientTM.gate1End.x, clientTM.gate1End.y);

            dbEntity.ballMoveSpeed = clientTM.ballMoveSpeed;
            dbEntity.ballMoveSpeedMax = clientTM.ballMoveSpeedMax;
            dbEntity.ballRadius = clientTM.ballRadius;
            dbEntity.ballSpawnAngleRange = clientTM.ballSpawnAngleRange;

            dbEntity.player0PaddleSpawnPos = new MortiseFrame.Abacus.Vector2(clientTM.player0PaddleSpawnPos.x, clientTM.player0PaddleSpawnPos.y);
            dbEntity.player1PaddleSpawnPos = new MortiseFrame.Abacus.Vector2(clientTM.player1PaddleSpawnPos.x, clientTM.player1PaddleSpawnPos.y);
            dbEntity.paddleMoveSpeed = clientTM.paddleMoveSpeed;
            dbEntity.paddleMoveSpeedMax = clientTM.paddleMoveSpeedMax;
            dbEntity.paddleSize = new MortiseFrame.Abacus.Vector2(clientTM.paddleSize.x, clientTM.paddleSize.y);

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
            clientTM.player0PaddleSpawnPos = new UnityEngine.Vector2(dbEntity.player0PaddleSpawnPos.x, dbEntity.player0PaddleSpawnPos.y);
            clientTM.player1PaddleSpawnPos = new UnityEngine.Vector2(dbEntity.player1PaddleSpawnPos.x, dbEntity.player1PaddleSpawnPos.y);
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