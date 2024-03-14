using System;
using MortiseFrame.LitIO;
using Ping.Protocol;

namespace Ping.Requests {

    public static class RequestGameStartDomain {

        // Send
        public static void Send_GameStartReq(RequestInfraContext ctx) {

            var msg = new GameStartReqMessage();
            ctx.Message_Enqueue(msg);

        }

    }

}