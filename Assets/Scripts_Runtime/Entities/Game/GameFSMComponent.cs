namespace Ping {

    public class GameFSMComponent {

        public GameFSMStatus Status;

        public bool gaming_isEntering;
        public bool result_isEntering;

        public int result_winnerPlayerIndex;

        public void NotInGame_Enter() {
            Status = GameFSMStatus.NotInGame;
        }

        public void Gaming_Enter() {
            Status = GameFSMStatus.Gaming;
            gaming_isEntering = true;
        }

        public void Result_Enter(int winnerPlayerIndex) {
            Status = GameFSMStatus.Result;
            result_isEntering = true;
            result_winnerPlayerIndex = winnerPlayerIndex;
        }

    }

}