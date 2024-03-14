using System;
using MortiseFrame.LitIO;
using Ping.Protocol;

namespace Ping.Requests {

    public static class RequestKeepAliveDomain {

        // On
        public static void On_KeepAliveBroadRes(RequestInfraContext ctx, byte[] data) {

            int offset = 0;
            var msgID = ByteReader.Read<byte>(data, ref offset);
            if (msgID != ProtocolIDConst.GetID<KeepAliveResMessage>()) {
                return;
            }

            var msg = new KeepAliveResMessage();

            msg.FromBytes(data, ref offset);
            var evt = ctx.EventCenter;
            evt.KeepAlive_On(msg);

        }

    }

}