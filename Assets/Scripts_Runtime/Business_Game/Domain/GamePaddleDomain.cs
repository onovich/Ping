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

        public static void RecordSyncTargetPos(GameBusinessContext ctx, PaddleEntity paddle, MortiseFrame.Abacus.Vector2 pos) {
            paddle.Sync_RecordSyncTargetPos(new UnityEngine.Vector2(pos.x, pos.y));
        }

        public static void ApplySyncMove(GameBusinessContext ctx, PaddleEntity paddleEntity) {
            paddleEntity.Sync_Move();
        }

    }

}