using System;
using MortiseFrame.LitIO;
using Ping.Protocol;

namespace Ping.Requests {

    public static class RequestRoomStartGameDomain {

        // On
        public static void OnRoomStartGameBroadRes(RequestInfraContext ctx, byte[] data) {

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