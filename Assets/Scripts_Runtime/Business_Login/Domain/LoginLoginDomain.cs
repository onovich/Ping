namespace Ping.Business.Login {

    public static class LoginLoginDomain {

        public static void UI_OnClickJoinRoom(LoginBusinessContext ctx) {
            LoginRoomDomain.Net_StartConnect(ctx);
        }

    }

}
