using UnityEngine;

namespace Ping.Business.Login {

    public class LoginBusiness {

        public static void Enter(LoginBusinessContext ctx) {
            UIApp.Login_Open(ctx.uiAppContext);
        }

        public static void Tick(LoginBusinessContext ctx, float dt) {
        }

        public static void Exit(LoginBusinessContext ctx) {
            UIApp.Login_Close(ctx.uiAppContext);
        }

        public static void ExitApplication(LoginBusinessContext ctx) {
            Exit(ctx);
            Application.Quit();
            PLog.Log("Application.Quit");
        }

        public static void OnUILoginClick(LoginBusinessContext ctx) {
            ctx.evt.Login();
        }

    }

}