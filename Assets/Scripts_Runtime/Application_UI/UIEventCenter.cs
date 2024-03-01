using System;

namespace Ping.UI {

    public class UIEventCenter {

        // Login
        public Action<string> Login_OnStartGameClickHandle;
        public void Login_OnStartGameClick(string userName) {
            Login_OnStartGameClickHandle?.Invoke(userName);
        }

        public Action Login_OnExitGameClickHandle;
        public void Login_OnExitGameClick() {
            Login_OnExitGameClickHandle?.Invoke();
        }

        public Action Login_OnCancleJoinRoomClickHandle;
        public void Login_OnCancleJoinRoomClick() {
            Login_OnCancleJoinRoomClickHandle?.Invoke();
        }

        public void Clear() {
            Login_OnStartGameClickHandle = null;
            Login_OnExitGameClickHandle = null;
            Login_OnCancleJoinRoomClickHandle = null;
        }


    }

}