using System;
using MortiseFrame.Rill;

namespace Ping.Requests {

    public class RequestInfraContext {

        ClientCore clientCore;
        public ClientCore ClientCore => clientCore;

        public TemplateInfraContext templateInfraContext;

        public bool isTest;

        public string REMOTE_IP_TEST;
        public int REMOTE_PORT;

        public string REMOTE_IP;

        public RequestInfraContext() {
            clientCore = new ClientCore();
        }

    }

}