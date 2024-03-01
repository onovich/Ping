namespace Ping {

    public class GameEntity {

        public RandomService random;
        GameFSMComponent fsmComponent;

        int localOwnerPlayerIndex;

        int turn;
        float time;

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

        public void SetLocalOwnerPlayerIndex(int id) {
            localOwnerPlayerIndex = id;
        }

        public int GetLocalOwnerPlayerIndex() {
            return localOwnerPlayerIndex;
        }

        public void SetTime(float t) {
            time = t;
        }

        public float GetTime() {
            return time;
        }

    }

}