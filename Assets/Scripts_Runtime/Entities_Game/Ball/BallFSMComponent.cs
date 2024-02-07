using UnityEngine;

namespace Ping {

    public class BallFSMComponent {

        public BallFSMStatus status;

        public int turn;

        public bool idle_isEntering;
        public bool moving_isEntering;
        public bool dead_isEntering;

        public Vector2 movingDir;

        public BallFSMComponent() { }

        public void EnterIdle() {
            status = BallFSMStatus.Idle;
            idle_isEntering = true;
            turn++;
        }

        public void EnterMoving(Vector2 movingDir) {
            status = BallFSMStatus.Moving;
            moving_isEntering = true;
            this.movingDir = movingDir;
        }

        public void EnterDead() {
            status = BallFSMStatus.Dead;
            dead_isEntering = true;
        }

    }

}