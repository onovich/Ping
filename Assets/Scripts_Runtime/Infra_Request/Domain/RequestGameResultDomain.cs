using System;
using MortiseFrame.LitIO;
using Ping.Protocol;
using MortiseFrame.Abacus;

namespace Ping.Requests {

    public static class RequestGameResultDomain {

        // On
        public static void On_GameResultBroadRes(RequestInfraContext ctx, byte[] data) {

            int offset = 0;
            var msgID = ByteReader.Read<byte>(data, ref offset);
            if (msgID != ProtocolIDConst.BROADID_GAMERESULT) {
                return;
            }

            var msg = new GameResultBroadMessage();

            msg.FromBytes(data, ref offset);
            var evt = ctx.EventCenter;
            evt.OnGame_GameResultBroad(msg);

        }

    }

}