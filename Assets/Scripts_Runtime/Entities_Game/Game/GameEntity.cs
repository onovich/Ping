namespace Ping {

    public class GameEntity {

        public RandomService random;
        GameFSMComponent fsmComponent;

        int turn;

        public GameEntity() {
            fsmComponent = new GameFSMComponent();
            FSM_EnterNotInGame();
        }

        public GameFSMStatus GetStatus() {
            return fsmComponent.status;
        }

        public void FSM_EnterGaming() {
            fsmComponent.Gaming_Enter();
        }

        public void FSM_EnterNotInGame() {
            fsmComponent.status = GameFSMStatus.NotInGame;
        }

        public GameFSMStatus FSM_GetStatus() {
            return fsmComponent.status;
        }

        public int GetTurn() {
            return turn;
        }

        public void IncTurn() {
            turn++;
        }

        public void ResetTurn() {
            turn = 0;
        }

    }

}