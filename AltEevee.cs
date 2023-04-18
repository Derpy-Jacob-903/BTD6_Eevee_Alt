using MelonLoader;
using BTD_Mod_Helper;
using AltEevee;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using BTD_Mod_Helper.Api.Display;
using NodeLoader;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;

[assembly: MelonInfo(typeof(AltEevee.Main), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace AltEevee
{
    public class Main : BloonsTD6Mod
    {
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("AltEevee loaded!");
        }
    }

    public class EeveeJohto : ModTower //Espeon-Sylveon-Umbreon
    {
        public override TowerSet TowerSet => TowerSet.Magic;
        public override string Name => "EeveeJohto";
        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 600; //200+400
        public override string Portrait => "Eevee-Portrait";

        public override int TopPathUpgrades => 4;
        public override int MiddlePathUpgrades => 2;
        public override int BottomPathUpgrades => 3;
        public override string Description => "A Pokemon-tower with several Evolutions";

        public override string DisplayName => "Johto Eevee";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            //towerModel.range += 10;
            var attackModel = towerModel.GetAttackModel();
            //attackModel.range += 10;

            var projectile = attackModel.weapons[0].projectile;
            projectile = Game.instance.model.GetTowerFromId("Druid").GetAttackModel().weapons[0].projectile.Duplicate();
            projectile.pierce = 2;
            //towerModel.GetBehavior<AttackModel>().weapons[0].projectile.GetDamageModel().damage += 1;
            projectile.GetDamageModel().damage = 1;
            //projectile.pierce += 2;
            towerModel.GetWeapon().emission = new ArcEmissionModel("ArcEmissionModel_", 3, 0, 30, null, false);
            towerModel.ApplyDisplay<EeveeDisplay>();
        }
        
    }
    public class EeveeKanto : ModTower //Jolteon-Flareeon-Vaporeon
    {
        public override TowerSet TowerSet => TowerSet.Magic;
        public override string Name => "EeveeKanto";
        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 600;
        public override string Portrait => "Eevee-Portrait";

        public override int TopPathUpgrades => 4;
        public override int MiddlePathUpgrades => 4;
        public override int BottomPathUpgrades => 3;
        public override string Description => "A Pokemon-tower with several Evolutions";

        public override string DisplayName => "Kanto Eevee";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            //towerModel.range += 10;
            var attackModel = towerModel.GetAttackModel();
            //attackModel.range += 10;

            var projectile = attackModel.weapons[0].projectile;
            projectile = Game.instance.model.GetTowerFromId("Druid").GetAttackModel().weapons[0].projectile.Duplicate();
            projectile.pierce = 2;
            //towerModel.GetBehavior<AttackModel>().weapons[0].projectile.GetDamageModel().damage += 1;
            projectile.GetDamageModel().damage = 1;
            //projectile.pierce += 2;
            towerModel.GetWeapon().emission = new ArcEmissionModel("ArcEmissionModel_", 3, 0, 30, null, false);
            towerModel.ApplyDisplay<EeveeDisplay>();
        }
        
    }
    public class EeveeSinnoh : ModTower //Leafeon-Sylveon-Glaceon
    {
        public override TowerSet TowerSet => TowerSet.Magic;
        public override string Name => "EeveeSinnoh";
        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 600;
        public override string Portrait => "Eevee-Portrait";
        

        public override int TopPathUpgrades => 4;
        public override int MiddlePathUpgrades => 2;
        public override int BottomPathUpgrades => 3;
        public override string Description => "A Pokemon-tower with several Evolutions";

        public override string DisplayName => "Sinnoh Eevee";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            //towerModel.range += 10;
            var attackModel = towerModel.GetAttackModel();
            //attackModel.range += 10;

            var projectile = attackModel.weapons[0].projectile;
            projectile = Game.instance.model.GetTowerFromId("Druid").GetAttackModel().weapons[0].projectile.Duplicate();
            projectile.pierce = 2;
            //towerModel.GetBehavior<AttackModel>().weapons[0].projectile.GetDamageModel().damage += 1;
            projectile.GetDamageModel().damage = 1;
            //projectile.pierce += 2;
            towerModel.GetWeapon().emission = new ArcEmissionModel("ArcEmissionModel_", 3, 0, 30, null, false);
            towerModel.ApplyDisplay<EeveeDisplay>();
        }
        
    }

    //public class Region
    //{
    //    public string[] Cars = {"EeveeJohto", "EeveeKanto", "EeveeSinnoh"};
    //}

    public class EeveeDisplay : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            NodeLoader.NodeLoader.LoadNode(node, "Eevee", mod);
        }
    }
}

