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
using Il2Cpp;

namespace AltEevee.Upgrades
{
    public class Espeon : ModUpgrade<AltEevee.EeveeJohto>
    {
        public override int Path => TOP;
        public override int Tier => 3;
        public override int Cost => 1350; //(150+300)+(1800-600-300)
        public override string Portrait => "FlareonPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("WizardMonkey").GetUpgrade(BOTTOM, 1).icon;
        public override int Priority => 10; 
        public override string Description => "Fires magical bolts of energy that deal extra damage to Ceramic, Fortified, and Lead Bloons. Can detect Camo Bloons.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {

            towerModel.AddBehavior(new OverrideCamoDetectionModel("CamoDetect", true));

            //towerModel.GetAttackModel().AddBehavior(new TargetStrongPrioCamoModel("StrongPrioCamo", true, false));
            //towerModel.GetAttackModel().AddBehavior(new TargetFirstPrioCamoModel("FirstPrioCamo", true, false));

            //towerModel.towerSelectionMenuThemeId = "Camo";
            towerModel.GetAttackModel().weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("CamoBloonDamageMultiplier", "Fortified", 2, 0, false, false));
            towerModel.GetAttackModel().weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("LeadBloonDamageMultiplier", "Ceramic", 2, 0, false, false));
            towerModel.GetAttackModel().weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("BlackBloonDamageMultiplier", "Lead", 2, 0, false, false));

            var attackModel = towerModel.GetAttackModel(); 
            var projectileModel = attackModel.GetDescendant<ProjectileModel>();
            //projectileModel.pierce += 2;
            attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("WizardMonkey-301").GetAttackModel().weapons[0].projectile.Duplicate();
            //towerModel.GetWeapon().rate *= 0.5f;
            //attackModel.weapons[0].projectile.SetHitCamo(true);

            var projectile = attackModel.weapons[0].projectile;
            projectile.pierce = 3;
            projectile.GetDamageModel().damage = 2;

            //towerModel.range += 10;
            //attackModel.range += 10;

            //var fire = Game.instance.model.GetTower(TowerType.MortarMonkey, 2, 0, 2).GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.GetBehavior<AddBehaviorToBloonModel>();
            //towerModel.GetAttackModel().weapons[0].projectile.AddBehavior(fire);
            //towerModel.GetAttackModel().weapons[0].projectile.collisionPasses = new[] { 1, 0 };
            towerModel.ApplyDisplay<FlareonDisplay>();
        }
    }
    public class Psychic : ModUpgrade<AltEevee.EeveeJohto>
    {
        public override int Path => TOP;
        public override int Tier => 4;
        public override int Cost => 1600; //1000+350+250
        public override string Portrait => "FlareonPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("MortarMonkey").GetUpgrade(TOP, 3).icon;
        public override int Priority => 0;
        public override string Description => "Gains a psychic attack that stuns and destroys singular Bloons. Main attack can distrack Bloons";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            //attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("SentryEnergy").GetAttackModel().weapons[0].projectile.Duplicate();
            //towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Purple;
            //var projectile = attackModel.weapons[0].projectile;
            attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("NinjaMonkey-010").GetAttackModel().weapons[0].projectile.GetBehavior<WindModel>().Duplicate());
            attackModel.weapons[0].projectile.GetBehavior<WindModel>().chance = 0.05f;
            //projectile.pierce = 4;
            //projectile.GetDamageModel().damage = 1;
            attackModel.AddWeapon(Game.instance.model.GetTowerFromId("Psi").GetAttackModel().weapons[0].Duplicate());
            //towerModel.GetAttackModel().weapons[1].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Purple;
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
