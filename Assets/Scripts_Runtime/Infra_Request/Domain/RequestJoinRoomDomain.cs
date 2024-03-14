using System;
using MortiseFrame.LitIO;
using Ping.Protocol;

namespace Ping.Requests {

    public static class RequestJoinRoomDomain {

        // On
        public static void On_JoinRoomBroadRes(RequestInfraContext ctx, byte[] data) {

            int offset = 0;
            var msgID = ByteReader.Read<byte>(data, ref offset);
            if (msgID != ProtocolIDConst.GetID<JoinRoomBroadMessage>()) {
                return;
            }

            var msg = new JoinRoomBroadMessage();

            msg.FromBytes(data, ref offset);
            var evt = ctx.EventCenter;
            evt.OnLogin_JoinRoomBroad(msg);

        }

        // Send
        public static void Send_JoinRoomReq(RequestInfraContext ctx, string userName) {

            var msg = new JoinRoomReqMessage();
            msg.userName = userName;
            ctx.Message_Enqueue(msg);

        }

    }

}