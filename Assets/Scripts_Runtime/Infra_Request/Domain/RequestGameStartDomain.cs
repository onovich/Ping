using System;
using MortiseFrame.LitIO;
using Ping.Protocol;

namespace Ping.Requests {

    public static class RequestGameStartDomain {

        // On
        public static void On_GameStartBroadRes(RequestInfraContext ctx, byte[] data) {

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

        // Send
        public static void Send_GameStartReq(RequestInfraContext ctx) {

            var msg = new GameStartReqMessage();
            byte msgID = ProtocolIDConst.REQID_STARTGAME;

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