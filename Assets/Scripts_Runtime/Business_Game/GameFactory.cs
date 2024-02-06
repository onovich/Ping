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
            ball.moveSpeed = config.ballMoveSpeed;

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
            paddle.playerID = id;

            // Set Attr
            paddle.moveSpeed = config.paddleMoveSpeed;
            paddle.moveSpeedMax = config.paddleMoveSpeedMax;

            // Set Pos
            paddle.Pos_SetPos(pos);

            return paddle;
        }

    }

}