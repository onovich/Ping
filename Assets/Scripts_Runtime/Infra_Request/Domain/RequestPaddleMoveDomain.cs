using System;
using MortiseFrame.LitIO;
using Ping.Protocol;
using MortiseFrame.Abacus;

namespace Ping.Requests {

    public static class RequestPaddleMoveDomain {

        // Send
        public static void Send_PaddleMoveReq(RequestInfraContext ctx, Vector2 axis) {

            var msg = new PaddleMoveReqMessage();
            msg.moveAxis = axis;
            byte msgID = ProtocolIDConst.REQID_PADDLEMOVE;

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