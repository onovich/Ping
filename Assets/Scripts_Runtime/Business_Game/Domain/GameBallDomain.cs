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

            int targetLayerMask = 1 << LayerConst.PADDLE;
            var hits = ctx.raycastTemp;
            var lastDirection = ball.Pos_GetVelocity();
            int count = Physics2D.RaycastNonAlloc(ball.Pos_GetPos(), lastDirection, hits, ball.Attr_GetRadius() + 0.01f, targetLayerMask);
            if (count <= 0) {
                return;
            }

            var hit = hits[0];
            var paddle = hit.transform.GetComponentInChildren<PaddleEntity>();
            var normal = hit.normal;
            // R = I - 2 * (I · N) * N
            // R: 反射向量; I: 入射向量; N: 法线单位向量
            var dir = lastDirection - 2 * (Vector2.Dot(lastDirection, normal)) * normal;
            Ball_HitPaddle(ctx, ball, paddle, dir);

        }

        static void Ball_HitPaddle(GameBusinessContext ctx, BallEntity ball, PaddleEntity paddle, Vector2 dir) {
            ball.Move_Stop();
            BallFSMComponent fsm = ball.FSM_GetComponent();
            fsm.movingDir = dir;
        }

    }

}