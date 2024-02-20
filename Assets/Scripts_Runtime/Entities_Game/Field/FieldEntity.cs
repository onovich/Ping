using UnityEngine;

namespace Ping {

    public class FieldEntity : MonoBehaviour {

        AABB bound;
        [SerializeField] WallEntity[] walls;
        [SerializeField] GateEntity[] gates;

        public void Ctor() {

        }

        public void SetBound(Vector2 min, Vector2 max) {
            bound = new AABB(min, max);
        }

        public AABB GetBound() {
            return bound;
        }

        public void TearDown() {
            foreach (var wall in walls) {
                wall.TearDown();
            }
            foreach (var gate in gates) {
                gate.TearDown();
            }
            Destroy(gameObject);
        }

    }

}