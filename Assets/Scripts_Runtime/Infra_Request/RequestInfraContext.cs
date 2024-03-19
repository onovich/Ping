using System;
using MortiseFrame.Rill;

namespace Ping.Requests{

    public class RequestInfraContext {

        ClientCore clientCore;
        public ClientCore ClientCore => clientCore;

        public bool isTest;

        public RequestInfraContext() {
            clientCore = new ClientCore();
        }

    }

}