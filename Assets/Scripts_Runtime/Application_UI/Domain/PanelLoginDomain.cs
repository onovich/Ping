using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ping.UI {

    public static class PanelLoginDomain {

        public static void Open(UIAppContext ctx) {

            Panel_Login panel = UIFactory.UniquePanel_Open<Panel_Login>(ctx);
            panel.Ctor();

            panel.OnClickNewGameHandle += (userName) => {
                ctx.eventCenter.Login_OnStartGameClick(userName);
            };

            panel.OnClickExitGameHandle += () => {
                ctx.eventCenter.Login_OnExitGameClick();
            };

            panel.OnClickCancleJoinRoomHandle += () => {
                ctx.eventCenter.Login_OnCancleJoinRoomClick();
            };

        }

        public static void ShowWaitingPanel(UIAppContext ctx) {
            var panel = ctx.UniquePanel_Get<Panel_Login>();
            if (panel == null) {
                return;
            }
            panel.ShowWaitingPanel();
        }

        public static void HideWaitingPanel(UIAppContext ctx) {
            var panel = ctx.UniquePanel_Get<Panel_Login>();
            if (panel == null) {
                return;
            }
            panel.HideWaitingPanel();
        }

        public static void ShowStartGameBtn(UIAppContext ctx) {
            var panel = ctx.UniquePanel_Get<Panel_Login>();
            if (panel == null) {
                return;
            }
            panel.ShowStartGameBtn();
        }

        public static void HideStartGameBtn(UIAppContext ctx) {
            var panel = ctx.UniquePanel_Get<Panel_Login>();
            if (panel == null) {
                return;
            }
            panel.HideStartGameBtn();
        }

        public static void SetRoomInfo(UIAppContext ctx, string info) {
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