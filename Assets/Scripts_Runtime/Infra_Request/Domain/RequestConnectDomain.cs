using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
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
            evt.ConnectRes_On(msg);

        }

        // Send
        public static async Task ConnectToServerAsync(RequestInfraContext ctx) {

            var evt = ctx.EventCenter;

            try {
                var client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                string ip = RequestConst.REMOTE_IP;
                int port = RequestConst.REMOTE_PORT;

                IPAddress ipAddress = IPAddress.Parse(ip);

                await Task.Factory.FromAsync(
                    client.BeginConnect,
                    client.EndConnect,
                    new IPEndPoint(ipAddress, port),
                    null);

                ctx.Client_Set(client);

            } catch (SocketException e) {
                var errorMsg = RequestErrorMessages.ErrorMessages[(int)e.SocketErrorCode];
                PLog.Log($"连接失败: {errorMsg}");
                evt.ConnectRes_OnError(errorMsg);
            } catch (Exception e) {
                PLog.LogError($"异常: {e.ToString()}");
            }
        }

    }

}