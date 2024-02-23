using System;

namespace Ping.UI {

    public class UIEventCenter {

        // Login
        public Action Login_OnStartGameClickHandle;
        public void Login_OnStartGameClick() {
            Login_OnStartGameClickHandle?.Invoke();
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