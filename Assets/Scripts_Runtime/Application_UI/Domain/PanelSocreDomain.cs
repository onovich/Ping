using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ping.UI {

    public static class PanelScoreDomain {

        public static void Open(UIAppContext ctx, string player0Name, string player1Name, int ownerIndex) {
            Panel_Score panel = UIFactory.UniquePanel_Open<Panel_Score>(ctx);
            panel.Ctor();
            panel.SetOwnerIndex(ownerIndex);
            panel.SetPlayer0Name(player0Name);
            panel.SetPlayer1Name(player1Name);
        }

        public static void Close(UIAppContext ctx) {
            Panel_Score panel = ctx.UniquePanel_Get<Panel_Score>();
            if (panel == null) {
                return;
            }
            UIFactory.UniquePanel_Close<Panel_Score>(ctx);
        }

        public static void SetPlayerScore(UIAppContext ctx, int score, int playerIndex) {
            Panel_Score panel = ctx.UniquePanel_Get<Panel_Score>();
            if (panel == null) {
                PLog.LogError("Panel_Score not found");
            }
            if (playerIndex == 0) {
                panel.SetPlayer0Score(score);
            }
            if (playerIndex == 1) {
                panel.SetPlayer1Score(score);
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