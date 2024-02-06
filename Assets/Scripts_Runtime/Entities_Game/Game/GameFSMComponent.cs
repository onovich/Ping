namespace Ping {

    public class GameFSMComponent {

        public GameStatus status;

        public bool gaming_isEntering;

        public void NotInGame_Enter() {
            status = GameStatus.NotInGame;
        }

        public void Gaming_Enter() {
            status = GameStatus.Gaming;
            gaming_isEntering = true;
        }

    }

}