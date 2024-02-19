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

        public static void SetPlayerScore(UIAppContext ctx, int score, int playerID) {
            Panel_Score panel = ctx.UniquePanel_Get<Panel_Score>();
            if (panel == null) {
                PLog.LogError("Panel_Score not found");
            }
            if (playerID == 1) {
                panel.SetPlayer1Score(score);
            }
            if (playerID == 2) {
                panel.SetPlayer2Score(score);
            }
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