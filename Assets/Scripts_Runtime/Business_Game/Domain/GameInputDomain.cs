using Ping.Requests;

namespace Ping.Business.Game {

    public class GameInputDomain {

        public static void Player_BakeInput(GameBusinessContext ctx, float dt) {
            InputEntity inputEntity = ctx.inputEntity;
            inputEntity.ProcessInput(ctx.mainCamera, dt);
        }

        public static void Owner_BakeInput(GameBusinessContext ctx, PaddleEntity owner) {
            InputEntity inputEntity = ctx.inputEntity;
            var moveAxis = inputEntity.Move_GetAxis();
            owner.Input_SetMoveAxis(moveAxis);
        }

        public static void Owner_ApplySendInput(GameBusinessContext ctx) {
            var owner = ctx.Paddle_GetLocalOwner();
            var moveAxis = owner.Input_GetMoveAxis();
            RequestInfra.SendGame_PaddleMoveReq(ctx.reqContext, new MortiseFrame.Abacus.Vector2(moveAxis.x, moveAxis.y));
        }

    }

}