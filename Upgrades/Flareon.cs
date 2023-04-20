using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.TowerFilters;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using ScientistBuff;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Simulation.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;

namespace AltEevee.Upgrades
{
    public class Flareon : ModUpgrade<AltEevee.EeveeKanto>
    {
        public override int Path => MIDDLE;
        public override int Tier => 3;
        public override int Cost => 825; //725-200+300
        public override string Portrait => "FlareonPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("WizardMonkey-010").GetUpgrade(MIDDLE, 1).icon;
        public override int Priority => 10; 
        public override string Description => "Evolving Eevee to Flareon and increases the attack speed and pierce";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel(); 
            var projectileModel = attackModel.GetDescendant<ProjectileModel>();
            //attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("Gwendolin 6").GetAttackModel().weapons[0].projectile.Duplicate();



            var projectile = attackModel.weapons[0].projectile;
            projectile.GetDamageModel().damage += 2;

            towerModel.ApplyDisplay<FlareonDisplay>();
        }
    }
    public class SunnyDay : ModUpgrade<AltEevee.EeveeKanto>
    {
        // Copyed from the Mad Scientist mod, lol
        //public override string DisplayName => "Sunny Day";
        public override string Description => "Creates pills to make all towers in its range gain more attack speed and can damage every Bloon";
        public override int Cost => 1350;
        public override int Path => MIDDLE;
        public override int Tier => 4;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            ///
            var attackModel = towerModel.GetAttackModel();
            //var AcidicMixtureModel = new AcidicMixtureModel("FlareonAcidicMixtureBuff"); //gain more attack speed
            var ignoreList = "BananaFarm,Pontoon,PortableLake,Alchemist,NaturesWardTotem,BananaFarmer,Benjamin,EnergisingTotem,TechBot,MonkeyVillage,Etienne,Psi"; //how to add flareon, but not other evolvions?
            towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Alchemist-200").GetAttackModel("AcidicMixture").Duplicate());
            var A = towerModel.GetAttackModel("AcidicMixture");
            //
            towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Alchemist-200").GetBehavior<CanBuffIndicatorModel>());
            //towerModel.GetAttackModel("AcidicMixture").RemoveBehavior<TargetFriendlyModel>();
            //towerModel.GetAttackModel("AcidicMixture").AddBehavior(new TargetFriendlyModel("HeatItUpBuff", ignoreList, false, false, "HeatItUpBuff", true));
            // NOTE: Flareon applies the Acidic Mixture Dip Buff to itself

            //attackModel.AddWeapon(Game.instance.model.GetTowerFromId("TackShooter-400").GetAttackModel().weapons[0].Duplicate());
            //towerModel.GetWeapons()[2].rate *= 10f;

        }

        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("BoomerangMonkey").GetUpgrade(BOTTOM, 2).icon;
    }
    public class FlareonDisplay:ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            NodeLoader.NodeLoader.LoadNode(node, "Flareon", mod);
        }
    }
}
