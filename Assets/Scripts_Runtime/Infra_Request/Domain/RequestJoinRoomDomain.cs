using System;
using MortiseFrame.LitIO;
using Ping.Protocol;

namespace Ping.Requests {

    public static class RequestJoinRoomDomain {

        // Send
        public static void Send_JoinRoomReq(RequestInfraContext ctx, string userName) {

            var msg = new JoinRoomReqMessage();
            msg.userName = userName;
            ctx.Message_Enqueue(msg);

        }

    }

}