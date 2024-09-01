
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Godot;
using PorygonC.Moves.Domain;
using PorygonC.Scenes.Domain;

namespace PorygonC.Pokemons.Domain
{
	public partial class Pokemon
	{
		public string Name { get; set; }
		public PokemonKey Key { get; set; }
		public short Ps { get; set; }
		public TypeKey Type1 { get; set; }
		public TypeKey Type2 { get; set; }
		public byte Level { get; set; }
		public ushort[] Stats { get; set; }
		public Move CurrMove { get; set; }
		public List<Move> Moves { get; set; }
		public bool IsDefeated { get; set; }
		public delegate Task task();
		public event task Defeated;
		public event task Received;
		public delegate Task _Info(string txt);
		public event _Info Send;

		public async Task Take(short received){
			Ps = (short)Math.Max(0,Ps -received);
			await Received?.Invoke();
			await Send?.Invoke(Name + " ha recibido " + received + " de damage ");
			//if(Ps == 0) await Defeated?.Invoke();
		}

		public async Task Attk(List<Pokemon> targets){
			await Send?.Invoke(Name + " ha realizado el movimiento " + CurrMove.Name);
			foreach (var target in targets)
			{
				await target.Take(CurrMove.Power);
			}
		}
	}


	public enum PokemonKey
	{
		MISSINGNO = -1,
		BULBASAUR,
		IVYSAUR,
		VENUSAUR,
		CHARMANDER,
		CHARMELEON,
		CHARIZARD,
		SQUIRTLE,
		WARTORTLE,
		BLASTOISE,
		CATERPIE,
		METAPOD,
		BUTTERFREE,
		WEEDLE,
		KAKUNA,
		BEEDRILL,
		PIDGEY,
		PIDGEOTTO,
		PIDGEOT,
		RATTATA,
		RATICATE,
		SPEAROW,
		FEAROW,
		EKANS,
		ARBOK,
		PIKACHU,
		RAICHU,
		SANDSHREW,
		SANDSLASH,
		NIDORANfE,
		NIDORINA,
		NIDOQUEEN,
		NIDORANmA,
		NIDORINO,
		NIDOKING,
		CLEFAIRY,
		CLEFABLE,
		VULPIX,
		NINETALES,
		JIGGLYPUFF,
		WIGGLYTUFF,
		ZUBAT,
		GOLBAT,
		ODDISH,
		GLOOM,
		VILEPLUME,
		PARAS,
		PARASECT,
		VENONAT,
		VENOMOTH,
		DIGLETT,
		DUGTRIO,
		MEOWTH,
		PERSIAN,
		PSYDUCK,
		GOLDUCK,
		MANKEY,
		PRIMEAPE,
		GROWLITHE,
		ARCANINE,
		POLIWAG,
		POLIWHIRL,
		POLIWRATH,
		ABRA,
		KADABRA,
		ALAKAZAM,
		MACHOP,
		MACHOKE,
		MACHAMP,
		BELLSPROUT,
		WEEPINBELL,
		VICTREEBEL,
		TENTACOOL,
		TENTACRUEL,
		GEODUDE,
		GRAVELER,
		GOLEM,
		PONYTA,
		RAPIDASH,
		SLOWPOKE,
		SLOWBRO,
		MAGNEMITE,
		MAGNETON,
		FARFETCHD,
		DODUO,
		DODRIO,
		SEEL,
		DEWGONG,
		GRIMER,
		MUK,
		SHELLDER,
		CLOYSTER,
		GASTLY,
		HAUNTER,
		GENGAR,
		ONIX,
		DROWZEE,
		HYPNO,
		KRABBY,
		KINGLER,
		VOLTORB,
		ELECTRODE,
		EXEGGCUTE,
		EXEGGUTOR,
		CUBONE,
		MAROWAK,
		HITMONLEE,
		HITMONCHAN,
		LICKITUNG,
		KOFFING,
		WEEZING,
		RHYHORN,
		RHYDON,
		CHANSEY,
		TANGELA,
		KANGASKHAN,
		HORSEA,
		SEADRA,
		GOLDEEN,
		SEAKING,
		STARYU,
		STARMIE,
		MRMIME,
		SCYTHER,
		JYNX,
		ELECTABUZZ,
		MAGMAR,
		PINSIR,
		TAUROS,
		MAGIKARP,
		GYARADOS,
		LAPRAS,
		DITTO,
		EEVEE,
		VAPOREON,
		JOLTEON,
		FLAREON,
		PORYGON,
		OMANYTE,
		OMASTAR,
		KABUTO,
		KABUTOPS,
		AERODACTYL,
		SNORLAX,
		ARTICUNO,
		ZAPDOS,
		MOLTRES,
		DRATINI,
		DRAGONAIR,
		DRAGONITE,
		MEWTWO,
		MEW,
		CHIKORITA,
		BAYLEEF,
		MEGANIUM,
		CYNDAQUIL,
		QUILAVA,
		TYPHLOSION,
		TOTODILE,
		CROCONAW,
		FERALIGATR,
		SENTRET,
		FURRET,
		HOOTHOOT,
		NOCTOWL,
		LEDYBA,
		LEDIAN,
		SPINARAK,
		ARIADOS,
		CROBAT,
		CHINCHOU,
		LANTURN,
		PICHU,
		CLEFFA,
		IGGLYBUFF,
		TOGEPI,
		TOGETIC,
		NATU,
		XATU,
		MAREEP,
		FLAAFFY,
		AMPHAROS,
		BELLOSSOM,
		MARILL,
		AZUMARILL,
		SUDOWOODO,
		POLITOED,
		HOPPIP,
		SKIPLOOM,
		JUMPLUFF,
		AIPOM,
		SUNKERN,
		SUNFLORA,
		YANMA,
		WOOPER,
		QUAGSIRE,
		ESPEON,
		UMBREON,
		MURKROW,
		SLOWKING,
		MISDREAVUS,
		UNOWN,
		WOBBUFFET,
		GIRAFARIG,
		PINECO,
		FORRETRESS,
		DUNSPARCE,
		GLIGAR,
		STEELIX,
		SNUBBULL,
		GRANBULL,
		QWILFISH,
		SCIZOR,
		SHUCKLE,
		HERACROSS,
		SNEASEL,
		TEDDIURSA,
		URSARING,
		SLUGMA,
		MAGCARGO,
		SWINUB,
		PILOSWINE,
		CORSOLA,
		REMORAID,
		OCTILLERY,
		DELIBIRD,
		MANTINE,
		SKARMORY,
		HOUNDOUR,
		HOUNDOOM,
		KINGDRA,
		PHANPY,
		DONPHAN,
		PORYGON2,
		STANTLER,
		SMEARGLE,
		TYROGUE,
		HITMONTOP,
		SMOOCHUM,
		ELEKID,
		MAGBY,
		MILTANK,
		BLISSEY,
		RAIKOU,
		ENTEI,
		SUICUNE,
		LARVITAR,
		PUPITAR,
		TYRANITAR,
		LUGIA,
		HOOH,
		CELEBI,
		TREECKO,
		GROVYLE,
		SCEPTILE,
		TORCHIC,
		COMBUSKEN,
		BLAZIKEN,
		MUDKIP,
		MARSHTOMP,
		SWAMPERT,
		POOCHYENA,
		MIGHTYENA,
		ZIGZAGOON,
		LINOONE,
		WURMPLE,
		SILCOON,
		BEAUTIFLY,
		CASCOON,
		DUSTOX,
		LOTAD,
		LOMBRE,
		LUDICOLO,
		SEEDOT,
		NUZLEAF,
		SHIFTRY,
		TAILLOW,
		SWELLOW,
		WINGULL,
		PELIPPER,
		RALTS,
		KIRLIA,
		GARDEVOIR,
		SURSKIT,
		MASQUERAIN,
		SHROOMISH,
		BRELOOM,
		SLAKOTH,
		VIGOROTH,
		SLAKING,
		NINCADA,
		NINJASK,
		SHEDINJA,
		WHISMUR,
		LOUDRED,
		EXPLOUD,
		MAKUHITA,
		HARIYAMA,
		AZURILL,
		NOSEPASS,
		SKITTY,
		DELCATTY,
		SABLEYE,
		MAWILE,
		ARON,
		LAIRON,
		AGGRON,
		MEDITITE,
		MEDICHAM,
		ELECTRIKE,
		MANECTRIC,
		PLUSLE,
		MINUN,
		VOLBEAT,
		ILLUMISE,
		ROSELIA,
		GULPIN,
		SWALOT,
		CARVANHA,
		SHARPEDO,
		WAILMER,
		WAILORD,
		NUMEL,
		CAMERUPT,
		TORKOAL,
		SPOINK,
		GRUMPIG,
		SPINDA,
		TRAPINCH,
		VIBRAVA,
		FLYGON,
		CACNEA,
		CACTURNE,
		SWABLU,
		ALTARIA,
		ZANGOOSE,
		SEVIPER,
		LUNATONE,
		SOLROCK,
		BARBOACH,
		WHISCASH,
		CORPHISH,
		CRAWDAUNT,
		BALTOY,
		CLAYDOL,
		LILEEP,
		CRADILY,
		ANORITH,
		ARMALDO,
		FEEBAS,
		MILOTIC,
		CASTFORM,
		KECLEON,
		SHUPPET,
		BANETTE,
		DUSKULL,
		DUSCLOPS,
		TROPIUS,
		CHIMECHO,
		ABSOL,
		WYNAUT,
		SNORUNT,
		GLALIE,
		SPHEAL,
		SEALEO,
		WALREIN,
		CLAMPERL,
		HUNTAIL,
		GOREBYSS,
		RELICANTH,
		LUVDISC,
		BAGON,
		SHELGON,
		SALAMENCE,
		BELDUM,
		METANG,
		METAGROSS,
		REGIROCK,
		REGICE,
		REGISTEEL,
		LATIAS,
		LATIOS,
		KYOGRE,
		GROUDON,
		RAYQUAZA,
		JIRACHI,
		DEOXYS,
		TURTWIG,
		GROTLE,
		TORTERRA,
		CHIMCHAR,
		MONFERNO,
		INFERNAPE,
		PIPLUP,
		PRINPLUP,
		EMPOLEON,
		STARLY,
		STARAVIA,
		STARAPTOR,
		BIDOOF,
		BIBAREL,
		KRICKETOT,
		KRICKETUNE,
		SHINX,
		LUXIO,
		LUXRAY,
		BUDEW,
		ROSERADE,
		CRANIDOS,
		RAMPARDOS,
		SHIELDON,
		BASTIODON,
		BURMY,
		WORMADAM,
		MOTHIM,
		COMBEE,
		VESPIQUEN,
		PACHIRISU,
		BUIZEL,
		FLOATZEL,
		CHERUBI,
		CHERRIM,
		SHELLOS,
		GASTRODON,
		AMBIPOM,
		DRIFLOON,
		DRIFBLIM,
		BUNEARY,
		LOPUNNY,
		MISMAGIUS,
		HONCHKROW,
		GLAMEOW,
		PURUGLY,
		CHINGLING,
		STUNKY,
		SKUNTANK,
		BRONZOR,
		BRONZONG,
		BONSLY,
		MIMEJR,
		HAPPINY,
		CHATOT,
		SPIRITOMB,
		GIBLE,
		GABITE,
		GARCHOMP,
		MUNCHLAX,
		RIOLU,
		LUCARIO,
		HIPPOPOTAS,
		HIPPOWDON,
		SKORUPI,
		DRAPION,
		CROAGUNK,
		TOXICROAK,
		CARNIVINE,
		FINNEON,
		LUMINEON,
		MANTYKE,
		SNOVER,
		ABOMASNOW,
		WEAVILE,
		MAGNEZONE,
		LICKILICKY,
		RHYPERIOR,
		TANGROWTH,
		ELECTIVIRE,
		MAGMORTAR,
		TOGEKISS,
		YANMEGA,
		LEAFEON,
		GLACEON,
		GLISCOR,
		MAMOSWINE,
		PORYGONZ,
		GALLADE,
		PROBOPASS,
		DUSKNOIR,
		FROSLASS,
		ROTOM,
		UXIE,
		MESPRIT,
		AZELF,
		DIALGA,
		PALKIA,
		HEATRAN,
		REGIGIGAS,
		GIRATINA,
		CRESSELIA,
		PHIONE,
		MANAPHY,
		DARKRAI,
		SHAYMIN,
		ARCEUS,
		VICTINI,
		SNIVY,
		SERVINE,
		SERPERIOR,
		TEPIG,
		PIGNITE,
		EMBOAR,
		OSHAWOTT,
		DEWOTT,
		SAMUROTT,
		PATRAT,
		WATCHOG,
		LILLIPUP,
		HERDIER,
		STOUTLAND,
		PURRLOIN,
		LIEPARD,
		PANSAGE,
		SIMISAGE,
		PANSEAR,
		SIMISEAR,
		PANPOUR,
		SIMIPOUR,
		MUNNA,
		MUSHARNA,
		PIDOVE,
		TRANQUILL,
		UNFEZANT,
		BLITZLE,
		ZEBSTRIKA,
		ROGGENROLA,
		BOLDORE,
		GIGALITH,
		WOOBAT,
		SWOOBAT,
		DRILBUR,
		EXCADRILL,
		AUDINO,
		TIMBURR,
		GURDURR,
		CONKELDURR,
		TYMPOLE,
		PALPITOAD,
		SEISMITOAD,
		THROH,
		SAWK,
		SEWADDLE,
		SWADLOON,
		LEAVANNY,
		VENIPEDE,
		WHIRLIPEDE,
		SCOLIPEDE,
		COTTONEE,
		WHIMSICOTT,
		PETILIL,
		LILLIGANT,
		BASCULIN,
		SANDILE,
		KROKOROK,
		KROOKODILE,
		DARUMAKA,
		DARMANITAN,
		MARACTUS,
		DWEBBLE,
		CRUSTLE,
		SCRAGGY,
		SCRAFTY,
		SIGILYPH,
		YAMASK,
		COFAGRIGUS,
		TIRTOUGA,
		CARRACOSTA,
		ARCHEN,
		ARCHEOPS,
		TRUBBISH,
		GARBODOR,
		ZORUA,
		ZOROARK,
		MINCCINO,
		CINCCINO,
		GOTHITA,
		GOTHORITA,
		GOTHITELLE,
		SOLOSIS,
		DUOSION,
		REUNICLUS,
		DUCKLETT,
		SWANNA,
		VANILLITE,
		VANILLISH,
		VANILLUXE,
		DEERLING,
		SAWSBUCK,
		EMOLGA,
		KARRABLAST,
		ESCAVALIER,
		FOONGUS,
		AMOONGUSS,
		FRILLISH,
		JELLICENT,
		ALOMOMOLA,
		JOLTIK,
		GALVANTULA,
		FERROSEED,
		FERROTHORN,
		KLINK,
		KLANG,
		KLINKLANG,
		TYNAMO,
		EELEKTRIK,
		EELEKTROSS,
		ELGYEM,
		BEHEEYEM,
		LITWICK,
		LAMPENT,
		CHANDELURE,
		AXEW,
		FRAXURE,
		HAXORUS,
		CUBCHOO,
		BEARTIC,
		CRYOGONAL,
		SHELMET,
		ACCELGOR,
		STUNFISK,
		MIENFOO,
		MIENSHAO,
		DRUDDIGON,
		GOLETT,
		GOLURK,
		PAWNIARD,
		BISHARP,
		BOUFFALANT,
		RUFFLET,
		BRAVIARY,
		VULLABY,
		MANDIBUZZ,
		HEATMOR,
		DURANT,
		DEINO,
		ZWEILOUS,
		HYDREIGON,
		LARVESTA,
		VOLCARONA,
		COBALION,
		TERRAKION,
		VIRIZION,
		TORNADUS,
		THUNDURUS,
		RESHIRAM,
		ZEKROM,
		LANDORUS,
		KYUREM,
		KELDEO,
		MELOETTA,
		GENESECT,
		CHESPIN,
		QUILLADIN,
		CHESNAUGHT,
		FENNEKIN,
		BRAIXEN,
		DELPHOX,
		FROAKIE,
		FROGADIER,
		GRENINJA,
		BUNNELBY,
		DIGGERSBY,
		FLETCHLING,
		FLETCHINDER,
		TALONFLAME,
		SCATTERBUG,
		SPEWPA,
		VIVILLON,
		LITLEO,
		PYROAR,
		FLABEBE,
		FLOETTE,
		FLORGES,
		SKIDDO,
		GOGOAT,
		PANCHAM,
		PANGORO,
		FURFROU,
		ESPURR,
		MEOWSTIC,
		HONEDGE,
		DOUBLADE,
		AEGISLASH,
		SPRITZEE,
		AROMATISSE,
		SWIRLIX,
		SLURPUFF,
		INKAY,
		MALAMAR,
		BINACLE,
		BARBARACLE,
		SKRELP,
		DRAGALGE,
		CLAUNCHER,
		CLAWITZER,
		HELIOPTILE,
		HELIOLISK,
		TYRUNT,
		TYRANTRUM,
		AMAURA,
		AURORUS,
		SYLVEON,
		HAWLUCHA,
		DEDENNE,
		CARBINK,
		GOOMY,
		SLIGGOO,
		GOODRA,
		KLEFKI,
		PHANTUMP,
		TREVENANT,
		PUMPKABOO,
		GOURGEIST,
		BERGMITE,
		AVALUGG,
		NOIBAT,
		NOIVERN,
		XERNEAS,
		YVELTAL,
		ZYGARDE,
		DIANCIE,
		HOOPA,
		VOLCANION,
		ROWLET,
		DARTRIX,
		DECIDUEYE,
		LITTEN,
		TORRACAT,
		INCINEROAR,
		POPPLIO,
		BRIONNE,
		PRIMARINA,
		PIKIPEK,
		TRUMBEAK,
		TOUCANNON,
		YUNGOOS,
		GUMSHOOS,
		GRUBBIN,
		CHARJABUG,
		VIKAVOLT,
		CRABRAWLER,
		CRABOMINABLE,
		ORICORIO,
		CUTIEFLY,
		RIBOMBEE,
		ROCKRUFF,
		LYCANROC,
		WISHIWASHI,
		MAREANIE,
		TOXAPEX,
		MUDBRAY,
		MUDSDALE,
		DEWPIDER,
		ARAQUANID,
		FOMANTIS,
		LURANTIS,
		MORELULL,
		SHIINOTIC,
		SALANDIT,
		SALAZZLE,
		STUFFUL,
		BEWEAR,
		BOUNSWEET,
		STEENEE,
		TSAREENA,
		COMFEY,
		ORANGURU,
		PASSIMIAN,
		WIMPOD,
		GOLISOPOD,
		SANDYGAST,
		PALOSSAND,
		PYUKUMUKU,
		TYPENULL,
		SILVALLY,
		MINIOR,
		KOMALA,
		TURTONATOR,
		TOGEDEMARU,
		MIMIKYU,
		BRUXISH,
		DRAMPA,
		DHELMISE,
		JANGMOO,
		HAKAMOO,
		KOMMOO,
		TAPUKOKO,
		TAPULELE,
		TAPUBULU,
		TAPUFINI,
		COSMOG,
		COSMOEM,
		SOLGALEO,
		LUNALA,
		NIHILEGO,
		BUZZWOLE,
		PHEROMOSA,
		XURKITREE,
		CELESTEELA,
		KARTANA,
		GUZZLORD,
		NECROZMA,
		MAGEARNA,
		MARSHADOW,
		POIPOLE,
		NAGANADEL,
		STAKATAKA,
		BLACEPHALON,
		ZERAORA,
		MELTAN,
		MELMETAL,
		GROOKEY,
		THWACKEY,
		RILLABOOM,
		SCORBUNNY,
		RABOOT,
		CINDERACE,
		SOBBLE,
		DRIZZILE,
		INTELEON,
		SKWOVET,
		GREEDENT,
		ROOKIDEE,
		CORVISQUIRE,
		CORVIKNIGHT,
		BLIPBUG,
		DOTTLER,
		ORBEETLE,
		NICKIT,
		THIEVUL,
		GOSSIFLEUR,
		ELDEGOSS,
		WOOLOO,
		DUBWOOL,
		CHEWTLE,
		DREDNAW,
		YAMPER,
		BOLTUND,
		ROLYCOLY,
		CARKOL,
		COALOSSAL,
		APPLIN,
		FLAPPLE,
		APPLETUN,
		SILICOBRA,
		SANDACONDA,
		CRAMORANT,
		ARROKUDA,
		BARRASKEWDA,
		TOXEL,
		TOXTRICITY,
		SIZZLIPEDE,
		CENTISKORCH,
		CLOBBOPUS,
		GRAPPLOCT,
		SINISTEA,
		POLTEAGEIST,
		HATENNA,
		HATTREM,
		HATTERENE,
		IMPIDIMP,
		MORGREM,
		GRIMMSNARL,
		OBSTAGOON,
		PERRSERKER,
		CURSOLA,
		SIRFETCHD,
		MRRIME,
		RUNERIGUS,
		MILCERY,
		ALCREMIE,
		FALINKS,
		PINCURCHIN,
		SNOM,
		FROSMOTH,
		STONJOURNER,
		EISCUE,
		INDEEDEE,
		MORPEKO,
		CUFANT,
		COPPERAJAH,
		DRACOZOLT,
		ARCTOZOLT,
		DRACOVISH,
		ARCTOVISH,
		DURALUDON,
		DREEPY,
		DRAKLOAK,
		DRAGAPULT,
		ZACIAN,
		ZAMAZENTA,
		ETERNATUS,
		KUBFU,
		URSHIFU,
		ZARUDE,
		REGIELEKI,
		REGIDRAGO,
		GLASTRIER,
		SPECTRIER,
		CALYREX,
		WYRDEER,
		KLEAVOR,
		URSALUNA,
		BASCULEGION,
		SNEASLER,
		OVERQWIL,
		ENAMORUS,
		SPRIGATITO,
		FLORAGATO,
		MEOWSCARADA,
		FUECOCO,
		CROCALOR,
		SKELEDIRGE,
		QUAXLY,
		QUAXWELL,
		QUAQUAVAL,
		LECHONK,
		OINKOLOGNE,
		TAROUNTULA,
		SPIDOPS,
		NYMBLE,
		LOKIX,
		PAWMI,
		PAWMO,
		PAWMOT,
		TANDEMAUS,
		MAUSHOLD,
		FIDOUGH,
		DACHSBUN,
		SMOLIV,
		DOLLIV,
		ARBOLIVA,
		SQUAWKABILLY,
		NACLI,
		NACLSTACK,
		GARGANACL,
		CHARCADET,
		ARMAROUGE,
		CERULEDGE,
		TADBULB,
		BELLIBOLT,
		WATTREL,
		KILOWATTREL,
		MASCHIFF,
		MABOSSTIFF,
		SHROODLE,
		GRAFAIAI,
		BRAMBLIN,
		BRAMBLEGHAST,
		TOEDSCOOL,
		TOEDSCRUEL,
		KLAWF,
		CAPSAKID,
		SCOVILLAIN,
		RELLOR,
		RABSCA,
		FLITTLE,
		ESPATHRA,
		TINKATINK,
		TINKATUFF,
		TINKATON,
		WIGLETT,
		WUGTRIO,
		BOMBIRDIER,
		FINIZEN,
		PALAFIN,
		VAROOM,
		REVAVROOM,
		CYCLIZAR,
		ORTHWORM,
		GLIMMET,
		GLIMMORA,
		GREAVARD,
		HOUNDSTONE,
		FLAMIGO,
		CETODDLE,
		CETITAN,
		VELUZA,
		DONDOZO,
		TATSUGIRI,
		ANNIHILAPE,
		CLODSIRE,
		FARIGIRAF,
		DUDUNSPARCE,
		KINGAMBIT,
		GREATTUSK,
		SCREAMTAIL,
		BRUTEBONNET,
		FLUTTERMANE,
		SLITHERWING,
		SANDYSHOCKS,
		IRONTREADS,
		IRONBUNDLE,
		IRONHANDS,
		IRONJUGULIS,
		IRONMOTH,
		IRONTHORNS,
		FRIGIBAX,
		ARCTIBAX,
		BAXCALIBUR,
		GIMMIGHOUL,
		GHOLDENGO,
		WOCHIEN,
		CHIENPAO,
		TINGLU,
		CHIYU,
		ROARINGMOON,
		IRONVALIANT,
		KORAIDON,
		MIRAIDON,
		WALKINGWAKE,
		IRONLEAVES,
		DIPPLIN,
		POLTCHAGEIST,
		SINISTCHA,
		OKIDOGI,
		MUNKIDORI,
		FEZANDIPITI,
		OGERPON,
		ARCHALUDON,
		HYDRAPPLE,
		GOUGINGFIRE,
		RAGINGBOLT,
		IRONBOULDER,
		IRONCROWN,
		TERAPAGOS,
		PECHARUNT
	}
}
