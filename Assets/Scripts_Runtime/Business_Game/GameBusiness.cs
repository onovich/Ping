using UnityEngine;
using Ping.Requests;
using Ping.Protocol;

namespace Ping.Business.Game {

    public static class GameBusiness {

        static float restTime;

        public static void Init(GameBusinessContext ctx) {

        }

        public static void StartGame(GameBusinessContext ctx) {
            GameGameDomain.NewGame(ctx);
        }

        public static void ExitGame(GameBusinessContext ctx) {
            GameGameDomain.ExitGame(ctx);
        }

        public static void Tick(GameBusinessContext ctx, float dt) {

            ResetInput(ctx);
            BakeLocalInput(ctx, dt);
            SendInputToServer(ctx);
            LogicTick(ctx, dt);

            restTime += dt;
            const float intervalTime = 0.01f;
            if (restTime <= intervalTime) {
                FixedTick(ctx, restTime);
                restTime = 0;
            } else {
                while (restTime >= intervalTime) {
                    FixedTick(ctx, intervalTime);
                    restTime -= intervalTime;
                }
            }

            RenderTick(ctx, dt);

        }

        static void ResetInput(GameBusinessContext ctx) {
            var inputEntity = ctx.inputEntity;
            inputEntity.Reset();
        }

        static void SendInputToServer(GameBusinessContext ctx) {
            var game = ctx.gameEntity;
            var fsm = game.FSM_GetComponent();
            var status = fsm.Status;
            if (status != GameFSMStatus.Gaming) { return; }

            GameInputDomain.Owner_ApplySendInput(ctx);
        }

        static void BakeLocalInput(GameBusinessContext ctx, float dt) {
            var game = ctx.gameEntity;
            var fsm = game.FSM_GetComponent();
            var status = fsm.Status;
            if (status != GameFSMStatus.Gaming) { return; }

            GameInputDomain.Player_BakeInput(ctx, dt);
            var owner = ctx.Paddle_GetLocalOwner();
            if (owner == null) { return; }
            GameInputDomain.Owner_BakeInput(ctx, owner);
        }

        static void LogicTick(GameBusinessContext ctx, float dt) {

            var game = ctx.gameEntity;
            var fsm = game.FSM_GetComponent();
            var status = fsm.Status;
            if (status != GameFSMStatus.Result) { return; }

            if (fsm.result_isEntering) {
                // fsm.Gaming_Enter();
                return;
            }

        }

        public static void FixedTick(GameBusinessContext ctx, float dt) {

            var game = ctx.gameEntity;
            var fsm = game.FSM_GetComponent();
            var status = fsm.Status;
            if (status != GameFSMStatus.Gaming) { return; }

            // Ball
            var ball = ctx.Ball_Get();
            if (ball == null) { return; }
            GameBallDomain.ApplySyncMove(ctx, ball);

            // Paddle
            var paddle0 = ctx.Paddle_Get(0);
            if (paddle0 == null) { return; }
            GamePaddleDomain.ApplySyncMove(ctx, paddle0);

            var paddle1 = ctx.Paddle_Get(1);
            if (paddle1 == null) { return; }
            GamePaddleDomain.ApplySyncMove(ctx, paddle1);

            Physics2D.Simulate(dt);

        }

        static void RenderTick(GameBusinessContext ctx, float dt) {
            var game = ctx.gameEntity;
            var fsm = game.FSM_GetComponent();
            var status = fsm.Status;
            if (status != GameFSMStatus.Result) { return; }

            if (fsm.result_isEntering) {
                fsm.result_isEntering = false;
                var winnerPlayerIndex = fsm.result_winnerPlayerIndex;

                var ball = ctx.Ball_Get();
                GameBallDomain.ResetBall(ctx, ball);

                var score0 = ctx.Player_Get(0).Score_Get();
                var score1 = ctx.Player_Get(1).Score_Get();
                UIApp.Score_SetPlayerScore(ctx.uiAppContext, score0, 0);
                UIApp.Score_SetPlayerScore(ctx.uiAppContext, score1, 1);

                fsm.Gaming_Enter();
                return;
            }

        }

        public static void OnNetResEntitiesSync(GameBusinessContext ctx, EntitiesSyncBroadMessage msg) {
            var paddle0Pos = msg.paddle0Pos;
            var paddle1Pos = msg.paddle1Pos;
            var ballPos = msg.ballPos;

            var paddle0 = ctx.Paddle_Get(0);
            var paddle1 = ctx.Paddle_Get(1);
            var ball = ctx.Ball_Get();

            GamePaddleDomain.RecordSyncTargetPos(ctx, paddle0, paddle0Pos);
            GamePaddleDomain.RecordSyncTargetPos(ctx, paddle1, paddle1Pos);
            GameBallDomain.RecordSyncTargetPos(ctx, ball, ballPos);

        }

        public static void OnNetResGameResult(GameBusinessContext ctx, GameResultBroadMessage msg) {
            var winnerPlayerIndex = msg.winnerPlayerIndex;
            var gameTurn = msg.gameTurn;
            var score0 = msg.score0;
            var score1 = msg.score1;

            var ball = ctx.Ball_Get();

            GameGameDomain.Win(ctx, gameTurn, winnerPlayerIndex, score0, score1);
        }

        public static void TearDown(GameBusinessContext ctx) {
            ExitGame(ctx);
        }

    }

}