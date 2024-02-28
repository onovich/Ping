using System.Collections.Generic;
using System.Net.Sockets;

namespace Ping.Requests {

    public class RequestInfraContext {

        Socket client;
        public Socket Client => client;

        RequestEventCenter eventCenter;
        public RequestEventCenter EventCenter => eventCenter;

        public RequestInfraContext() {
            eventCenter = new RequestEventCenter();
        }

        public void Client_Set(Socket socket) {
            this.client = socket;
        }

    }

}