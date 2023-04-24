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
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Behaviors;

namespace AltEevee.Upgrades.MiddlePath
{
    public class Sylveon : ModUpgrade<AltEevee.EeveeSinnoh>
    {
        public override int Path => MIDDLE;
        public override int Tier => 3;
        public override int Cost => 2500;
        public override string Portrait => "GlaceonPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("IceMonkey-001").GetUpgrade(BOTTOM, 1).icon;
        public override int Priority => 10;
        public override string Description => "Evolving Eevee to Glaceon and faster attack speed";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            //attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("SentryCold").GetAttackModel().weapons[0].projectile.Duplicate();
            attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("IceMonkey-320").GetAttackModel().weapons[0].projectile.GetBehavior<FreezeModel>().Duplicate());
            attackModel.weapons[0].projectile.GetBehavior<FreezeModel>().layers *= 0;
            attackModel.weapons[0].projectile.GetBehavior<FreezeModel>().speed = 0.01f;
            attackModel.weapons[0].projectile.GetBehavior<FreezeModel>().canFreezeMoabs = true;

            
            attackModel.AddWeapon(Game.instance.model.GetTowerFromId("WizardMonkey-010").GetAttackModel("Fireball").weapons[0].Duplicate());
            towerModel.GetAttackModel().weapons[1].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Purple;
            towerModel.GetAttackModel().weapons[1].projectile.RemoveBehavior<DamageModel>();
            towerModel.GetAttackModel().weapons[1].projectile.RemoveBehavior<RemoveBloonModifiersModel>();
            towerModel.GetAttackModel().weapons[1].projectile.RemoveBehavior<FilterOnlyCamoInModel>();
            attackModel.weapons[1].projectile.AddBehavior(Game.instance.model.GetTowerFromId("IceMonkey-320").GetAttackModel().weapons[0].projectile.GetBehavior<FreezeModel>().Duplicate());
            attackModel.weapons[1].projectile.GetBehavior<FreezeModel>().layers = 0;
            attackModel.weapons[1].projectile.GetBehavior<FreezeModel>().speed = 0.01f;
            attackModel.weapons[1].projectile.GetBehavior<FreezeModel>().canFreezeMoabs = true;
            //.Filters.FilterOnlyCamoIn



            towerModel.GetWeapon().rate *= 0.7f;
            var projectile = attackModel.weapons[0].projectile;
            //projectile.pierce = 2;
            var projectileModel = towerModel.GetAttackModel().GetDescendant<ProjectileModel>();
            //projectileModel.GetDamageModel().damage = 8; // 1
            //projectileModel.GetDamageModel().immuneBloonProperties = BloonProperties.White;
            towerModel.ApplyDisplay<SylveonDisplay>();
            //}
        }

        public class PlayRough : ModUpgrade<AltEevee.EeveeSinnoh>
        {
            public override int Path => MIDDLE;
            public override int Tier => 4;
            public override int Cost => 2500;
            public override string Portrait => "GlaceonPortrait";
            public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("IceMonkey-001").GetUpgrade(BOTTOM, 1).icon;
            public override int Priority => 10;
            public override string Description => "Evolving Eevee to Glaceon and faster attack speed";

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var attackModel = towerModel.GetAttackModel();
                var ability = Game.instance.model.GetTower(TowerType.MonkeyBuccaneer, 0, 5, 0).GetAbility().Duplicate();
                ability.cooldown *= 1f;
                towerModel.AddBehavior(ability);
                //var projectile = attackModel.weapons[0].projectile;
                //projectile.pierce += 18;
                var projectileModel = towerModel.GetAttackModel().GetDescendant<ProjectileModel>();
                towerModel.ApplyDisplay<SylveonDisplay>();
                //}
            }
        }
        public class SylveonDisplay : ModDisplay
            {
                public override string BaseDisplay => Generic2dDisplay;
                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    NodeLoader.NodeLoader.LoadNode(node, "Glaceon", mod);
                }
            }
        }
    }
