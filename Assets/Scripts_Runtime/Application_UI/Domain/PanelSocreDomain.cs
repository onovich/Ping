using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ping.UI {

    public static class PanelScoreDomain {

        public static void Open(UIAppContext ctx) {
            Panel_Score panel = UIFactory.UniquePanel_Open<Panel_Score>(ctx);
            panel.Ctor();
        }

        public static void Close(UIAppContext ctx) {
            Panel_Score panel = ctx.UniquePanel_Get<Panel_Score>();
            if (panel == null) {
                return;
            }
            UIFactory.UniquePanel_Close<Panel_Score>(ctx);
        }

        public static void SetPlayer1Score(UIAppContext ctx, int score) {
            Panel_Score panel = ctx.UniquePanel_Get<Panel_Score>();
            if (panel == null) {
                PLog.LogError("Panel_Score not found");
            }
            panel.SetPlayer1Score(score);
        }

        public static void SetPlayer2Score(UIAppContext ctx, int score) {
            Panel_Score panel = ctx.UniquePanel_Get<Panel_Score>();
            if (panel == null) {
                PLog.LogError("Panel_Score not found");
            }
            panel.SetPlayer2Score(score);
        }

        public static void SetGameTime(UIAppContext ctx, float time) {
            Panel_Score panel = ctx.UniquePanel_Get<Panel_Score>();
            if (panel == null) {
                PLog.LogError("Panel_Score not found");
            }
            panel.SetGameTime(time);
        }

    }

}