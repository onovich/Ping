using System;
using MortiseFrame.LitIO;
using Ping.Protocol;

namespace Ping.Requests {

    public static class RequestStartGameDomain {

        // On
        public static void OnStartGameBroadRes(RequestInfraContext ctx, byte[] data) {

            int offset = 0;
            var msgID = ByteReader.Read<byte>(data, ref offset);
            if (msgID != ProtocolIDConst.BROADID_STARTGAME) {
                return;
            }

            var msg = new GameStartBroadMessage();

            msg.FromBytes(data, ref offset);
            var evt = ctx.EventCenter;
            evt.GameStart_OnBroad(msg);

        }

    }

}