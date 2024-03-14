using System.Collections.Generic;
using System.Net.Sockets;
using System.Collections.Concurrent;
using Ping.Protocol;
using System;

namespace Ping.Requests {

    public class RequestInfraContext {

        Socket client;
        public Socket Client => client;

        RequestEventCenter eventCenter;
        public RequestEventCenter EventCenter => eventCenter;

        // Message
        Queue<IMessage> messageQueue;

        // Buffer
        public byte[] readBuff;

        public RequestInfraContext() {
            eventCenter = new RequestEventCenter();
            messageQueue = new Queue<IMessage>();
            readBuff = new byte[4096];
        }

        public void Client_Set(Socket socket) {
            this.client = socket;
        }

        // Message
        public void Message_Enqueue(IMessage message) {
            messageQueue.Enqueue(message);
        }

        public bool Message_TryDequeue(out IMessage message) {
            return messageQueue.TryDequeue(out message);
        }

        public int Message_GetCount() {
            return messageQueue.Count;
        }

        // Buffer
        public void Buffer_Clear() {
            Array.Clear(readBuff, 0, readBuff.Length);
        }

    }

}