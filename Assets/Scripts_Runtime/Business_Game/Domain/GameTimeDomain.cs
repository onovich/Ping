using System;
using UnityEngine;

namespace Ping.Business.Game {

    public static class GameTimeDomain {

        public static void ApplyGameTime(GameBusinessContext ctx, float dt) {
            var game = ctx.gameEntity;
            game.SetTime(game.GetTime() + dt);
            UIApp.Score_SetGameTime(ctx.uiAppContext, game.GetTime());
        }

    }

}