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
            //projectileModel.pierce += 2;
            attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("Gwendolin 6").GetAttackModel().weapons[0].projectile.Duplicate();
            //towerModel.GetWeapon().rate *= 0.5f;
            //attackModel.weapons[0].projectile.SetHitCamo(true);

            var projectile = attackModel.weapons[0].projectile;
            projectile.pierce = 2;
            projectile.GetDamageModel().damage = 2;

            //var fire = Game.instance.model.GetTower(TowerType.MortarMonkey, 2, 0, 2).GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.GetBehavior<AddBehaviorToBloonModel>();
            //towerModel.GetAttackModel().weapons[0].projectile.AddBehavior(fire);
            //towerModel.GetAttackModel().weapons[0].projectile.collisionPasses = new[] { 1, 0 };
            towerModel.ApplyDisplay<FlareonDisplay>();
        }
    }
    public class SunnyDay : ModUpgrade<AltEevee.EeveeKanto>
    {
        // Copyed from the Mad Scientist mod, lol
        //public override string DisplayName => "Sunny Day";
        public override string Description => "Creates pills to make all towers in its range gain more attack speed and can damage every Bloon";
        public override int Cost => 3500;
        public override int Path => MIDDLE;
        public override int Tier => 4;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            ///
            //var AcidicMixtureModel = new AcidicMixtureModel("FlareonAcidicMixtureBuff"); //gain more attack speed
            //new Il2CppReferenceArray<TowerFilterModel>(0), "", "");
            //AcidicMixtureModel.ApplyBuffIcon<ScientistBuffIcon>();
            //towerModel.AddBehavior(AcidicMixtureModel);
            var ignoreList = "BananaFarm,Pontoon,PortableLake,Alchemist,NaturesWardTotem,BananaFarmer,Benjamin,EnergisingTotem,TechBot,MonkeyVillage,Etienne,Psi";
            //towerModel.RemoveBehavior<AttackModel>();
            var attackModel = towerModel.GetAttackModel();

            //attackModel.AddWeapon(Game.instance.model.GetTowerFromId("Alchemist-200").GetAttackModel().weapons[1].GetBehavior<AcidicMixture>());
            attackModel.AddWeapon(Game.instance.model.GetTowerFromId("TackShooter-400").GetAttackModel().weapons[0].Duplicate());

            //attackModel.AddBehavior<AcidicMixture>(Game.instance.model.GetTowerFromId("Alchemist-200").GetAttackModel().weapons[1].GetBehavior<AcidicMixture>());
            //var projectile1 = attackModel.weapons[1].projectile;
            //projectile1.pierce = 1;

            //
            //
            var pierceSupportModel = new PierceSupportModel("PierceSupportModel_Flareon", true, 1, "HeatItUp: Pierce PierceUp",
            new Il2CppReferenceArray<TowerFilterModel>(0), false, "HeatItUpBuff", "BuffIconGwendolin");
            //var rateSupportModel = new RateSupportModel("RateSupportModel_Flareon", .50f, true, Id, false, 0,
            //new Il2CppReferenceArray<TowerFilterModel>(0), "HeatItUpBuff", "");
            var support = new DamageTypeSupportModel("DamageTypeSupportModel_Flareon", true, Id, BloonProperties.None,
            new Il2CppReferenceArray<TowerFilterModel>(0), "AcidicMixtureBuff", "");
            support.ApplyBuffIcon<ScientistBuffIcon>();
            towerModel.AddBehavior(support);
            //rateSupportModel.ApplyBuffIcon<BuffIconGwendolinPyrotechnics>();
            towerModel.AddBehavior(pierceSupportModel);
            //towerModel.AddBehavior(damageSupportModel);

            //Wrong Gwendolin Buff bruh
            //var support = new PyrotechnicsSupportModel("PyrotechnicsSupportModel_Flareon", 0.1f, true, "PyrotechnicsSupport", 0,
            //new Il2CppReferenceArray<TowerFilterModel>(0), "BuffIconGwendolinPyrotechnics", "BuffIconGwendolinPyrotechnics");
            ////support.ApplyBuffIcon<ScientistBuffIcon>();
            //towerModel.AddBehavior(support);


            //towerModel.GetBehavior<AttackModel>().weapons[1].projectile.GetDamageModel().damage = 1;
            //projectile1.GetDamageModel().damage = 0;
            //attackModel.weapons[1].AddBehavior(new AcidicMixtureModel("Flareon_AcidicMixtureModel"));
            //var targetFriendlyModel = new Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.TargetFriendlyModel("TargetFriendlyModel_", ignoreList, false, false, "FlareonAcidicMixtureBuff", true);//gain more attack speed
            //new Il2CppReferenceArray<TowerFilterModel>(0), "", "");
            //AcidicMixtureModel.ApplyBuffIcon<ScientistBuffIcon>();
            //towerModel.AddBehavior(targetFriendlyModel);
            //var AcidSupport = new AcidicMixtureModel("AcidicMixtureModel"); //can damage every Bloon
            //new Il2CppReferenceArray<TowerFilterModel>(0), "", "");
            //AcidSupport.ApplyBuffIcon<ScientistBuffIcon>();
            //towerModel.AddBehavior(AcidSupport);
            //var support = new DamageTypeSupportModel("DamageTypeSupportModel_TempleBase", true, Id, BloonProperties.None, //can damage every Bloon
            //new Il2CppReferenceArray<TowerFilterModel>(0), "", "");
            //support.ApplyBuffIcon<ScientistBuffIcon>();
            //towerModel.AddBehavior(support);
            //var attackModel = towerModel.GetAttackModel();
            //var HeatProjectile = TowerBehaviorExt.GetTowerBehavior(Game.instance.model.GetTowerFromId("Gwendolin 4"),"BonusProjectileAfterIntervalModel").BonusProjectileAfterIntervalModel().weapons[1].projectile.Duplicate();
            //var HeatUpSupport = new BonusProjectileAfterIntervalModel("BonusProjectileAfterIntervalModel", 40, HeatProjectile);
            //attackModel.AddWeapon(Game.instance.model.GetTowerFromId("Gwendolin 4").GetAttackModel().weapons[0].Duplicate());
            ///
            //var PierceSupportModel = new PierceUpTowersModel("PierceUpModel_Flareon", 1f, 8, false, "HeatItUp:Pierce", 0, true, displayToAddPath: (PrefabReference)"""b720a719dc3097a4380702202c2dbe41""");
            //new Il2CppReferenceArray<TowerFilterModel>(0), "", "");
            //rateSupportModel.ApplyBuffIcon<ScientistBuffIcon>();
            //var DamageSupportModel = new HeatItUpDamageBuffModel("HeatItUpDamageBuff", 8, "HeatItUp: Damage", true, "HeatItUpBuff", "BuffIconGwendolin");
            //towerModel.AddBehavior(PierceSupportModel);
            //towerModel.AddBehavior(DamageSupportModel);
            //var support = new AcidicMixtureModel("AcidicMixtureModel_");
            //support.ApplyBuffIcon<ScientistBuffIcon>();
            //towerModel.AddBehavior(support);

        }

        public override string Icon => "MindAlteringSubstances-Icon";

        public override string Portrait => "";
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
