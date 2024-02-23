using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using MortiseFrame.LitIO;
using Ping.Protocol;

namespace Ping.Requests {

    public class TCPClient {

        Socket client;

        public TCPClient() {
            client = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream,
            ProtocolType.Tcp);
        }

        public bool Connect(string host, int port) {
            if (!IPAddress.TryParse(host, out var address)) {
                return false;
            }
            try {
                IPEndPoint ep = new IPEndPoint(address, port);
                client.Connect(ep);
                return true;
            } catch {
                return false;
            }
        }

        public void Send(byte[] data) {
            Action action = async () => {
                try {
                    await SendAsync(data);
                } catch (Exception e) {
                    PLog.LogError(e.ToString());
                }
            };
            action.Invoke();
        }

        async Task<int> SendAsync(byte[] data) {
            var bufferSegment = new ArraySegment<byte>(data);
            try {
                return await client.SendAsync(bufferSegment, SocketFlags.None);
            } catch {
                Close();
                throw;
            }
        }

        public async Task<(int, byte[])> ReceiveAsync() {
            byte[] buffer = new byte[4096];
            int count = 0;
            try {
                count = await client.ReceiveAsync(buffer, SocketFlags.None);
            } catch {
                Close();
                throw;
            }

            if (count == 0) {
                Close();
                throw new Exception("Connection is closed");
            }
            return (count, buffer);
        }

        void Close() {
            if (client != null) {
                client.Close();
            }
        }

    }

}