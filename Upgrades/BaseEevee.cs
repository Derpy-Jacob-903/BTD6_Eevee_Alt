using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
using BTD_Mod_Helper.Api.Display;

namespace AltEevee.Upgrades.TopPath
{
    public class SharperPins : ModUpgrade <AltEevee>
    {
        public override int Path => TOP;
        public override int Tier => 1;
        public override int Cost => 150;
        public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("Druid-200").GetUpgrade(TOP, 2).icon;
        public override string Description => "Sharper pins a";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            //towerModel.GetWeapon().rate *= 0.66f;
            towerModel.range += 10;
            var attackModel = towerModel.GetAttackModel();
            attackModel.range += 10;
            attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("Druid-200").GetAttackModel().weapons[1].projectile.Duplicate();
            //attackModel.weapons[0].projectile.SetHitCamo(true);
        }
    }
    public class HarderPins : ModUpgrade <AltEevee>
    {
        public override int Path => TOP;
        public override int Tier => 2;
        public override int Cost => 150;
        public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("Druid-200").GetUpgrade(TOP, 2).icon;
        public override string Description => "Sharper pins a";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            //towerModel.GetWeapon().rate *= 0.66f;
            towerModel.range += 10;
            var attackModel = towerModel.GetAttackModel();
            attackModel.range += 10;
            attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("Druid-200").GetAttackModel().weapons[1].projectile.Duplicate();
            //attackModel.weapons[0].projectile.SetHitCamo(true);
        }
    }
    public class FasterThrowing : ModUpgrade <AltEevee>
    {
        public override int Path => MIDDLE;
        public override int Tier => 1;
        public override int Cost => 150;
        public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("Druid-200").GetUpgrade(TOP, 2).icon;
        public override string Description => "Sharper pins a";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            //towerModel.GetWeapon().rate *= 0.66f;
            towerModel.range += 10;
            var attackModel = towerModel.GetAttackModel();
            attackModel.range += 10;
            attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("Druid-200").GetAttackModel().weapons[1].projectile.Duplicate();
            //attackModel.weapons[0].projectile.SetHitCamo(true);
        }
    }
    public class FasterPins : ModUpgrade <AltEevee>
    {
        public override int Path => MIDDLE;
        public override int Tier => 2;
        public override int Cost => 150;
        public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("Druid-200").GetUpgrade(TOP, 2).icon;
        public override string Description => "Sharper pins a";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            //towerModel.GetWeapon().rate *= 0.66f;
            towerModel.range += 10;
            var attackModel = towerModel.GetAttackModel();
            attackModel.range += 10;
            attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("Druid-200").GetAttackModel().weapons[1].projectile.Duplicate();
            //attackModel.weapons[0].projectile.SetHitCamo(true);
        }
    }
    public class LongRangePins : ModUpgrade <AltEevee>
    {
        public override int Path => BOTTOM;
        public override int Tier => 1;
        public override int Cost => 150;
        public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("Druid-200").GetUpgrade(TOP, 2).icon;
        public override string Description => "Sharper pins a";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            //towerModel.GetWeapon().rate *= 0.66f;
            towerModel.range += 10;
            var attackModel = towerModel.GetAttackModel();
            attackModel.range += 10;
            attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("Druid-200").GetAttackModel().weapons[1].projectile.Duplicate();
            //attackModel.weapons[0].projectile.SetHitCamo(true);
        }
    }
    public class LongRangePins : ModUpgrade <AltEevee>
    {
        public override int Path => BOTTOM;
        public override int Tier => 2;
        public override int Cost => 150;
        public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("Druid-200").GetUpgrade(TOP, 2).icon;
        public override string Description => "Sharper pins a";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            //towerModel.GetWeapon().rate *= 0.66f;
            towerModel.range += 10;
            var attackModel = towerModel.GetAttackModel();
            attackModel.range += 10;
            attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("Druid-200").GetAttackModel().weapons[1].projectile.Duplicate();
            //attackModel.weapons[0].projectile.SetHitCamo(true);
        }
    }
}
