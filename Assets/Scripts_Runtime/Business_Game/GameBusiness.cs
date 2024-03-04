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
            LocalInput(ctx, dt);
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

        static void LocalInput(GameBusinessContext ctx, float dt) {
            GameInputDomain.Player_BakeInput(ctx, dt);

            var game = ctx.gameEntity;
            var status = game.FSM_GetStatus();
            if (status == GameFSMStatus.Gaming) {
                GameInputDomain.Owner_BakeInput(ctx, ctx.Paddle_GetLocalOwner());
            }
        }

        static void LogicTick(GameBusinessContext ctx, float dt) {

        }

        public static void FixedTick(GameBusinessContext ctx, float dt) {

            var game = ctx.gameEntity;
            var status = game.GetStatus();
            if (status != GameFSMStatus.Gaming) { return; }

            // Ball
            var ball = ctx.Ball_Get();
            if (ball == null) { return; }
            GameBallFSMController.FixedTickFSM(ctx, ball, dt);

            // Paddle
            var paddle1 = ctx.Paddle_Get(1);
            if (paddle1 == null) { return; }
            GamePaddleFSMController.FixedTickFSM(ctx, paddle1, dt);

            var paddle2 = ctx.Paddle_Get(2);
            if (paddle2 == null) { return; }
            GamePaddleFSMController.FixedTickFSM(ctx, paddle2, dt);

            Physics2D.Simulate(dt);

        }

        static void RenderTick(GameBusinessContext ctx, float dt) {
            var game = ctx.gameEntity;
            var status = game.GetStatus();
            if (status != GameFSMStatus.Gaming) { return; }

            // Time
            GameTimeDomain.ApplyGameTime(ctx, dt);

        }

        public static void OnNetResEntitiesSync(GameBusinessContext ctx, EntitiesSyncBroadMessage msg) {
            var paddle1Pos = msg.paddle1Pos;
            var paddle2Pos = msg.paddle2Pos;
            var ballPos = msg.ballPos;

            var paddle1 = ctx.Paddle_Get(0);
            var paddle2 = ctx.Paddle_Get(1);
            var ball = ctx.Ball_Get();

            GamePaddleDomain.RecordSyncTargetPos(ctx, paddle1, paddle1Pos);
            GamePaddleDomain.RecordSyncTargetPos(ctx, paddle2, paddle2Pos);
            GameBallDomain.RecordSyncTargetPos(ctx, ball, ballPos);

            var player = ctx.Player_GetOwner();

        }

        public static void TearDown(GameBusinessContext ctx) {
            ExitGame(ctx);
        }

    }

}