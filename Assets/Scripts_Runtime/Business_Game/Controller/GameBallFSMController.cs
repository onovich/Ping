using UnityEngine;

namespace Ping.Business.Game {

    public static class GameBallFSMController {

        public static void FixedTickFSM(GameBusinessContext ctx, BallEntity ball, float fixdt) {

            FixedTickFSM_Any(ctx, ball, fixdt);

            BallFSMStatus status = ball.FSM_GetStatus();
            if (status == BallFSMStatus.Idle) {
                FixedTickFSM_Idle(ctx, ball, fixdt);
            } else if (status == BallFSMStatus.Moving) {
                FixedTickFSM_Moving(ctx, ball, fixdt);
            } else if (status == BallFSMStatus.Dead) {
                FixedTickFSM_Dead(ctx, ball, fixdt);
            } else {
                PLog.LogError($"GameBallFSMController.FixedTickFSM: unknown status: {status}");
            }

        }

        static void FixedTickFSM_Any(GameBusinessContext ctx, BallEntity ball, float fixdt) {

        }

        static void FixedTickFSM_Idle(GameBusinessContext ctx, BallEntity ball, float fixdt) {
            BallFSMComponent fsm = ball.FSM_GetComponent();
            if (fsm.idle_isEntering) {
                fsm.idle_isEntering = false;
            }

            var turn = fsm.turn;
            var side = turn % 2;
            var dir = side == 0 ? Vector2.up : Vector2.down;
            var game = ctx.gameEntity;
            dir = game.random.GetRandomDirection(dir, 90);

            fsm.EnterMoving(dir);
        }

        static void FixedTickFSM_Moving(GameBusinessContext ctx, BallEntity ball, float fixdt) {
            BallFSMComponent fsm = ball.FSM_GetComponent();
            if (fsm.moving_isEntering) {
                fsm.moving_isEntering = false;
            }

            GameBallDomain.MoveAndCheckHit(ctx, ball, fixdt);

        }

        static void FixedTickFSM_Dead(GameBusinessContext ctx, BallEntity ball, float fixdt) {
            BallFSMComponent fsm = ball.FSM_GetComponent();
            if (fsm.dead_isEntering) {
                fsm.dead_isEntering = false;
                ball.Move_Stop();
            }
        }

    }

}