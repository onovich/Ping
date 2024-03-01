using System;
using MortiseFrame.LitIO;
using Ping.Protocol;

namespace Ping.Requests {

    public static class RequestJoinRoomDomain {

        // On
        public static void OnJoinRoomBroadRes(RequestInfraContext ctx, byte[] data) {

            var msgID = data[0];
            if (msgID != ProtocolIDConst.BROADID_JOINROOM) {
                return;
            }

            int offset = 0;
            var msg = new JoinRoomBroadMessage();

            ushort count = ByteReader.Read<ushort>(data, ref offset);
            if (count <= 0) {
                return;
            }

            msg.FromBytes(data, ref offset);
            var evt = ctx.EventCenter;
            evt.JoinRoom_On(msg);

        }

        // Send
        public static void SendJoinRoomReq(RequestInfraContext ctx, string userName) {

            var msg = new JoinRoomReqMessage();
            msg.userName = userName;
            byte msgID = ProtocolIDConst.REQID_JOINROOM;

            byte[] data = msg.ToBytes();
            if (data.Length >= 4096 - 2) {
                throw new Exception("Message is too long");
            }

            byte[] dst = new byte[data.Length + 2];
            int offset = 0;
            dst[offset] = msgID;
            offset += 1;
            Buffer.BlockCopy(data, 0, dst, offset, data.Length);
            var client = ctx.Client;
            client.Send(dst);

        }

    }

}