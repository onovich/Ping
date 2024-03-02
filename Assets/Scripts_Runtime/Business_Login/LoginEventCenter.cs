using System;

namespace Ping.Business.Login {

    public class LoginEventCenter {

        public LoginEventCenter() { }

        public Action<string> OnLoginDoneHandle;
        public void LoginDone(string userName) {
            OnLoginDoneHandle?.Invoke(userName);
        }

        public Action OnCancleWaitingHandle;
        public void CancleWaiting() {
            OnCancleWaitingHandle?.Invoke();
        }

        public void Clear() {
            OnLoginDoneHandle = null;
            OnCancleWaitingHandle = null;
        }

    }

}