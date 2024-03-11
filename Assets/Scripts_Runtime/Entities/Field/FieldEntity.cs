using UnityEngine;

namespace Ping {

    public class FieldEntity : MonoBehaviour {

        AABB bound;
        [SerializeField] WallEntity[] walls;
        [SerializeField] GateEntity[] gates;

        public void Ctor() {

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