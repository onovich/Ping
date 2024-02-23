using System;
using Ping.Protocol;

namespace Ping.Requests {

    public class RequestEventCenter {

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
            JoinRoom_OnResHandle = null;
            RoomStartGame_OnBroadHandle = null;
        }

    }

}