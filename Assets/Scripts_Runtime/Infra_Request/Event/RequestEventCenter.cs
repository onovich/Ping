using System;
using System.Net.Sockets;
using Ping.Protocol;

namespace Ping.Requests {

    public class RequestEventCenter {

        // Connect To Server Res
        public Action<ConnectResMessage> ConnectRes_OnHandle;
        public void ConnectRes_On(ConnectResMessage msg) {
            ConnectRes_OnHandle?.Invoke(msg);
        }

        public Action<string> ConnectRes_OnErrorHandle;
        public void ConnectRes_OnError(string msg) {
            ConnectRes_OnErrorHandle?.Invoke(msg);
        }

        // Join Room Broad
        public Action<JoinRoomBroadMessage> JoinRoom_OnHandle;
        public void JoinRoom_On(JoinRoomBroadMessage msg) {
            JoinRoom_OnHandle?.Invoke(msg);
        }

        // Room Start Game Broad
        public Action<GameStartBroadMessage> GameStart_OnBroadHandle;
        public void GameStart_OnBroad(GameStartBroadMessage msg) {
            GameStart_OnBroadHandle?.Invoke(msg);
        }

        public void Clear() {
            ConnectRes_OnHandle = null;
            ConnectRes_OnErrorHandle = null;
            JoinRoom_OnHandle = null;
            GameStart_OnBroadHandle = null;
        }

    }

}