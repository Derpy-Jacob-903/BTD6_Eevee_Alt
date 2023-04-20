using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
using AltEevee;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace AltEevee.UpgradesKanto
{
    public class SharperPinsKanto : ModUpgrade<AltEevee.EeveeKanto>
    { 
        public override int Path => TOP;
        public override int Tier => 1;
        public override int Cost => 360; //140+220
        public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("MonkeyAce").GetUpgrade(BOTTOM, 1).icon;
        public override string Description => "Sharper pins can pop 4 Bloons each";
        public override string DisplayName => "Sharper Pins";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            projectile.pierce += 2;
        }
    }
    public class HarderPinsKanto : ModUpgrade<AltEevee.EeveeKanto>
    {
        public override int Path => TOP;
        public override int Tier => 2;
        public override int Cost => 600; //600
        public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("DartlingGunner").GetUpgrade(BOTTOM, 2).icon;
        public override string Description => "Harder pins pop 2 layers of Bloons at once.";
        public override string DisplayName => "Harder Pins";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            projectile.GetDamageModel().damage += 1;
            //projectile.GetDamageModel().damage += 1;
            //projectile.GetDamageModel().damage += 1;
        }
    }
    public class FasterThrowingKanto : ModUpgrade<AltEevee.EeveeKanto>
    {
        public override int Path => MIDDLE;
        public override int Tier => 1;
        public override int Cost => 100;
        public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("HeliPilot").GetUpgrade(BOTTOM, 2).icon;
        public override string Description => "Throws pins 15% faster.";
        public override string DisplayName => "Faster Throwing";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetWeapon().rate *= 0.85f;
        }
    }
    public class FasterPinsKanto : ModUpgrade<AltEevee.EeveeKanto>
    {
        public override int Path => MIDDLE;
        public override int Tier => 2;
        public override int Cost => 200;
        public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("HeliPilot").GetUpgrade(BOTTOM, 1).icon;
        public override string Description => "Throws pins 20% faster.";
        public override string DisplayName => "Faster Pins";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetWeapon().rate *= 0.80f;
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            //projectile.GetBehaviors<TravelStraitModel> = 2;
            towerModel.GetAttackModel().weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan *= 2;
        }
    }
    public class LongRangePinsKanto : ModUpgrade<AltEevee.EeveeKanto>
    {
        public override int Path => BOTTOM;
        public override int Tier => 1;
        public override int Cost => 100;
        public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("TackShooter").GetUpgrade(MIDDLE, 1).icon;
        public override string Description => "Throws pins 10 units farther.";
        public override string DisplayName => "Long Range Pins";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += 10;
            var attackModel = towerModel.GetAttackModel();
            attackModel.range += 10;
        }
    }
    public class LongerRangePinsKanto : ModUpgrade<AltEevee.EeveeKanto>
    {
        public override int Path => BOTTOM;
        public override int Tier => 2;
        public override int Cost => 225;
        public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("TackShooter").GetUpgrade(MIDDLE, 2).icon;
        public override string Description => "Throws pins another 10 units farther.";
        public override string DisplayName => "Longer Range Pins";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += 10;
            var attackModel = towerModel.GetAttackModel();
            attackModel.range += 10;
            //projectile.GetBehaviors<TravelStraitModel> = 2;
        }
    }
}