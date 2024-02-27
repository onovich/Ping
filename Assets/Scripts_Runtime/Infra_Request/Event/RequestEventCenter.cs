using System;
using Ping.Protocol;

namespace Ping.Requests {

    public class RequestEventCenter {

        // Connect To Server Res
        public Action<ConnectResMessage> ConnectRes_OnResHandle;
        public void ConnectRes_OnRes(ConnectResMessage msg) {
            ConnectRes_OnResHandle?.Invoke(msg);
        }

        // Join Room Res
        public Action<JoinRoomResMessage> JoinRoom_OnResHandle;
        public void JoinRoom_OnRes(JoinRoomResMessage msg) {
            JoinRoom_OnResHandle?.Invoke(msg);
        }

        // Room Start Game Broad
        public Action<RoomStartGameBroadMessage> RoomStartGame_OnBroadHandle;
        public void RoomStartGame_OnBroad(RoomStartGameBroadMessage msg) {
            RoomStartGame_OnBroadHandle?.Invoke(msg);
        }

        public void Clear() {
            ConnectRes_OnResHandle = null;
            JoinRoom_OnResHandle = null;
            RoomStartGame_OnBroadHandle = null;
        }

    }

}