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

        public static void MoveAndCheckHit(GameBusinessContext ctx, BallEntity ball, float fixdt) {
            BallFSMComponent fsm = ball.FSM_GetComponent();
            var dir = fsm.movingDir;
            if (PredictHit(ctx, ball, fixdt)) {
                return;
            }
            ball.Move_ByDir(dir, fixdt);
            TryHit(ctx, ball, 0.02f);
        }

        static bool PredictHit(GameBusinessContext ctx, BallEntity ball, float dis) {
            var succ = TryHit(ctx, ball, dis);
            return succ;
        }

        static bool TryHit(GameBusinessContext ctx, BallEntity ball, float dis) {
            var succ = false;
            int targetLayerMask = 1 << LayerConst.WALL;
            targetLayerMask |= 1 << LayerConst.PADDLE;
            var hits = ctx.raycastTemp;
            var dir = ball.Pos_GetDirection();
            int count = Physics2D.CircleCastNonAlloc(ball.Pos_GetPos(), ball.Attr_GetRadius(), dir, hits, dis, targetLayerMask);
            if (count <= 0) {
                return succ;
            }
            var hit = hits[0];
            succ |= TryHitWall(ctx, ball, hit);
            succ |= TryHitPaddle(ctx, ball, hit);
            return succ;
        }

        static bool TryHitPaddle(GameBusinessContext ctx, BallEntity ball, RaycastHit2D hit) {
            if (hit.collider == null) {
                return false;
            }
            var paddle = hit.transform.GetComponent<PaddleEntity>();
            if (paddle == null) {
                return false;
            }
            var normal = hit.normal;
            Reflect(ctx, ball, normal);
            return true;
        }

        static bool TryHitWall(GameBusinessContext ctx, BallEntity ball, RaycastHit2D hit) {
            if (hit.collider == null) {
                return false;
            }
            var wall = hit.transform.GetComponent<WallEntity>();
            if (wall == null) {
                return false;
            }
            PLog.Log($"GameBallDomain.TryHitWall: hit: {hit}");
            var normal = hit.normal;
            Reflect(ctx, ball, normal);
            return true;
        }

        static void Reflect(GameBusinessContext ctx, BallEntity ball, Vector2 normal) {
            // R = I - 2 * (I · N) * N
            // R: 反射向量; I: 入射向量; N: 法线单位向量
            var dir = ball.Pos_GetDirection() - 2 * (Vector2.Dot(ball.Pos_GetDirection(), normal)) * normal;
            ball.FSM_SetMovingDir(dir);
            PLog.Log($"GameBallDomain.Reflect: dir: {dir}");
        }

    }

}