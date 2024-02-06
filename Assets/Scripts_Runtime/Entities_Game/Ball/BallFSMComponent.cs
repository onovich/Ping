namespace Ping {

    public class BallFSMComponent {

        public BallFSMStatus status;

        public bool idle_isEntering;
        public bool moving_isEntering;
        public bool dead_isEntering;

        public BallFSMComponent() { }

        public void EnterIdle() {
            status = BallFSMStatus.Idle;
            idle_isEntering = true;
        }

        public void EnterMoving() {
            status = BallFSMStatus.Moving;
            moving_isEntering = true;
        }

        public void EnterDead() {
            status = BallFSMStatus.Dead;
            dead_isEntering = true;
        }

    }

}