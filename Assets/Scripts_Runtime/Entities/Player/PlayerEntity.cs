namespace Ping {

    public class PlayerEntity {

        // Base Info
        int playerIndex;

        // Score
        int score;

        // Net
        string userName;

        public PlayerEntity(int index) {
            playerIndex = index;
            score = 0;
            userName = "";
        }

        // Player Index
        public int GetPlayerIndex() {
            return playerIndex;
        }

        // User Name
        public void SetUserName(string name) {
            userName = name;
        }

        public string GetUserName() {
            return userName;
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