using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ping {

    public class GateEntity : MonoBehaviour {

        public void TearDown() {
            Destroy(gameObject);
        }

    }

}