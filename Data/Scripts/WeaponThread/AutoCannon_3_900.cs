using System.Collections.Generic;
using static WeaponThread.WeaponStructure;
using static WeaponThread.WeaponStructure.WeaponDefinition;
using static WeaponThread.WeaponStructure.WeaponDefinition.HardPointDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.ModelAssignmentsDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.HardPointDef.HardwareDef.ArmorState;
using static WeaponThread.WeaponStructure.WeaponDefinition.HardPointDef.Prediction;
using static WeaponThread.WeaponStructure.WeaponDefinition.TargetingDef.BlockTypes;
using static WeaponThread.WeaponStructure.WeaponDefinition.TargetingDef.Threat;

namespace WeaponThread
{   // Don't edit above this line
    partial class Weapons
    {
        WeaponDefinition AutoCannon_3_900 => new WeaponDefinition {

            Assignments = new ModelAssignmentsDef 
            {
                MountPoints = new[] {
                    new MountPointDef {
                        SubtypeId = "AutoCannon_3_900",
                        AimPartId = "None",
                        MuzzlePartId = "MissileTurretBarrels",
                        AzimuthPartId = "MissileTurretBase1",
                        ElevationPartId = "MissileTurretBarrels",
                        DurabilityMod = 1f,
                        IconName = ""
                    },
                },
                Barrels = new [] {
                    "muzzle_missile_001",
                    "muzzle_missile_002",
                    "muzzle_missile_003",
                },
                Ejector = "",
                Scope = "", //Where line of sight checks are performed from must be clear of block collision
            },
            Targeting = new TargetingDef  
            {
                Threats = new[] {
                    Grids, Meteors,
                },
                SubSystems = new[] {
                    Thrust, Utility, Offense, Power, Production, Any,
                },
                ClosestFirst = false, // tries to pick closest targets first (blocks on grids, projectiles, etc...).
                IgnoreDumbProjectiles = false, // Don't fire at non-smart projectiles.
                LockedSmartOnly = false, // Only fire at smart projectiles that are locked on to parent grid.
                MinimumDiameter = 0, // 0 = unlimited, Minimum radius of threat to engage.
                MaximumDiameter = 0, // 0 = unlimited, Maximum radius of threat to engage.
                MaxTargetDistance = 0, // 0 = unlimited, Maximum target distance that targets will be automatically shot at.
                MinTargetDistance = 0, // 0 = unlimited, Min target distance that targets will be automatically shot at.
                TopTargets = 4, // 0 = unlimited, max number of top targets to randomize between.
                TopBlocks = 4, // 0 = unlimited, max number of blocks to randomize between
                StopTrackingSpeed = 1000, // do not track target threats traveling faster than this speed
            },
            HardPoint = new HardPointDef 
            {
                WeaponName = "3x900mm Auto Cannon", // name of weapon in terminal
                DeviateShotAngle = 0.1f,
                AimingTolerance = 3f, // 0 - 180 firing angle
                AimLeadingPrediction = Accurate, // Off, Basic, Accurate, Advanced
                DelayCeaseFire = 10, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                AddToleranceToTracking = false,
                CanShootSubmerged = true,

                Ui = new UiDef {
                    RateOfFire = false,
                    DamageModifier = false,
                    ToggleGuidance = false,
                    EnableOverload =  false,
                },
                Ai = new AiDef {
                    TrackTargets = true,
                    TurretAttached = true,
                    TurretController = true,
                    PrimaryTracking = true,
                    LockOnFocus = true,
                    SuppressFire = false,
                },
                HardWare = new HardwareDef {
                    RotateRate = 0.01f,
                    ElevateRate = 0.01f,
                    MinAzimuth = -180,
                    MaxAzimuth = 180,
                    MinElevation = -10,
                    MaxElevation = 50,
                    FixedOffset = false,
                    InventorySize = 5f,
                    Offset = Vector(x: 0, y: 0, z: 0),
                    Armor = IsWeapon, // IsWeapon, Passive, Active
                },
                Other = new OtherDef {
                    GridWeaponCap = 3,
                    RotateBarrelAxis = 0,
                    EnergyPriority = 0,
                    MuzzleCheck = false,
                    Debug = false,
                    RestrictionRadius = 0, // Meters, radius of sphere disable this gun if another is present
                    CheckInflatedBox = false, // if true, the bounding box of the gun is expanded by the RestrictionRadius
                    CheckForAnyWeapon = false, // if true, the check will fail if ANY gun is present, false only looks for this subtype
                },
                Loading = new LoadingDef {
                    RateOfFire = 24, // visual only, 0 disables and uses RateOfFire
                    BarrelsPerShot = 1,
                    TrajectilesPerBarrel = 1, // Number of Trajectiles per barrel per fire event.
                    SkipBarrels = 0,
                    ReloadTime = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    DelayUntilFire = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    HeatPerShot = 0, //heat generated per shot
                    MaxHeat = 0, //max heat before weapon enters cooldown (70% of max heat)
                    Cooldown = 0, //percent of max heat to be under to start firing again after overheat accepts .2-.95
                    HeatSinkRate = 0, //amount of heat lost per second
                    DegradeRof = false, // progressively lower rate of fire after 80% heat threshold (80% of max heat)
                    ShotsInBurst = 0,
                    DelayAfterBurst = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    FireFullBurst = false,
                    GiveUpAfterBurst = false,
                    BarrelSpinRate = 0, // visual only, 0 disables and uses RateOfFire
                    DeterministicSpin = false, // Spin barrel position will always be relative to initial / starting positions (spin will not be as smooth).
                },
                Audio = new HardPointAudioDef {
                    PreFiringSound = "",
                    FiringSound = "900mmCannon", // WepShipGatlingShot
                    FiringSoundPerShot = true,
                    ReloadSound = "",
                    NoAmmoSound = "WepPlayRifleNoAmmo",
                    HardPointRotationSound = "WepTurretGatlingRotate",
                    BarrelRotationSound = "",
                    FireSoundEndDelay = 120, // Measured in game ticks(6 = 100ms, 60 = 1 seconds, etc..).
                },
                Graphics = new HardPointParticleDef {

                    Barrel1 = new ParticleDef {
                        Name = "", // Smoke_LargeGunShot
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),

                        Extras = new ParticleOptionDef {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 200,
                            MaxDuration = 2,
                            Scale = 1f,
                        },
                    },
                    Barrel2 = new ParticleDef {
                        Name = "",//Muzzle_Flash_Large
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),

                        Extras = new ParticleOptionDef {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 200,
                            MaxDuration = 2,
                            Scale = 1f,
                        },
                    },
                },
            },
            Ammos = new [] {
                Autocannon900Ammo_HE,
                Autocannon900Ammo_AP
            },
            //Animations = AdvancedAnimation,
            //Upgrades = UpgradeModules,
            // Don't edit below this line
        };
    }
}
