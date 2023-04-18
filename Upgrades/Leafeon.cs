using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2Cpp;

namespace AltEevee.Upgrades
{
    public class Leafeon : ModUpgrade<AltEevee.EeveeSinnoh>
    {
        public override int Path => TOP;
        public override int Tier => 3;
        public override int Cost => 1065; // 280+1135-350
        public override string Portrait => "BlitzaPortrait";
        public override int Priority => 10;
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("Druid-200").GetUpgrade(TOP, 2).icon;
        public override string Description => "Evolving Eevee to Jolteon and increases the attack speed and range";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("Druid-120").GetAttackModel().weapons[0].projectile.Duplicate();
            towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            var projectile = attackModel.weapons[0].projectile;
            projectile.pierce = 4;
            projectile.GetDamageModel().damage = 1;
            //attackModel.AddWeapon(Game.instance.model.GetTowerFromId("NinjaMonkey-002").GetAttackModel().weapons[1].Duplicate());
            attackModel.AddWeapon(Game.instance.model.GetTowerFromId("NinjaMonkey-002").GetWeapons()[1].Duplicate());
            //attackModel.AddWeapon(Game.instance.model.GetTowerFromId("NinjaMonkey-002").GetWeapons()[1].Duplicate()); //"fireWithoutTarget": false
            attackModel.weapons[1].projectile = Game.instance.model.GetTowerFromId("Druid-030").GetWeapons()[1].projectile.Duplicate();
            towerModel.GetAttackModel().weapons[1].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            towerModel.ApplyDisplay<JolteonDisplay>();
        }
    }

    public class GrassyTerrain : ModUpgrade<AltEevee.EeveeSinnoh>
    {
        public override int Path => TOP;
        public override int Tier => 4;
        public override int Cost => 3000;
        public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("Druid-200").GetUpgrade(TOP, 4).icon;
        public override string Description => "Evolving Eevee to Jolteon and increases the attack speed and range";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            towerModel.AddBehavior(new MonkeyCityIncomeSupportModel("_MonkeyCityIncomeSupport", true, 1.15f, null, "MonkeyCityBuff", "BuffIconVillagexx4"));
            //towerModel.AddBehavior(new RangeSupportModel("_RangeSupport", true, 1.15f, null, "GrassyTerrainBuff", "BuffIconVillage3xx",false, "GrassyTerrainBuff",));
            //attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("Druid-200").GetAttackModel().weapons[1].projectile.Duplicate();
            //attackModel.weapons[0].projectile.SetHitCamo(true); Behaviors.DamageBasedAttackSpeed
            //towerModel.ApplyDisplay<JolteonDisplay>();
            //towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Druid-003").GetBehaviors<DamageBasedAttackSpeedModel>); //CS0311

            //
            //attackModel.AddWeapon(Game.instance.model.GetTowerFromId("Druid-400").GetAttackModel().weapons[2].Duplicate());
            //towerModel.GetAttackModel().weapons[2].rate *= 10f;
            //var projectile = attackModel.weapons[0].projectile;
            //projectile.GetDamageModel().damage *= 10;
        }
    }
    //public class JolteonDisplay : ModDisplay
    //{
    //    public override string BaseDisplay => Generic2dDisplay;
    //    public override void ModifyDisplayNode(UnityDisplayNode node)
    //   {
    //        NodeLoader.NodeLoader.LoadNode(node, "Jolteon", mod);
    //    }
    //}
}
