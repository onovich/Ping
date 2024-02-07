using UnityEngine;

namespace Ping.Business.Game {

    public static class GameBallDomain {

        public static BallEntity Spawn(GameBusinessContext ctx, Vector2 pos) {
            var Ball = GameFactory.Ball_Spawn(ctx.templateInfraContext, ctx.assetsInfraContext, pos);
            ctx.Ball_Set(Ball);
            return Ball;
        }

        public static void UnSpawn(GameBusinessContext ctx, BallEntity ball) {
            ctx.Ball_Set(null);
            ball.TearDown();
        }

        public static void BallMove(GameBusinessContext ctx, BallEntity ball, float fixdt) {

            BallFSMComponent fsm = ball.FSM_GetComponent();

            var dir = fsm.movingDir;
            ball.Move_ByDir(dir, fixdt);

            OverlapCheck(ctx, ball);

        }

        static void OverlapCheck(GameBusinessContext ctx, BallEntity ball) {

            var overlaps = ctx.overlapTemp;
            int targetLayerMask = 1 << LayerConst.PADDLE;
            int count = Physics2D.OverlapCircleNonAlloc(ball.Pos_GetPos(), ball.Attr_GetRadius(), overlaps, targetLayerMask);
            if (count <= 0) {
                return;
            }
            var coll = overlaps[0];
            var paddle = coll.transform.parent.GetComponentInChildren<PaddleEntity>();
            Ball_HitPaddle(ctx, ball, paddle);

        }

        static void Ball_HitPaddle(GameBusinessContext ctx, BallEntity ball, PaddleEntity paddle) {
            // TODO
            ball.Move_Stop();
        }

    }

}