using UnityEngine;

namespace Ping.Business.Game {

    public static class GameGameDomain {
        public static void NewGame(GameBusinessContext ctx) {

            var config = ctx.templateInfraContext.Config_Get();

            // Game
            var game = ctx.gameEntity;
            game.FSM_EnterGaming();
            game.random = new RandomService(101052099, 0);

            // Field
            GameFieldDomain.Spawn(ctx);

            // Ball
            GameBallDomain.SpawnAtOriginPos(ctx, new Vector2(0, 0));

            // Paddle 1
            GamePaddleDomain.Spawn(ctx, 1, config.player1PaddleSpawnPos);
            GamePaddleDomain.Spawn(ctx, 2, config.player2PaddleSpawnPos);

            // UI
            UIApp.Score_Open(ctx.uiAppContext);

            // Cursor

        }

        public static void ExitGame(GameBusinessContext ctx) {

            // Game
            var game = ctx.gameEntity;
            if (game.FSM_GetStatus() == GameFSMStatus.NotInGame) return;

            game.FSM_EnterNotInGame();

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

            // Map
            // UI
            UIApp.Score_Close(ctx.uiAppContext);

        }

        public static void Win(GameBusinessContext ctx, int playerID) {
            var game = ctx.gameEntity;
            game.IncTurn();
            var player = ctx.Player_Get();
            player.Score_Inc();
            UIApp.Score_SetPlayerScore(ctx.uiAppContext, player.Score_Get(), playerID);
        }

    }

}