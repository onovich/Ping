namespace Ping.Business.Game {

    public static class GameBusiness {

        public static void Init(GameBusinessContext ctx) {

        }

        public static void StartGame(GameBusinessContext ctx) {
            GameGameDomain.NewGame(ctx);
        }

        public static void ExitGame(GameBusinessContext ctx) {
            GameGameDomain.ExitGame(ctx);
        }

        public static void Tick(GameBusinessContext ctx, float dt) {

            ResetInput(ctx);
            ProcessInput(ctx);
            PreTick(ctx, dt);

            float restTime = dt;
            const float interval = 0.01f;
            for (; restTime >= interval; restTime -= interval) {
                FixedTick(ctx, interval);
            }

            if (restTime > 0) {
                FixedTick(ctx, restTime);
            }

            LateTick(ctx, dt);

        }

        static void ResetInput(GameBusinessContext ctx) {

        }

        static void ProcessInput(GameBusinessContext ctx) {

        }

        static void PreTick(GameBusinessContext ctx, float dt) {

        }

        static void FixedTick(GameBusinessContext ctx, float dt) {

        }

        static void LateTick(GameBusinessContext ctx, float dt) {

        }

        public static void TearDown(GameBusinessContext ctx) {
            ExitGame(ctx);
        }

    }

}