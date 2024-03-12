using System;
using System.Net.Sockets;
using Ping.Protocol;

namespace Ping.Requests {

    public class RequestEventCenter {

        // Connect
        public Action<ConnectResMessage> OnConnect_ResHandle;
        public void OnConnect_Res(ConnectResMessage msg) {
            OnConnect_ResHandle?.Invoke(msg);
        }

        public Action<string> OnConnect_ResErrorHandle;
        public void OnConnect_ResError(string msg) {
            OnConnect_ResErrorHandle?.Invoke(msg);
        }

        // Login
        public Action<JoinRoomBroadMessage> OnLogin_JoinRoomBroadHandle;
        public void OnLogin_JoinRoomBroad(JoinRoomBroadMessage msg) {
            OnLogin_JoinRoomBroadHandle?.Invoke(msg);
        }

        public Action<GameStartBroadMessage> OnLogin_GameStartBroadHandle;
        public void OnLogin_GameStartBroad(GameStartBroadMessage msg) {
            OnLogin_GameStartBroadHandle?.Invoke(msg);
        }

        // Game
        public Action<EntitiesSyncBroadMessage> OnGame_EntitiesSyncBroadHandle;
        public void OnGame_EntitiesSyncBroad(EntitiesSyncBroadMessage msg) {
            OnGame_EntitiesSyncBroadHandle?.Invoke(msg);
        }

        public Action<GameResultBroadMessage> OnGame_GameResultBroadHandle;
        public void OnGame_GameResultBroad(GameResultBroadMessage msg) {
            OnGame_GameResultBroadHandle?.Invoke(msg);
        }

        public void Clear() {
            OnConnect_ResHandle = null;
            OnConnect_ResErrorHandle = null;
            OnLogin_JoinRoomBroadHandle = null;
            OnLogin_GameStartBroadHandle = null;
            OnGame_EntitiesSyncBroadHandle = null;
            OnGame_GameResultBroadHandle = null;
        }

    }

}