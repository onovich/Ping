using System.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Ping.Requests {

    public static class RequestInfra {

        public static void JoinRoom_SendReq(RequestInfraContext ctx, string token) {
            RequestJoinRoomDomain.SendJoinRoomReq(ctx, token);
        }

        public static void RoomStartGame_SendReq(RequestInfraContext ctx, string token) {
            RequestRoomStartGameDomain.SendRoomStartGameReq(ctx, token);
        }

    }

}