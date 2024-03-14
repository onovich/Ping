using System;
using MortiseFrame.LitIO;
using Ping.Protocol;
using MortiseFrame.Abacus;

namespace Ping.Requests {

    public static class RequestPaddleMoveDomain {

        // Send
        public static void Send_PaddleMoveReq(RequestInfraContext ctx, FVector2 axis) {

            var msg = new PaddleMoveReqMessage();
            msg.moveAxis = axis;
            ctx.Message_Enqueue(msg);

        }

    }

}