using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using MortiseFrame.LitIO;
using Ping.Protocol;

namespace Ping.Requests {

    public static class RequestConnectDomain {

        // Send
        public static async Task ConnectToServerAsync(RequestInfraContext ctx) {

            var evt = ctx.EventCenter;

            try {
                var client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client.NoDelay = true;
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
                evt.OnConnect_ResError(errorMsg);
            } catch (Exception e) {
                PLog.LogError($"异常: {e.ToString()}");
            }
        }

    }

}