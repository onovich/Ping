using System.Collections.Generic;

namespace Ping {

    public class MainContext {

        // Entity
        SortedList<int, PlayerEntity> players;
        public int ownerIndex;

        public MainContext() {
            players = new SortedList<int, PlayerEntity>(2);
            ownerIndex = -1;
        }

        // Player
        public void Player_Add(PlayerEntity playerEntity) {
            players.Add(playerEntity.GetPlayerIndex(), playerEntity);
        }

        public PlayerEntity Player_Get(int index) {
            var player = players[index];
            if (player == null) {
                PLog.LogError("PlayerEntity is null");
            }
            return player;
        }

        public void Player_Clear() {
            ownerIndex = -1;
            players.Clear();
        }

    }

}