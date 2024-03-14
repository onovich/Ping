using System;
using MortiseFrame.LitIO;
using Ping.Protocol;
using MortiseFrame.Abacus;

namespace Ping.Requests {

    public static class RequestEntitiesSyncDomain {

        // On
        public static void On_EntitiesSyncBroadRes(RequestInfraContext ctx, byte[] data) {

            int offset = 0;
            var msgID = ByteReader.Read<byte>(data, ref offset);
            if (msgID != ProtocolIDConst.GetID<EntitiesSyncBroadMessage>()) {
                return;
            }

            var msg = new EntitiesSyncBroadMessage();

            msg.FromBytes(data, ref offset);
            var evt = ctx.EventCenter;
            evt.OnGame_EntitiesSyncBroad(msg);

        }

    }

}