using UnityEngine;

namespace Ping.Business.Game {

    public static class GamePaddleFSMController {

        public static void FixedTickFSM(GameBusinessContext ctx, PaddleEntity Paddle, float fixdt) {

            FixedTickFSM_Any(ctx, Paddle, fixdt);

            PaddleFSMStatus status = Paddle.FSM_GetStatus();
            if (status == PaddleFSMStatus.Moving) {
                FixedTickFSM_Moving(ctx, Paddle, fixdt);
            } else {
                PLog.LogError($"GamePaddleFSMController.FixedTickFSM: unknown status: {status}");
            }

        }

        static void FixedTickFSM_Any(GameBusinessContext ctx, PaddleEntity Paddle, float fixdt) {

        }

        static void FixedTickFSM_Moving(GameBusinessContext ctx, PaddleEntity Paddle, float fixdt) {
            PaddleFSMComponent fsm = Paddle.FSM_GetComponent();
            if (fsm.moving_isEntering) {
                // Anim
                fsm.moving_isEntering = false;
            }

            // Move
            var player = ctx.playerEntity;
            if (Paddle.GetPlayerID() == player.GetOwnerPlayerID()) {
                Paddle.Move_Move(fixdt);
            }

        }

    }

}