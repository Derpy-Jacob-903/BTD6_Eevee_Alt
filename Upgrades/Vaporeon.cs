using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Map;
using Il2CppAssets.Scripts.Simulation.Behaviors;

namespace AltEevee.Upgrades.MiddlePath
{
    public class Vaporeon : ModUpgrade<AltEevee.EeveeKanto>
    {
        public override int Path => BOTTOM;
        public override int Tier => 3;
        public override int Cost => 625; //325-200+500
        public override string Portrait => "GlaceonPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("IceMonkey-001").GetUpgrade(BOTTOM, 1).icon;
        public override int Priority => 10;
        public override string Description => "Evolving Eevee to Vaporeon for long range attacks";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            //attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("MonkeySub").GetAttackModel().weapons[0].projectile.Duplicate();
            var baseProjectile = Game.instance.model.GetTowerFromId("MonkeySub").GetAttackModel().weapons[0].projectile.Duplicate(); //000 Sub projectile
            var dartProjectile = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().weapons[0].projectile.Duplicate(); //000 Dart projectile
            towerModel.areaTypes = Game.instance.model.GetTowerFromId("PatFusty").areaTypes;

            attackModel.AddBehavior(new TargetStrongSharedRangeModel("TargetStrongShared", false, true, false, true));
            attackModel.AddBehavior(new TargetFirstSharedRangeModel("TargetFirstShared", false, true, false, true));

            var projectile = attackModel.weapons[0].projectile;

            projectile.AddBehavior(baseProjectile.GetBehavior<TrackTargetModel>());
            projectile.ApplyDisplay<SubDartDisplay>();
            //projectile.pierce = 2;
            //var projectileModel = towerModel.GetAttackModel().GetDescendant<ProjectileModel>();
            //projectileModel.GetDamageModel().damage = 1; // 1
            towerModel.ApplyDisplay<GlaceonDisplay>();
            //}
        }
        public class GlaceonDisplay : ModDisplay
        {
            public override string BaseDisplay => Generic2dDisplay;
            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                NodeLoader.NodeLoader.LoadNode(node, "Glaceon", mod);
            }
        }
        public class SubDartDisplay : ModDisplay
        {
            public override string BaseDisplay => "e01ccafb0b98cc942b501b16dc4f7994";
        }
    }
}
