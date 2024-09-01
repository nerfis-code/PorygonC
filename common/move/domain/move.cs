using System;
using System.Collections.Generic;
using System.IO;
using Utf8Json;

namespace PorygonC.Domain
{
    public class Move{
        public MoveKey Key { set; get; }
        public string Name { set; get; }
        public Type Type { set; get; }
        public byte Power { set; get; }
        public byte Accuracy { set; get; }
        public byte TotalPP { set; get; }
        public byte PP { set; get; }
        public string Target { set; get; }
        public byte EffectChance { set; get; }
        public string[] Flags { set; get; }
        public string Description { set; get; }
        public string Category { set; get; }

        public Move(MoveKey moveKey){
            var txt = File.ReadAllText("Common/PBS/move.json");
            var dict = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(txt);
            var move = dict[(int)moveKey];

            Key = Enum.TryParse((string)move["Key"], out MoveKey m)? m : MoveKey.NONE;
            Type = Enum.TryParse((string)move["Key"], out Type t)? t : Type.UNKNOWN;
            
            Name = (string)move["Name"];
            Target = (string)move["Target"];
            Description = (string)move["Description"];
            Category = (string)move["Category"];
            
            Power = (byte)(double)move["Power"];
            Accuracy = (byte)(double)move["Accuracy"];
            TotalPP = (byte)(double)move["TotalPP"];
            PP = TotalPP;
            EffectChance = (byte)(double)move["EffectChance"];

        }

    }
    public enum MoveKey
    {
        NONE = -1,
        MEGAHORN,
        ATTACKORDER,
        BUGBUZZ,
        FIRSTIMPRESSION,
        POLLENPUFF,
        LEECHLIFE,
        LUNGE,
        XSCISSOR,
        SIGNALBEAM,
        SKITTERSMACK,
        UTURN,
        STEAMROLLER,
        BUGBITE,
        SILVERWIND,
        FELLSTINGER,
        STRUGGLEBUG,
        FURYCUTTER,
        PINMISSILE,
        TWINEEDLE,
        INFESTATION,
        DEFENDORDER,
        HEALORDER,
        POWDER,
        QUIVERDANCE,
        RAGEPOWDER,
        SPIDERWEB,
        STICKYWEB,
        STRINGSHOT,
        TAILGLOW,
        HYPERSPACEFURY,
        FOULPLAY,
        FIERYWRATH,
        DARKESTLARIAT,
        NIGHTDAZE,
        CRUNCH,
        DARKPULSE,
        FALSESURRENDER,
        JAWLOCK,
        THROATCHOP,
        WICKEDBLOW,
        LASHOUT,
        NIGHTSLASH,
        SUCKERPUNCH,
        KNOCKOFF,
        ASSURANCE,
        BITE,
        BRUTALSWING,
        FEINTATTACK,
        THIEF,
        SNARL,
        PAYBACK,
        PURSUIT,
        BEATUP,
        FLING,
        POWERTRIP,
        PUNISHMENT,
        DARKVOID,
        EMBARGO,
        FAKETEARS,
        FLATTER,
        HONECLAWS,
        MEMENTO,
        NASTYPLOT,
        OBSTRUCT,
        PARTINGSHOT,
        QUASH,
        SNATCH,
        SWITCHEROO,
        TAUNT,
        TOPSYTURVY,
        TORMENT,
        ETERNABEAM,
        DRAGONENERGY,
        ROAROFTIME,
        DRACOMETEOR,
        OUTRAGE,
        CLANGINGSCALES,
        COREENFORCER,
        DRAGONRUSH,
        DYNAMAXCANNON,
        SPACIALREND,
        DRAGONHAMMER,
        DRAGONPULSE,
        DRAGONCLAW,
        BREAKINGSWIPE,
        DRAGONBREATH,
        DRAGONTAIL,
        DRAGONDARTS,
        DUALCHOP,
        TWISTER,
        SCALESHOT,
        DRAGONRAGE,
        CLANGOROUSSOUL,
        DRAGONDANCE,
        BOLTSTRIKE,
        VOLTTACKLE,
        ZAPCANNON,
        AURAWHEEL,
        THUNDER,
        FUSIONBOLT,
        PLASMAFISTS,
        THUNDERBOLT,
        WILDCHARGE,
        BOLTBEAK,
        DISCHARGE,
        OVERDRIVE,
        THUNDERCAGE,
        ZINGZAP,
        THUNDERPUNCH,
        RISINGVOLTAGE,
        VOLTSWITCH,
        PARABOLICCHARGE,
        SPARK,
        THUNDERFANG,
        SHOCKWAVE,
        ELECTROWEB,
        CHARGEBEAM,
        THUNDERSHOCK,
        NUZZLE,
        ELECTROBALL,
        CHARGE,
        EERIEIMPULSE,
        ELECTRICTERRAIN,
        ELECTRIFY,
        IONDELUGE,
        MAGNETRISE,
        MAGNETICFLUX,
        THUNDERWAVE,
        LIGHTOFRUIN,
        FLEURCANNON,
        MISTYEXPLOSION,
        MOONBLAST,
        PLAYROUGH,
        STRANGESTEAM,
        DAZZLINGGLEAM,
        SPIRITBREAK,
        DRAININGKISS,
        DISARMINGVOICE,
        FAIRYWIND,
        NATURESMADNESS,
        AROMATICMIST,
        BABYDOLLEYES,
        CHARM,
        CRAFTYSHIELD,
        DECORATE,
        FAIRYLOCK,
        FLORALHEALING,
        FLOWERSHIELD,
        GEOMANCY,
        MISTYTERRAIN,
        MOONLIGHT,
        SWEETKISS,
        FOCUSPUNCH,
        METEORASSAULT,
        HIGHJUMPKICK,
        CLOSECOMBAT,
        FOCUSBLAST,
        SUPERPOWER,
        CROSSCHOP,
        DYNAMICPUNCH,
        FLYINGPRESS,
        HAMMERARM,
        JUMPKICK,
        SACREDSWORD,
        THUNDEROUSKICK,
        SECRETSWORD,
        SKYUPPERCUT,
        AURASPHERE,
        BODYPRESS,
        SUBMISSION,
        BRICKBREAK,
        DRAINPUNCH,
        VITALTHROW,
        WAKEUPSLAP,
        LOWSWEEP,
        CIRCLETHROW,
        FORCEPALM,
        REVENGE,
        ROLLINGKICK,
        STORMTHROW,
        KARATECHOP,
        MACHPUNCH,
        POWERUPPUNCH,
        ROCKSMASH,
        VACUUMWAVE,
        DOUBLEKICK,
        ARMTHRUST,
        TRIPLEKICK,
        COUNTER,
        FINALGAMBIT,
        LOWKICK,
        REVERSAL,
        SEISMICTOSS,
        BULKUP,
        COACHING,
        DETECT,
        MATBLOCK,
        NORETREAT,
        OCTOLOCK,
        QUICKGUARD,
        VCREATE,
        BLASTBURN,
        ERUPTION,
        MINDBLOWN,
        SHELLTRAP,
        BLUEFLARE,
        BURNUP,
        OVERHEAT,
        FLAREBLITZ,
        PYROBALL,
        FIREBLAST,
        FUSIONFLARE,
        INFERNO,
        MAGMASTORM,
        SACREDFIRE,
        SEARINGSHOT,
        HEATWAVE,
        FLAMETHROWER,
        BLAZEKICK,
        FIERYDANCE,
        FIRELASH,
        FIREPLEDGE,
        LAVAPLUME,
        FIREPUNCH,
        MYSTICALFIRE,
        BURNINGJEALOUSY,
        FLAMEBURST,
        FIREFANG,
        FLAMEWHEEL,
        INCINERATE,
        FLAMECHARGE,
        EMBER,
        FIRESPIN,
        HEATCRASH,
        SUNNYDAY,
        WILLOWISP,
        SKYATTACK,
        BRAVEBIRD,
        DRAGONASCENT,
        HURRICANE,
        AEROBLAST,
        BEAKBLAST,
        FLY,
        BOUNCE,
        DRILLPECK,
        OBLIVIONWING,
        AIRSLASH,
        CHATTER,
        AERIALACE,
        AIRCUTTER,
        PLUCK,
        SKYDROP,
        WINGATTACK,
        ACROBATICS,
        DUALWINGBEAT,
        GUST,
        PECK,
        DEFOG,
        FEATHERDANCE,
        MIRRORMOVE,
        ROOST,
        TAILWIND,
        ASTRALBARRAGE,
        SHADOWFORCE,
        POLTERGEIST,
        MOONGEISTBEAM,
        PHANTOMFORCE,
        SPECTRALTHIEF,
        SHADOWBONE,
        SHADOWBALL,
        SPIRITSHACKLE,
        SHADOWCLAW,
        HEX,
        OMINOUSWIND,
        SHADOWPUNCH,
        SHADOWSNEAK,
        ASTONISH,
        LICK,
        NIGHTSHADE,
        CONFUSERAY,
        CURSE,
        DESTINYBOND,
        GRUDGE,
        NIGHTMARE,
        SPITE,
        TRICKORTREAT,
        FRENZYPLANT,
        LEAFSTORM,
        SOLARBLADE,
        PETALDANCE,
        POWERWHIP,
        SEEDFLARE,
        SOLARBEAM,
        WOODHAMMER,
        ENERGYBALL,
        LEAFBLADE,
        PETALBLIZZARD,
        APPLEACID,
        DRUMBEATING,
        GRASSPLEDGE,
        GRAVAPPLE,
        SEEDBOMB,
        GIGADRAIN,
        HORNLEECH,
        GRASSYGLIDE,
        TROPKICK,
        LEAFTORNADO,
        MAGICALLEAF,
        NEEDLEARM,
        RAZORLEAF,
        VINEWHIP,
        BRANCHPOKE,
        LEAFAGE,
        MEGADRAIN,
        SNAPTRAP,
        BULLETSEED,
        ABSORB,
        GRASSKNOT,
        AROMATHERAPY,
        COTTONGUARD,
        COTTONSPORE,
        FORESTSCURSE,
        GRASSWHISTLE,
        GRASSYTERRAIN,
        INGRAIN,
        JUNGLEHEALING,
        LEECHSEED,
        SLEEPPOWDER,
        SPIKYSHIELD,
        SPORE,
        STRENGTHSAP,
        STUNSPORE,
        SYNTHESIS,
        WORRYSEED,
        PRECIPICEBLADES,
        EARTHQUAKE,
        HIGHHORSEPOWER,
        EARTHPOWER,
        LANDSWRATH,
        THOUSANDARROWS,
        THOUSANDWAVES,
        DIG,
        DRILLRUN,
        STOMPINGTANTRUM,
        SCORCHINGSANDS,
        BONECLUB,
        MUDBOMB,
        BULLDOZE,
        MUDSHOT,
        BONEMERANG,
        SANDTOMB,
        BONERUSH,
        MUDSLAP,
        FISSURE,
        MAGNITUDE,
        MUDSPORT,
        ROTOTILLER,
        SANDATTACK,
        SHOREUP,
        SPIKES,
        FREEZESHOCK,
        ICEBURN,
        GLACIALLANCE,
        BLIZZARD,
        ICEHAMMER,
        ICEBEAM,
        ICICLECRASH,
        ICEPUNCH,
        FREEZEDRY,
        AURORABEAM,
        GLACIATE,
        ICEFANG,
        AVALANCHE,
        FROSTBREATH,
        ICYWIND,
        ICESHARD,
        POWDERSNOW,
        ICEBALL,
        ICICLESPEAR,
        TRIPLEAXEL,
        SHEERCOLD,
        AURORAVEIL,
        HAIL,
        HAZE,
        MIST,
        EXPLOSION,
        SELFDESTRUCT,
        GIGAIMPACT,
        HYPERBEAM,
        BOOMBURST,
        LASTRESORT,
        SKULLBASH,
        DOUBLEEDGE,
        HEADCHARGE,
        MEGAKICK,
        MULTIATTACK,
        TECHNOBLAST,
        THRASH,
        EGGBOMB,
        JUDGMENT,
        HYPERVOICE,
        REVELATIONDANCE,
        ROCKCLIMB,
        TAKEDOWN,
        UPROAR,
        BODYSLAM,
        EXTREMESPEED,
        HYPERFANG,
        MEGAPUNCH,
        RAZORWIND,
        SLAM,
        STRENGTH,
        TRIATTACK,
        CRUSHCLAW,
        RELICSONG,
        CHIPAWAY,
        DIZZYPUNCH,
        FACADE,
        HEADBUTT,
        RETALIATE,
        SECRETPOWER,
        SLASH,
        SMELLINGSALTS,
        HORNATTACK,
        STOMP,
        COVET,
        HIDDENPOWER,
        ROUND,
        SWIFT,
        VISEGRIP,
        CUT,
        RAPIDSPIN,
        SNORE,
        TERRAINPULSE,
        WEATHERBALL,
        ECHOEDVOICE,
        FAKEOUT,
        FALSESWIPE,
        HOLDBACK,
        PAYDAY,
        POUND,
        QUICKATTACK,
        SCRATCH,
        TACKLE,
        DOUBLEHIT,
        FEINT,
        TAILSLAP,
        RAGE,
        SPIKECANNON,
        COMETPUNCH,
        FURYSWIPES,
        BARRAGE,
        BIND,
        DOUBLESLAP,
        FURYATTACK,
        WRAP,
        CONSTRICT,
        BIDE,
        CRUSHGRIP,
        ENDEAVOR,
        FLAIL,
        FRUSTRATION,
        GUILLOTINE,
        HORNDRILL,
        NATURALGIFT,
        PRESENT,
        RETURN,
        SONICBOOM,
        SPITUP,
        SUPERFANG,
        TRUMPCARD,
        WRINGOUT,
        ACUPRESSURE,
        AFTERYOU,
        ASSIST,
        ATTRACT,
        BATONPASS,
        BELLYDRUM,
        BESTOW,
        BLOCK,
        CAMOUFLAGE,
        CAPTIVATE,
        CELEBRATE,
        CONFIDE,
        CONVERSION,
        CONVERSION2,
        COPYCAT,
        COURTCHANGE,
        DEFENSECURL,
        DISABLE,
        DOUBLETEAM,
        ENCORE,
        ENDURE,
        ENTRAINMENT,
        FLASH,
        FOCUSENERGY,
        FOLLOWME,
        FORESIGHT,
        GLARE,
        GROWL,
        GROWTH,
        HAPPYHOUR,
        HARDEN,
        HEALBELL,
        HELPINGHAND,
        HOLDHANDS,
        HOWL,
        LASERFOCUS,
        LEER,
        LOCKON,
        LOVELYKISS,
        LUCKYCHANT,
        MEFIRST,
        MEANLOOK,
        METRONOME,
        MILKDRINK,
        MIMIC,
        MINDREADER,
        MINIMIZE,
        MORNINGSUN,
        NATUREPOWER,
        NOBLEROAR,
        ODORSLEUTH,
        PAINSPLIT,
        PERISHSONG,
        PLAYNICE,
        PROTECT,
        PSYCHUP,
        RECOVER,
        RECYCLE,
        REFLECTTYPE,
        REFRESH,
        ROAR,
        SAFEGUARD,
        SCARYFACE,
        SCREECH,
        SHARPEN,
        SHELLSMASH,
        SIMPLEBEAM,
        SING,
        SKETCH,
        SLACKOFF,
        SLEEPTALK,
        SMOKESCREEN,
        SOFTBOILED,
        SPLASH,
        SPOTLIGHT,
        STOCKPILE,
        STUFFCHEEKS,
        SUBSTITUTE,
        SUPERSONIC,
        SWAGGER,
        SWALLOW,
        SWEETSCENT,
        SWORDSDANCE,
        TAILWHIP,
        TEARFULLOOK,
        TEATIME,
        TEETERDANCE,
        TICKLE,
        TRANSFORM,
        WHIRLWIND,
        WISH,
        WORKUP,
        YAWN,
        BELCH,
        GUNKSHOT,
        SLUDGEWAVE,
        SHELLSIDEARM,
        SLUDGEBOMB,
        POISONJAB,
        CROSSPOISON,
        SLUDGE,
        VENOSHOCK,
        CLEARSMOG,
        POISONFANG,
        POISONTAIL,
        ACID,
        ACIDSPRAY,
        SMOG,
        POISONSTING,
        ACIDARMOR,
        BANEFULBUNKER,
        COIL,
        CORROSIVEGAS,
        GASTROACID,
        POISONGAS,
        POISONPOWDER,
        PURIFY,
        TOXIC,
        TOXICSPIKES,
        TOXICTHREAD,
        VENOMDRENCH,
        PRISMATICLASER,
        PSYCHOBOOST,
        FUTURESIGHT,
        SYNCHRONOISE,
        DREAMEATER,
        PHOTONGEYSER,
        PSYSTRIKE,
        FREEZINGGLARE,
        PSYCHIC,
        PSYCHICFANGS,
        EERIESPELL,
        EXPANDINGFORCE,
        EXTRASENSORY,
        HYPERSPACEHOLE,
        PSYSHOCK,
        ZENHEADBUTT,
        LUSTERPURGE,
        MISTBALL,
        PSYCHOCUT,
        PSYBEAM,
        HEARTSTAMP,
        CONFUSION,
        STOREDPOWER,
        MIRRORCOAT,
        PSYWAVE,
        AGILITY,
        ALLYSWITCH,
        AMNESIA,
        BARRIER,
        CALMMIND,
        COSMICPOWER,
        GRAVITY,
        GUARDSPLIT,
        GUARDSWAP,
        HEALBLOCK,
        HEALPULSE,
        HEALINGWISH,
        HEARTSWAP,
        HYPNOSIS,
        IMPRISON,
        INSTRUCT,
        KINESIS,
        LIGHTSCREEN,
        LUNARDANCE,
        MAGICCOAT,
        MAGICPOWDER,
        MAGICROOM,
        MEDITATE,
        MIRACLEEYE,
        POWERSPLIT,
        POWERSWAP,
        POWERTRICK,
        PSYCHICTERRAIN,
        PSYCHOSHIFT,
        REFLECT,
        REST,
        ROLEPLAY,
        SKILLSWAP,
        SPEEDSWAP,
        TELEKINESIS,
        TELEPORT,
        TRICK,
        TRICKROOM,
        WONDERROOM,
        HEADSMASH,
        ROCKWRECKER,
        METEORBEAM,
        DIAMONDSTORM,
        STONEEDGE,
        POWERGEM,
        ROCKSLIDE,
        ANCIENTPOWER,
        ROCKTOMB,
        ROCKTHROW,
        SMACKDOWN,
        ACCELEROCK,
        ROLLOUT,
        ROCKBLAST,
        ROCKPOLISH,
        SANDSTORM,
        STEALTHROCK,
        TARSHOT,
        WIDEGUARD,
        DOOMDESIRE,
        STEELBEAM,
        STEELROLLER,
        BEHEMOTHBASH,
        BEHEMOTHBLADE,
        IRONTAIL,
        SUNSTEELSTRIKE,
        METEORMASH,
        ANCHORSHOT,
        FLASHCANNON,
        IRONHEAD,
        SMARTSTRIKE,
        STEELWING,
        DOUBLEIRONBASH,
        MIRRORSHOT,
        MAGNETBOMB,
        GEARGRIND,
        METALCLAW,
        BULLETPUNCH,
        GYROBALL,
        HEAVYSLAM,
        METALBURST,
        AUTOTOMIZE,
        GEARUP,
        IRONDEFENSE,
        KINGSSHIELD,
        METALSOUND,
        SHIFTGEAR,
        HYDROCANNON,
        WATERSPOUT,
        HYDROPUMP,
        ORIGINPULSE,
        STEAMERUPTION,
        CRABHAMMER,
        AQUATAIL,
        MUDDYWATER,
        SPARKLINGARIA,
        SURF,
        FISHIOUSREND,
        LIQUIDATION,
        DIVE,
        SCALD,
        SNIPESHOT,
        WATERPLEDGE,
        WATERFALL,
        RAZORSHELL,
        BRINE,
        BUBBLEBEAM,
        OCTAZOOKA,
        FLIPTURN,
        WATERPULSE,
        AQUAJET,
        BUBBLE,
        WATERGUN,
        CLAMP,
        WHIRLPOOL,
        SURGINGSTRIKES,
        WATERSHURIKEN,
        AQUARING,
        LIFEDEW,
        RAINDANCE,
        SOAK,
        WATERSPORT,
        WITHDRAW,
        DIRECLAW,
        SPRINGTIDESTORM,
        RAGINGFURY,
        WAVECRASH,
        CHLOROBLAST,
        MOUNTAINGALE,
        HEADLONGRUSH,
        BARBBARRAGE,
        ESPERWING,
        BITTERMALICE,
        TRIPLEARROWS,
        BLEAKWINDSTORM,
        WILDBOLTSTORM,
        SANDSEARSTORM,
        LUNARBLESSING,
        PSYSHIELDBASH,
        POWERSHIFT,
        STONEAXE,
        MYSTICALPOWER,
        VICTORYDANCE,
        SHELTER,
        INFERNALPARADE,
        CEASELESSEDGE,
        TAKEHEART,
        AQUACUTTER,
        AQUASTEP,
        ARMORCANNON,
        AXEKICK,
        BITTERBLADE,
        BLAZINGTORQUE,
        CHILLINGWATER,
        CHILLYRECEPTION,
        COLLISIONCOURSE,
        COMBATTORQUE,
        COMEUPPANCE,
        DOODLE,
        DOUBLESHOCK,
        ELECTRODRIFT,
        FILLETAWAY,
        FLOWERTRICK,
        GIGATONHAMMER,
        GLAIVERUSH,
        HYPERDRILL,
        ICESPINNER,
        JETPUNCH,
        KOWTOWCLEAVE,
        LASTRESPECTS,
        LUMINACRASH,
        MAGICALTORQUE,
        MAKEITRAIN,
        MORTALSPIN,
        NOXIOUSTORQUE,
        ORDERUP,
        POPULATIONBOMB,
        POUNCE,
        RAGEFIST,
        RAGINGBULL,
        REVIVALBLESSING,
        RUINATION,
        SALTCURE,
        SHEDTAIL,
        SILKTRAP,
        SNOWSCAPE,
        SPICYEXTRACT,
        SPINOUT,
        TIDYUP,
        TORCHSONG,
        TRAILBLAZE,
        TRIPLEDIVE,
        TWINBEAM,
        WICKEDTORQUE,
        HYDROSTEAM,
        PSYBLADE,
        BLOODMOON,
        MATCHAGOTCHA,
        SYRUPBOMB,
        IVYCUDGEL,
        ELECTROSHOT,
        TERASTARSTORM,
        FICKLEBEAM,
        BURNINGBULWARK,
        THUNDERCLAP,
        MIGHTYCLEAVE,
        TACHYONCUTTER,
        HARDPRESS,
        DRAGONCHEER,
        ALLURINGVOICE,
        TEMPERFLARE,
        SUPERCELLSLAM,
        PSYCHICNOISE,
        UPPERHAND,
        MALIGNANTCHAIN
    }

}