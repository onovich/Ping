namespace Ping {

    public class GameEntity {

        public RandomService random;
        GameFSMComponent fsmComponent;

        int turn;
        float time;

        public GameEntity() {
            fsmComponent = new GameFSMComponent();
            fsmComponent.NotInGame_Enter();
        }

        public GameFSMComponent FSM_GetComponent() {
            return fsmComponent;
        }

        public int GetTurn() {
            return turn;
        }

        public void SetTurn(int turn) {
            this.turn = turn;
        }

        public void ResetTurn() {
            turn = 0;
        }
        
        public void SetTime(float t) {
            time = t;
        }

        public float GetTime() {
            return time;
        }

    }

}