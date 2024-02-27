using System;
using System.Net;
using System.Net.Sockets;
using MortiseFrame.LitIO;
using Ping.Protocol;

namespace Ping.Requests {

    public static class RequestConnectDomain {

        // On
        public static void OnConnectRes(RequestInfraContext ctx, byte[] data) {

            int offset = 0;
            ConnectResMessage msg = new ConnectResMessage();

            ushort count = ByteReader.Read<ushort>(data, ref offset);
            if (count <= 0) {
                return;
            }

            msg.FromBytes(data, ref offset);
            var evt = ctx.EventCenter;
            evt.ConnectRes_OnRes(msg);

        }

        // Send
        public static void ConnectToServer(RequestInfraContext ctx) {

            try {
                var client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                string ip = RequestConst.REMOTE_IP;
                int port = RequestConst.REMOTE_PORT;
                client.Connect(new IPEndPoint(IPAddress.Parse(ip), port));
                ctx.Client_Set(client);
            } catch (SocketException e) {
                PLog.LogError("SocketException: " + e);
            }

        }

    }

}