using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ping.UI {

    public static class PanelLoginDomain {

        public static void Open(UIAppContext ctx) {

            Panel_Login panel = UIFactory.UniquePanel_Open<Panel_Login>(ctx);
            panel.Ctor();

            panel.OnClickStartGameHandle += (userName) => {
                ctx.eventCenter.Login_OnStartGameClick(userName);
            };

            panel.OnClickExitGameHandle += () => {
                ctx.eventCenter.Login_OnExitGameClick();
            };

            panel.OnClickCancleWaitingHandle += () => {
                ctx.eventCenter.Login_OnCancleWaitingClick();
            };

        }

        public static void ShowWaitingPanel(UIAppContext ctx, bool isShow) {
            var panel = ctx.UniquePanel_Get<Panel_Login>();
            if (panel == null) {
                return;
            }
            panel.ShowWaitingPanel(isShow);
        }

        public static void ShowRoomInfo(UIAppContext ctx, string info) {
            var panel = ctx.UniquePanel_Get<Panel_Login>();
            if (panel == null) {
                return;
            }
            panel.SetRoomInfo(info);
        }

        public static void Close(UIAppContext ctx) {
            var panel = ctx.UniquePanel_Get<Panel_Login>();
            if (panel == null) {
                return;
            }
            UIFactory.UniquePanel_Close<Panel_Login>(ctx);
        }

    }

}