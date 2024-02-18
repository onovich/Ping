namespace Ping {

    public class GameEntity {

        public RandomService random;
        GameFSMComponent fsmComponent;

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

    }

}