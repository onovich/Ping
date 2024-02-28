using System.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Ping.Requests {

    public static class RequestInfra {

        public static void Tick_Login(RequestInfraContext ctx, float dt) {
            var client = ctx.Client;
            if (client == null) {
                return;
            }
            if (!client.Poll(0, System.Net.Sockets.SelectMode.SelectRead)) {
                return;
            }
            byte[] data = new byte[4096];
            int count = client.Receive(data);
            if (count <= 0) {
                return;
            }

            On_ConnectRes(ctx, data);
            On_JoinRoomRes(ctx, data);
            On_StartGameBroadRes(ctx, data);

        }

        public static void Tick_Game(RequestInfraContext ctx, float dt) {
            return;
        }

        // Connect
        public static async Task Connect_ToServer(RequestInfraContext ctx) {
            await RequestConnectDomain.ConnectToServerAsync(ctx);
        }

        // Send Req
        public static void Send_JoinRoomReq(RequestInfraContext ctx, string token) {
            RequestJoinRoomDomain.SendJoinRoomReq(ctx, token);
        }

        // On Res
        public static void On_ConnectRes(RequestInfraContext ctx, byte[] data) {
            RequestConnectDomain.OnConnectRes(ctx, data);
        }

        public static void On_JoinRoomRes(RequestInfraContext ctx, byte[] data) {
            RequestJoinRoomDomain.OnJoinRoomRes(ctx, data);
        }

        public static void On_StartGameBroadRes(RequestInfraContext ctx, byte[] data) {
            RequestStartGameDomain.OnStartGameBroadRes(ctx, data);
        }

    }

}