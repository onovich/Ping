using System;
using MortiseFrame.LitIO;
using Ping.Protocol;

namespace Ping.Requests {

    public static class RequestGameStartDomain {

        // On
        public static void On_GameStartBroadRes(RequestInfraContext ctx, byte[] data) {

            int offset = 0;
            var msgID = ByteReader.Read<byte>(data, ref offset);
            if (msgID != ProtocolIDConst.GetID<GameStartBroadMessage>()) {
                return;
            }

            var msg = new GameStartBroadMessage();

            msg.FromBytes(data, ref offset);
            var evt = ctx.EventCenter;
            evt.OnLogin_GameStartBroad(msg);

        }

        // Send
        public static void Send_GameStartReq(RequestInfraContext ctx) {

            var msg = new GameStartReqMessage();
            ctx.Message_Enqueue(msg);

        }

    }

}