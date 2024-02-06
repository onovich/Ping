using UnityEngine;

namespace Ping {

    public class FieldEntity : MonoBehaviour {

        AABB bound;

        public void Ctor() {

        }

        public void SetBound(Vector2Int min, Vector2Int max) {
            bound = new AABB(min, max);
        }

        public AABB GetBound() {
            return bound;
        }

        public void TearDown() {
            Destroy(gameObject);
        }

    }

}