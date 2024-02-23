using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ping {

    public class WallEntity : MonoBehaviour {

        public void TearDown() {
            Destroy(gameObject);
        }

    }

}