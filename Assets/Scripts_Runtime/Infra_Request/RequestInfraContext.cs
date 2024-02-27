using System.Collections.Generic;
using System.Net.Sockets;

namespace Ping.Requests {

    public class RequestInfraContext {

        Socket tcpClient;
        public Socket TCPClient => tcpClient;

        RequestEventCenter eventCenter;
        public RequestEventCenter EventCenter => eventCenter;

        public RequestInfraContext() {
            eventCenter = new RequestEventCenter();
        }

        public void Client_Set(Socket socket) {
            this.tcpClient = socket;
        }

    }

}