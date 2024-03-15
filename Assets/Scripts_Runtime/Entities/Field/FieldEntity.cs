using UnityEngine;

namespace Ping {

    public class FieldEntity : MonoBehaviour {

        public void Ctor() {

        }

        public void TearDown() {
            Destroy(gameObject);
        }

    }

}