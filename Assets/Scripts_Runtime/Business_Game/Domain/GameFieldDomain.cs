using UnityEngine;

namespace Ping.Business.Game {

    public static class GameFieldDomain {

        public static FieldEntity Spawn(GameBusinessContext ctx) {
            var field = GameFactory.Field_Spawn(ctx.templateInfraContext, ctx.assetsInfraContext);
            ctx.Field_Set(field);
            return field;
        }

        public static void UnSpawn(GameBusinessContext ctx, FieldEntity field) {
            ctx.Field_Set(null);
            field.TearDown();
        }

    }

}