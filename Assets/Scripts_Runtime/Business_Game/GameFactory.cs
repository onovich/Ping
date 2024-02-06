using UnityEngine;

namespace Ping.Business.Game {

    public static class GameFactory {

        // Field
        public static FieldEntity Field_Spawn(TemplateInfraContext templateInfraContext,
                                              AssetsInfraContext assetsInfraContext) {

            var config = templateInfraContext.Config_Get();

            var prefab = assetsInfraContext.Entity_GetField();
            var field = GameObject.Instantiate(prefab).GetComponent<FieldEntity>();
            field.Ctor();

            // Set Bound
            field.SetBound(config.fieldBoundMin, config.fieldBoundMax);

            return field;
        }

        // Ball
        public static BallEntity Ball_Spawn(TemplateInfraContext templateInfraContext,
                                            AssetsInfraContext assetsInfraContext,
                                            Vector2 pos) {

            var config = templateInfraContext.Config_Get();

            var prefab = assetsInfraContext.Entity_GetBall();
            var ball = GameObject.Instantiate(prefab).GetComponent<BallEntity>();
            ball.Ctor();

            // Set Attr
            ball.Attr_SetMoveSpeed(config.ballMoveSpeed);
            ball.Attr_SetMoveSpeedMax(config.ballMoveSpeedMax);

            // Set Pos
            ball.Pos_SetPos(pos);

            // Set FSM
            ball.FSM_EnterIdle();

            return ball;

        }

        // Paddle
        public static PaddleEntity Paddle_Spawn(TemplateInfraContext templateInfraContext,
                                                AssetsInfraContext assetsInfraContext,
                                                int id,
                                                Vector2 pos) {

            var config = templateInfraContext.Config_Get();

            var prefab = assetsInfraContext.Entity_GetPaddle();
            var paddle = GameObject.Instantiate(prefab).GetComponent<PaddleEntity>();
            paddle.Ctor();

            // Base Info
            paddle.SetPlayerID(id);

            // Set Attr
            paddle.Attr_SetMoveSpeed(config.paddleMoveSpeed);
            paddle.Attr_SetMoveSpeedMax(config.paddleMoveSpeedMax);

            // Set Pos
            paddle.Pos_SetPos(pos);

            // Set FSM
            paddle.FSM_EnterMoving();

            return paddle;
        }

    }

}