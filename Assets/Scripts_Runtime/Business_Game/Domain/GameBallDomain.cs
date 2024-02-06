using UnityEngine;

namespace Ping.Business.Game {

    public static class GameBallDomain {

        public static BallEntity Spawn(GameBusinessContext ctx, Vector2 pos) {
            var Ball = GameFactory.Ball_Spawn(ctx.templateInfraContext, ctx.assetsInfraContext, pos);
            ctx.Ball_Set(Ball);
            return Ball;
        }

        public static void UnSpawn(GameBusinessContext ctx, BallEntity Ball) {
            ctx.Ball_Set(null);
            Ball.TearDown();
        }

    }

}