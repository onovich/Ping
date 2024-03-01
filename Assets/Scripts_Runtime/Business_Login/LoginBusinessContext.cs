using Ping.Requests;

namespace Ping.Business.Login {

    public class LoginBusinessContext {

        // Event
        public LoginEventCenter evt;

        // UI
        public UIAppContext uiAppContext;

        // Infra
        public RequestInfraContext reqContext;

        // Main
        public MainContext mainContext;

        public string ownerName;

        public LoginBusinessContext() {
            evt = new LoginEventCenter();
        }

        // Player
        public PlayerEntity Player_Get(int index) {
            return mainContext.Player_Get(index);
        }

        public PlayerEntity Player_GetOwner() {
            return mainContext.Player_Get(mainContext.ownerIndex);
        }

    }

}