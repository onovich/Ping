using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ping.UI {

    public static class PanelLoginDomain {

        public static void Open(UIAppContext ctx) {

            Panel_Login panel = UIFactory.UniquePanel_Open<Panel_Login>(ctx);
            panel.Ctor();

            panel.OnClickStartGameHandle += () => {
                ctx.eventCenter.Login_OnStartGameClick();
            };

            panel.OnClickExitGameHandle += () => {
                ctx.eventCenter.Login_OnExitGameClick();
            };

        }

        public static void Close(UIAppContext ctx) {
            UIFactory.UniquePanel_Close<Panel_Login>(ctx);
        }

    }

}