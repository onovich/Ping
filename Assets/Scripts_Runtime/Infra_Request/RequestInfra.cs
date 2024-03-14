using System;
using System.Threading.Tasks;
using MortiseFrame.Abacus;
using MortiseFrame.LitIO;
using Ping.Protocol;

namespace Ping.Requests {

    public static class RequestInfra {

        public static void Tick_On(RequestInfraContext ctx, float dt) {
            var client = ctx.Client;
            if (client == null) {
                return;
            }
            if (!client.Poll(0, System.Net.Sockets.SelectMode.SelectRead)) {
                return;
            }
            byte[] buff = ctx.readBuff;
            int count = client.Receive(buff);
            if (count <= 0) {
                return;
            }

            var offset = 0;
            while (offset < count) {
                var len = ByteReader.Read<int>(buff, ref offset);
                if (len == 0) {
                    break;
                }
                On(ctx, buff, ref offset);
            }

            ctx.Buffer_ClearReadBuffer();
        }

        public static void On(RequestInfraContext ctx, byte[] data, ref int offset) {

            var msgID = ByteReader.Read<byte>(data, ref offset);
            var msg = ProtocolIDConst.GetObject(msgID) as IMessage;

            msg.FromBytes(data, ref offset);
            var evt = ctx.EventCenter;
            evt.On(msg);

        }

        public static void Tick_Send(RequestInfraContext ctx, float dt) {

            if (ctx.Client == null) {
                return;
            }

            while (ctx.Message_TryDequeue(out IMessage message)) {
                if (message == null) {
                    continue;
                }

                byte[] buff = ctx.writeBuff;
                int offset = 0;

                var src = message.ToBytes();
                if (src.Length >= 4096 - 5) {
                    PLog.Log("Message is too long");
                }

                int len = src.Length + 5;
                byte msgID = ProtocolIDConst.GetID(message);

                ByteWriter.Write<int>(buff, len, ref offset);
                ByteWriter.Write<byte>(buff, msgID, ref offset);
                Buffer.BlockCopy(src, 0, buff, offset, src.Length);
                offset += src.Length;

                if (offset == 0) {
                    return;
                }

                var client = ctx.Client;
                client.Send(buff, offset, System.Net.Sockets.SocketFlags.None);

                ctx.Buffer_ClearWriteBuffer();

            }

        }

        // Connect
        public static async Task Connect_ToServer(RequestInfraContext ctx) {
            await RequestConnectDomain.ConnectToServerAsync(ctx);
        }

        // Send Req
        // - Login
        public static void SendLogin_JoinRoomReq(RequestInfraContext ctx, string token) {
            RequestJoinRoomDomain.Send_JoinRoomReq(ctx, token);
        }

        public static void SendLogin_GameStartReq(RequestInfraContext ctx) {
            RequestGameStartDomain.Send_GameStartReq(ctx);
        }

        // - Game
        public static void SendGame_PaddleMoveReq(RequestInfraContext ctx, FVector2 axis) {
            RequestPaddleMoveDomain.Send_PaddleMoveReq(ctx, axis);
        }

    }

}