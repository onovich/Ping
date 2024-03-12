using System;
using MortiseFrame.Abacus;
using UnityEngine;

namespace Ping.Business.Game {

    public static class GameBallDomain {

        public static BallEntity SpawnAtOriginPos(GameBusinessContext ctx, Vector2 pos) {
            var Ball = GameFactory.Ball_Spawn(ctx.templateInfraContext, ctx.assetsInfraContext, pos);
            ctx.Ball_Set(Ball);
            return Ball;
        }

        public static void UnSpawn(GameBusinessContext ctx, BallEntity ball) {
            ctx.Ball_Set(null);
            ball.TearDown();
        }

        public static void RecordSyncTargetPos(GameBusinessContext ctx, BallEntity ball, FVector2 pos) {
            ball.Sync_RecordSyncTargetPos(new UnityEngine.Vector2(pos.x, pos.y));
        }

        public static void ApplySyncMove(GameBusinessContext ctx, BallEntity ball) {
            ball.Move_Sync();
        }

        public static void ResetBall(GameBusinessContext ctx, BallEntity ball) {
            ball.Reset();
            ball.Reset_Sync();
        }

    }

}