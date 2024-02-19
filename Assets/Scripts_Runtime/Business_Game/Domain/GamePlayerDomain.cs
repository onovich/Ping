using UnityEngine;

namespace Ping.Business.Game {

    public static class GamePlayerDomain {

        public static void Spawn(GameBusinessContext ctx, int id) {

            var player = GameFactory.Player_Spawn(id);
            ctx.Player_Set(id, player);

        }

    }

}