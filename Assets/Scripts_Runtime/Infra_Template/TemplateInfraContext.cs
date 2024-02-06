using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Ping {

    public class TemplateInfraContext {

        GameConfig config;
        public AsyncOperationHandle configHandle;

        public TemplateInfraContext() {
        }

        // Game
        public void Config_Set(GameConfig config) {
            this.config = config;
        }

        public GameConfig Config_Get() {
            return config;
        }

        // Clear
        public void Clear() {
        }

    }

}