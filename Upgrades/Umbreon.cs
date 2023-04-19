using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;

namespace AltEevee.Upgrades
{
    public class Umbreon : ModUpgrade<AltEevee.EeveeJohto>
    {
        public override int Path => BOTTOM;
        public override int Tier => 3;
        public override int Cost => 300; //300+300+300
        public override string Portrait => "FlareonPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("MonkeyAce-010").GetUpgrade(MIDDLE, 2).icon;
        public override int Priority => 11; //a
        public override string Description => "Evolves into Umbreon, allowing Camo Bloon detection. Throws arrows that deal extra damage to Camo, Lead (if damagable), Black and White Bloons.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {

            towerModel.AddBehavior(new OverrideCamoDetectionModel("CamoDetect", true));

            towerModel.GetAttackModel().AddBehavior(new TargetStrongPrioCamoModel("StrongPrioCamo", true, false));
            towerModel.GetAttackModel().AddBehavior(new TargetFirstPrioCamoModel("FirstPrioCamo", true, false));

            towerModel.towerSelectionMenuThemeId = "Camo";
            towerModel.GetAttackModel().weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("CamoBloonDamageMultiplier", "Camo", 4, 0, false, false));
            towerModel.GetAttackModel().weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("LeadBloonDamageMultiplier", "Lead", 2, 0, false, false));
            towerModel.GetAttackModel().weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("BlackBloonDamageMultiplier", "Black", 1, 1, false, false));
            towerModel.GetAttackModel().weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("WhiteBloonDamageMultiplier", "White", 1, 1, false, false));
            towerModel.GetAttackModel().weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("ZebraBloonDamageMultiplier", "Zebra", 1, 1, false, false));

            var attackModel = towerModel.GetAttackModel(); 
            var projectileModel = attackModel.GetDescendant<ProjectileModel>();
            //projectileModel.pierce += 2;
            attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("DartMonkey-003").GetAttackModel().weapons[0].projectile.Duplicate();
            //towerModel.GetWeapon().rate *= 0.5f;
            //attackModel.weapons[0].projectile.SetHitCamo(true);

            var projectile = attackModel.weapons[0].projectile;
            projectile.pierce = 2;
            projectile.GetDamageModel().damage = 1;

            towerModel.range += 10;
            attackModel.range += 10;

            //var fire = Game.instance.model.GetTower(TowerType.MortarMonkey, 2, 0, 2).GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.GetBehavior<AddBehaviorToBloonModel>();
            //towerModel.GetAttackModel().weapons[0].projectile.AddBehavior(fire);
            //towerModel.GetAttackModel().weapons[0].projectile.collisionPasses = new[] { 1, 0 };
            towerModel.ApplyDisplay<FlareonDisplay>();
        }
    }
    //public class FlareonDisplay:ModDisplay
    //{
    //    public override string BaseDisplay => Generic2dDisplay;
    //    public override void ModifyDisplayNode(UnityDisplayNode node)
    //    {
    //        NodeLoader.NodeLoader.LoadNode(node, "Flareon", mod);
    //    }
    //}
}
