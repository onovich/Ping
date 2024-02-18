using UnityEngine;

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
            ProcessInput(ctx, dt);
            PreTick(ctx, dt);

            // restTime += dt;
            // const float intervalTime = 0.01f;
            // if (restTime <= intervalTime) {
            //     FixedTick(ctx, restTime);
            //     restTime = 0;
            // } else {
            //     while (restTime >= intervalTime) {
            //         FixedTick(ctx, intervalTime);
            //         restTime -= intervalTime;
            //     }
            // }

            LateTick(ctx, dt);

        }

        static void ResetInput(GameBusinessContext ctx) {
            var inputEntity = ctx.inputEntity;
            inputEntity.Reset();
        }

        static void ProcessInput(GameBusinessContext ctx, float dt) {
            GameInputDomain.Player_BakeInput(ctx, dt);

            var game = ctx.gameEntity;
            var status = game.FSM_GetStatus();
            if (status == GameFSMStatus.Gaming) {
                GameInputDomain.Owner_BakeInput(ctx, ctx.Paddle_GetOwner());
            }

        }

        static void PreTick(GameBusinessContext ctx, float dt) {

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

            // Physics2D.Simulate(dt);

        }

        static void LateTick(GameBusinessContext ctx, float dt) {

        }

        public static void TearDown(GameBusinessContext ctx) {
            ExitGame(ctx);
        }

    }

}