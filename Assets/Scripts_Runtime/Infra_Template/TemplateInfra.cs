using System.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Ping {

    public static class TemplateInfra {

        public static async Task LoadAssets(TemplateInfraContext ctx) {

            {
                var handle = Addressables.LoadAssetAsync<GameConfig>("TM_Config");
                var config = await handle.Task;
                ctx.Config_Set(config);
                ctx.configHandle = handle;
            }

        }

        public static void Release(TemplateInfraContext ctx) {
            if (ctx.configHandle.IsValid()) {
                Addressables.Release(ctx.configHandle);
            }
        }

    }

}