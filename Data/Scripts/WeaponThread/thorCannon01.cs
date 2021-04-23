using static WeaponThread.WeaponStructure;
using static WeaponThread.WeaponStructure.WeaponDefinition;
using static WeaponThread.WeaponStructure.WeaponDefinition.ModelAssignmentsDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.HardPointDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.HardPointDef.Prediction;
using static WeaponThread.WeaponStructure.WeaponDefinition.TargetingDef.BlockTypes;
using static WeaponThread.WeaponStructure.WeaponDefinition.TargetingDef.Threat;

namespace WeaponThread {   
    partial class Weapons {
        // Don't edit above this line
        WeaponDefinition thor_01_def => new WeaponDefinition {

            Assignments = new ModelAssignmentsDef 
            {
                MountPoints = new[] {
                    new MountPointDef {
                        SubtypeId = "thor_cannon_01",
                        AimPartId = "None",
                        MuzzlePartId = "MissileTurretBarrels",
                        AzimuthPartId = "MissileTurretBase1",
                        ElevationPartId = "MissileTurretBarrels",
                    },

                },
                Barrels = new [] {
                    "muzzle_missile_01",
					"muzzle_missile_02",

                },
            },
            Targeting = new TargetingDef  
            {
                Threats = new[] {
                    Grids,
                },
                SubSystems = new[] {
                    Thrust, Utility, Offense, Power, Production, Any,
                },
                ClosestFirst = true, // tries to pick closest targets first (blocks on grids, projectiles, etc...).
                MinimumDiameter = 3, // 0 = unlimited, Minimum radius of threat to engage.
                MaximumDiameter = 0, // 0 = unlimited, Maximum radius of threat to engage.
                TopTargets = 0, // 0 = unlimited, max number of top targets to randomize between.
                TopBlocks = 4, // 0 = unlimited, max number of blocks to randomize between
                StopTrackingSpeed = 1000, // do not track target threats traveling faster than this speed
            },
            HardPoint = new HardPointDef 
            {
                WeaponName = "HFC-635 THOR", // name of weapon in terminal
                DeviateShotAngle = 0.01f,
                AimingTolerance = 0.8f, // 0 - 180 firing angle
                AimLeadingPrediction = Advanced, // Off, Basic, Accurate, Advanced
                DelayCeaseFire = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).

                Ui = new UiDef {
                    RateOfFire = true,
                    DamageModifier = false,
                    ToggleGuidance = true,
                    EnableOverload =  false,
                },
                Ai = new AiDef {
                    TrackTargets = true,
                    TurretAttached = true,
                    TurretController = true,
                    PrimaryTracking = true,
                    LockOnFocus = false,
                },
                HardWare = new HardwareDef {
                    RotateRate = 0.002f,
                    ElevateRate = 0.003f,
                    MinAzimuth = -180,
                    MaxAzimuth = 180,
                    MinElevation = -35,
                    MaxElevation = 50,
                    FixedOffset = false,
                    InventorySize = 0.05f,
                    Offset = Vector(x: 0, y: 0, z: 0),
                },
                Other = new OtherDef {
                    GridWeaponCap = 0,
                    RotateBarrelAxis = 0,
                    EnergyPriority = 0,
                    MuzzleCheck = false,
                    Debug = false,
                },
                Loading = new LoadingDef {
                    RateOfFire = 35,
                    BarrelSpinRate = 0, // visual only, 0 disables and uses RateOfFire
                    BarrelsPerShot = 1,
                    TrajectilesPerBarrel = 1, // Number of Trajectiles per barrel per fire event.
                    SkipBarrels = 0,
                    ReloadTime = 100, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    DelayUntilFire = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    HeatPerShot = 1000, //heat generated per shot
                    MaxHeat = 3000, //max heat before weapon enters cooldown (70% of max heat)
                    Cooldown = .50f, //percent of max heat to be under to start firing again after overheat accepts .2-.95
                    HeatSinkRate = 300, //amount of heat lost per second
                    DegradeRof = false, // progressively lower rate of fire after 80% heat threshold (80% of max heat)
                    ShotsInBurst = 0,
                    DelayAfterBurst = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    FireFullBurst = false,
                },
                Audio = new HardPointAudioDef {
                    PreFiringSound = "",
                    FiringSound = "ArcThorFireNormal", // WepShipGatlingShot
                    FiringSoundPerShot = true,
                    ReloadSound = "",
                    NoAmmoSound = "",
                    HardPointRotationSound = "WepTurretGatlingRotate",
                    BarrelRotationSound = "WepShipGatlingRotation",
                },
                Graphics = new HardPointParticleDef {

                    Barrel1 = new ParticleDef {
                        Name = "Railgunmuzzleflash_NW", // Smoke_LargeGunShot
                        Color = Color(red: 255, green: 155, blue: 51, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),

                        Extras = new ParticleOptionDef {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 300,
                            MaxDuration = 10,
                            Scale = 1.5f,
                        },
                    },
                    Barrel2 = new ParticleDef {
                        Name = "Railgunmuzzlesparks_NW",//Muzzle_Flash_Large
                        Color = Color(red: 10, green: 0, blue: 0, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),

                        Extras = new ParticleOptionDef {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 150,
                            MaxDuration = 15,
                            Scale = 0.4f,
                        },
                    },
                },
            },
            Ammos = new [] {
                thor635ammo,
				thorShrapneldef

            },
            //Animations = thorCannon01_anim,
            // Don't edit below this line
        };
    }
}
