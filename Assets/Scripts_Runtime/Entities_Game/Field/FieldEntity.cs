using UnityEngine;

namespace Ping {

    public class FieldEntity : MonoBehaviour {

        public AABB bound;

        public void Ctor() {

        }

        public void SetBound(Vector2Int min, Vector2Int max) {
            bound = new AABB(min, max);
        }

        public void TearDown() {
            Destroy(gameObject);
        }

    }

}