using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Ping {

    public class AssetsInfraContext {

        Dictionary<string, GameObject> entityDict;

        public AsyncOperationHandle entityHandle;

        public AssetsInfraContext() {
            entityDict = new Dictionary<string, GameObject>();
        }

        // Entity
        public void Entity_Add(string name, GameObject prefab) {
            entityDict.Add(name, prefab);
        }

        bool Entity_TryGet(string name, out GameObject asset) {
            var has = entityDict.TryGetValue(name, out asset);
            return has;
        }

        public GameObject Entity_GetBall() {
            var has = Entity_TryGet("Entity_Ball", out var prefab);
            if (!has) {
                PLog.LogError($"Entity Ball not found");
            }
            return prefab;
        }

        public GameObject Entity_GetPaddle() {
            var has = Entity_TryGet("Entity_Paddle", out var prefab);
            if (!has) {
                PLog.LogError($"Entity Paddle not found");
            }
            return prefab;
        }

        public GameObject Entity_GetField() {
            var has = Entity_TryGet("Entity_Field", out var prefab);
            if (!has) {
                PLog.LogError($"Entity Field not found");
            }
            return prefab;
        }

    }

}