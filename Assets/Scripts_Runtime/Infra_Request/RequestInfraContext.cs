using System.Collections.Generic;

namespace Ping.Requests {

    public class RequestInfraContext {

        TCPClient tcpClient;
        public TCPClient TCPClient => tcpClient;

        RequestEventCenter eventCenter;
        public RequestEventCenter EventCenter => eventCenter;

        public RequestInfraContext() {
            tcpClient = new TCPClient();
            eventCenter = new RequestEventCenter();
        }

    }

}