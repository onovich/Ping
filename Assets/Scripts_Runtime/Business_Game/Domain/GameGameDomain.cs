using UnityEngine;

namespace Ping.Business.Game {

    public static class GameGameDomain {
        public static void NewGame(GameBusinessContext ctx) {

            var config = ctx.templateInfraContext.Config_Get();

            // Game
            var game = ctx.gameEntity;
            var fsm = game.FSM_GetComponent();
            fsm.Gaming_Enter();
            game.random = new RandomService(101052099, 0);

            // Field
            GameFieldDomain.Spawn(ctx);

            // Ball
            GameBallDomain.SpawnAtOriginPos(ctx, new Vector2(0, 0));

            // Paddle 1
            GamePaddleDomain.Spawn(ctx, 1, config.player0PaddleSpawnPos);
            GamePaddleDomain.Spawn(ctx, 2, config.player1PaddleSpawnPos);

            // UI
            var player1 = ctx.Player_Get(1);
            var player2 = ctx.Player_Get(2);
            var ownerIndex = ctx.Player_GetOwnerIndex();
            UIApp.Score_Open(ctx.uiAppContext, player1.GetUserName(), player2.GetUserName(), ownerIndex);

        }

        public static void ExitGame(GameBusinessContext ctx) {

            // Game
            var game = ctx.gameEntity;
            var fsm = game.FSM_GetComponent();
            var status = fsm.Status;
            if (status == GameFSMStatus.NotInGame) return;

            fsm.NotInGame_Enter();

            // Field
            var field = ctx.Field_Get();
            GameFieldDomain.UnSpawn(ctx, field);

            // Ball
            var ball = ctx.Ball_Get();
            GameBallDomain.UnSpawn(ctx, ball);

            // Paddle
            var paddle1 = ctx.Paddle_Get(1);
            GamePaddleDomain.UnSpawn(ctx, paddle1);

            var paddle2 = ctx.Paddle_Get(2);
            GamePaddleDomain.UnSpawn(ctx, paddle2);

            // UI
            UIApp.Score_Close(ctx.uiAppContext);

        }

        public static void Win(GameBusinessContext ctx, int turn, int winnerPlayerIndex, int score1, int score2) {
            var game = ctx.gameEntity;
            game.SetTurn(turn);

            var player1 = ctx.Player_Get(1);
            var player2 = ctx.Player_Get(2);

            player1.Score_Set(score1);
            player2.Score_Set(score2);

            var fsm = game.FSM_GetComponent();
            fsm.Result_Enter(winnerPlayerIndex);

            var ball = ctx.Ball_Get();
        }

    }

}