using UnityEngine;

namespace Ping.Business.Game {

    public static class GameBallFSMController {

        public static void FixedTickFSM(GameBusinessContext ctx, BallEntity Ball, float fixdt) {

            FixedTickFSM_Any(ctx, Ball, fixdt);

            BallFSMStatus status = Ball.FSM_GetStatus();
            if (status == BallFSMStatus.Idle) {
                FixedTickFSM_Idle(ctx, Ball, fixdt);
            } else if (status == BallFSMStatus.Moving) {
                FixedTickFSM_Moving(ctx, Ball, fixdt);
            } else if (status == BallFSMStatus.Dead) {
                FixedTickFSM_Dead(ctx, Ball, fixdt);
            } else {
                PLog.LogError($"GameBallFSMController.FixedTickFSM: unknown status: {status}");
            }

        }

        static void FixedTickFSM_Any(GameBusinessContext ctx, BallEntity Ball, float fixdt) {

        }

        static void FixedTickFSM_Idle(GameBusinessContext ctx, BallEntity Ball, float fixdt) {

        }

        static void FixedTickFSM_Moving(GameBusinessContext ctx, BallEntity Ball, float fixdt) {
            BallFSMComponent fsm = Ball.FSM_GetComponent();
            if (fsm.moving_isEntering) {
                fsm.moving_isEntering = false;
            }

            // TODO: Move

        }

        static void FixedTickFSM_Dead(GameBusinessContext ctx, BallEntity Ball, float fixdt) {
            BallFSMComponent fsm = Ball.FSM_GetComponent();
            if (fsm.dead_isEntering) {
                fsm.dead_isEntering = false;
                Ball.Move_Stop();
            }
        }

    }

}