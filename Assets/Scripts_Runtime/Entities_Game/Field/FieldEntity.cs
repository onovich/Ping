using UnityEngine;

namespace Ping {

    public class FieldEntity : MonoBehaviour {

        public AABB bound;

        public void TearDown() {
            Destroy(gameObject);
        }

    }

}