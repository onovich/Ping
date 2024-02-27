using System;
using MortiseFrame.LitIO;
using Ping.Protocol;

namespace Ping.Requests {

    public static class RequestStartGameDomain {

        // On
        public static void OnStartGameBroadRes(RequestInfraContext ctx, byte[] data) {

            var msgID = data[0];
            if (msgID != ProtocolIDConst.BROADID_STARTGAME) {
                return;
            }

            var msg = new RoomStartGameBroadMessage();
            int offset = 0;
            ushort count = ByteReader.Read<ushort>(data, ref offset);
            if (count <= 0) {
                return;
            }

            msg.FromBytes(data, ref offset);
            var evt = ctx.EventCenter;
            evt.RoomStartGame_OnBroad(msg);

        }

    }

}