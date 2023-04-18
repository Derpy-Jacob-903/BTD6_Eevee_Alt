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
            attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("MonkeySub").GetAttackModel().weapons[0].projectile.Duplicate();

            attackModel.AddBehavior(new TargetStrongSharedRangeModel("TargetStrongShared", false, true, false, true));
            attackModel.AddBehavior(new TargetFirstSharedRangeModel("TargetFirstShared", false, true, false, true));
            //towerModel.GetWeapon().rate *= 0.7f;
            var projectile = attackModel.weapons[0].projectile;
            projectile.pierce = 2;
            var projectileModel = towerModel.GetAttackModel().GetDescendant<ProjectileModel>();
            projectileModel.GetDamageModel().damage = 1; // 1
            //projectileModel.GetDamageModel().immuneBloonProperties = BloonProperties.White; //Can damage Frozen Bloons
            //foreach (var weaponModel in towerModel.GetWeapons())
            //{
            //    weaponModel.RemoveBehavior(ProjectileFilterModel);
            //}
            //foreach (var weaponModel in towerModel.GetWeapons())
            //towerModel.GetAttackModel().AddBehavior(new TargetStrongSharedRangeModel("TargetStrongShared", false, true, false, true)); // for vaporeon
            //var fire = Game.instance.model.GetTower(TowerType.Druid, 0, 0, 0).GetAttackModel().weapons[0].projectile.GetBehavior<BaseProjectile_>().projectile.GetDamageModel()>();
            //projectile.ProjectileBehaviorExt.AddProjectileBehavior(Game.instance.model.GetTowerFromId("Druid").GetAttackModel().weapons[0].projectile.Duplicate());
            //towerModel.GetAttackModel().weapons[0].projectile.AddBehavior(fire);

            //projectile.GetDamageModel().damage = 1; //Cold Sentry projectile has no DamageModel?

            //attackModel.weapons[0].projectile.SetHitCamo(true);
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
    }
}
