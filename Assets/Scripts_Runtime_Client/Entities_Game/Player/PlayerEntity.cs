namespace Ping {

    public class PlayerEntity {

        int playerID;

        // Score
        int score;

        public void SetPlayerID(int id) {
            playerID = id;
        }

        public int GetPlayerID() {
            return playerID;
        }

        // Score
        public void Score_Inc() {
            score++;
        }

        public int Score_Get() {
            return score;
        }

    }

}