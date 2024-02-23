using System;
using MortiseFrame.LitIO;
using Ping.Protocol;

namespace Ping.Requests {

    public static class RequestRoomStartGameDomain {

        // On
        public static void OnRoomStartGameRes(RequestInfraContext ctx, byte[] data) {

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

        // Send
        public static void SendRoomStartGameReq(RequestInfraContext ctx, string token) {

            var msg = new RoomStartGameReqMessage();
            msg.userToken = token;
            byte msgID = msg.GetID();

            byte[] data = msg.ToBytes();
            if (data.Length >= 4096 - 2) {
                throw new Exception("Message is too long");
            }
            byte[] dst = new byte[data.Length + 2];
            int offset = 0;
            dst[offset] = msgID;
            offset += 1;
            Buffer.BlockCopy(data, 0, dst, offset, data.Length);
            var client = ctx.TCPClient;
            client.Send(dst);

        }

    }

}