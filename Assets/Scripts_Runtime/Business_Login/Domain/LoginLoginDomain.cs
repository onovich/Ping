using System;

namespace Ping.Business.Login {

    public static class LoginLoginDomain {

        public static void UI_OnClickJoinRoom(LoginBusinessContext ctx) {


            Action action = async () => {

                await LoginRoomDomain.Net_StartConnect(ctx);
                LoginRoomDomain.Net_SendJoinRoomReq(ctx);

            };
            action.Invoke();


        }

    }

}
