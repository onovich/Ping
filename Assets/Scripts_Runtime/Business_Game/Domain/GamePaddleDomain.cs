using UnityEngine;

namespace Ping.Business.Game {

    public static class GamePaddleDomain {

        public static PaddleEntity Spawn(GameBusinessContext ctx, int id, Vector2 pos) {
            var Paddle = GameFactory.Paddle_Spawn(ctx.templateInfraContext, ctx.assetsInfraContext, id, pos);
            ctx.Paddle_Set(Paddle);
            return Paddle;
        }

        public static void UnSpawn(GameBusinessContext ctx, PaddleEntity paddle) {
            ctx.Paddle_Clear(paddle);
            paddle.TearDown();
        }

    }

}