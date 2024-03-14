using System;
using System.Net.Sockets;
using Ping.Protocol;

namespace Ping.Requests {

    public class RequestEventCenter {

        public void On(IMessage msg) {
            if (msg is ConnectResMessage) {
                OnConnect_Res((ConnectResMessage)msg);
            } else if (msg is JoinRoomBroadMessage) {
                OnLogin_JoinRoomBroad((JoinRoomBroadMessage)msg);
            } else if (msg is GameStartBroadMessage) {
                OnLogin_GameStartBroad((GameStartBroadMessage)msg);
            } else if (msg is EntitiesSyncBroadMessage) {
                OnGame_EntitiesSyncBroad((EntitiesSyncBroadMessage)msg);
            } else if (msg is GameResultBroadMessage) {
                OnGame_GameResultBroad((GameResultBroadMessage)msg);
            } else if (msg is KeepAliveResMessage) {
                KeepAlive_On((KeepAliveResMessage)msg);
            }

        }

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

        public Action<KeepAliveResMessage> KeepAlive_OnHandle;
        public void KeepAlive_On(KeepAliveResMessage msg) {
            KeepAlive_OnHandle?.Invoke(msg);
        }

        public void Clear() {
            OnConnect_ResHandle = null;
            OnConnect_ResErrorHandle = null;
            OnLogin_JoinRoomBroadHandle = null;
            OnLogin_GameStartBroadHandle = null;
            OnGame_EntitiesSyncBroadHandle = null;
            OnGame_GameResultBroadHandle = null;
            KeepAlive_OnHandle = null;
        }

    }

}