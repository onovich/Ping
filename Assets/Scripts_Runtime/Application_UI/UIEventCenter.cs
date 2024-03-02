using System;

namespace Ping.UI {

    public class UIEventCenter {

        // Login
        public Action<string> Login_OnNewGameClickHandle;
        public void Login_OnNewGameClick(string userName) {
            Login_OnNewGameClickHandle?.Invoke(userName);
        }

        public Action Login_OnExitGameClickHandle;
        public void Login_OnExitGameClick() {
            Login_OnExitGameClickHandle?.Invoke();
        }

        public Action Login_OnCancleJoinRoomClickHandle;
        public void Login_OnCancleJoinRoomClick() {
            Login_OnCancleJoinRoomClickHandle?.Invoke();
        }

        public Action Login_OnGameStartClickHandle;
        public void Login_OnGameStartClick() {
            Login_OnGameStartClickHandle?.Invoke();
        }

        public void Clear() {
            Login_OnNewGameClickHandle = null;
            Login_OnExitGameClickHandle = null;
            Login_OnCancleJoinRoomClickHandle = null;
            Login_OnGameStartClickHandle = null;
        }


    }

}