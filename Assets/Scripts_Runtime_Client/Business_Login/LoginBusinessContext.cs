namespace Ping.Business.Login {

    public class LoginBusinessContext {

        public LoginEventCenter evt;
        public UIAppContext uiAppContext;

        public LoginBusinessContext() {
            evt = new LoginEventCenter();
        }

    }

}