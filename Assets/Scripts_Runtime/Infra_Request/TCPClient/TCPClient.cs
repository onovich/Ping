using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MortiseFrame.LitIO;
using Ping.Protocol;

namespace Ping.Requests {

    public class TCPClient {

        Socket client;
        bool isConnecting = false;

        byte[] readBuff;
        Queue<byte[]> writeQueue;

        delegate void EventListener(String msg);
        Dictionary<NetEvent, EventListener> eventListeners;

        public enum NetEvent {
            None = 0,
            ConnectSucc = 1,
            ConnectFail = 2,
            Close = 3,
        }

        public TCPClient() {
            eventListeners = new Dictionary<NetEvent, EventListener>();
        }

        void Init() {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            readBuff = new byte[4096];
            writeQueue = new Queue<byte[]>();
            isConnecting = false;
            client.NoDelay = true;
        }

        public void Connect(string host, int port) {
            if (!IPAddress.TryParse(host, out var address)) {
                PLog.LogError("Invalid IP address.");
                return;
            }

            if (client != null && client.Connected) {
                PLog.LogError("Socket is already connected.");
            }

            if (isConnecting) {
                PLog.LogError("Socket is connecting.");
                return;
            }

            Init();

            // Connect
            isConnecting = true;
            var ep = new IPEndPoint(address, port);
            client.BeginConnect(ep, ConnectCallback, client);
        }

        void ConnectCallback(IAsyncResult ar) {
            try {
                Socket socket = (Socket)ar.AsyncState;
                socket.EndConnect(ar);
                PLog.Log("Socket connected to " + socket.RemoteEndPoint.ToString());
                FireEvent(NetEvent.ConnectSucc, "");
                isConnecting = false;
            } catch (Exception e) {
                PLog.LogError("Socket Connect fail" + e.ToString());
                FireEvent(NetEvent.ConnectFail, e.ToString());
                isConnecting = false;
            }
        }

        void FireEvent(NetEvent evt, string msg) {
            if (eventListeners.ContainsKey(evt)) {
                eventListeners[evt].Invoke(msg);
            }
        }

        public void Send(byte[] data) {
            if (!client.Connected) {
                PLog.LogError("Socket is not connected.");
                return;
            }
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
            } catch (Exception e) {
                PLog.LogError(e.ToString());
                throw;
            }
        }

        public async Task<(int, byte[])> ReceiveAsync() {
            byte[] buffer = new byte[4096];
            int count = 0;
            try {
                count = await client.ReceiveAsync(buffer, SocketFlags.None);
            } catch (Exception e) {
                PLog.LogError(e.ToString());
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