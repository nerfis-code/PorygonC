using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using System;



namespace PorygonC.Domain
{
	class BaseSpecie
	{
		public byte Generation { get; set; }
		public Type Type1 { get; set; }
		public Type Type2 { get; set; }
		public string Name { get; set; }
		public object[] Moves { get; set; }
		public MoveKey[] TutorMoves { get; set; }
		public MoveKey[] EggMoves { get; set; }
		public Abilitie Abilitie1 { get; set; }
		public Abilitie Abilitie2 { get; set; }
		public Abilitie HiddenAbilitie { get; set; }
		public float Height { get; set; }
		public float Weight { get; set; }
		public ushort BaseTotal { get; set; }
		public byte[] BaseStats { get; set; }
		public byte CatchRate { get; set; }
		public byte Happiness { get; set; }
		public ushort BaseExp { get; set; }
		public object[] EVs { get; set; }
		public string[] Flags { get; set; }


		public BaseSpecie(Dictionary<string,object> dict){
			
			Generation = (byte)(double)dict["Generation"];
			Type1 = Enum.TryParse((string)dict["Type1"],out Type T1) ? T1 : Type.UNKNOWN;
			Type2 = Enum.TryParse((string)dict["Type2"],out Type T2) ? T2 : Type.UNKNOWN;
			Height = float.Parse((string)dict["Height"]);
			Weight = float.Parse((string)dict["Weight"]);

			Abilitie1 = Enum.TryParse((string)dict["Abilitie1"],out Abilitie ab1) ? ab1 : Abilitie.NONE;
			Abilitie2 = Enum.TryParse((string)dict["Abilitie2"],out Abilitie ab2) ? ab2 : Abilitie.NONE;
			HiddenAbilitie = Enum.TryParse((string)dict["HiddenAbilitie"],out Abilitie hab) ? hab : Abilitie.NONE;
			BaseTotal = (ushort)(double)dict["BaseTotal"];
			BaseStats = ((List<object>)dict["BaseStats"]).Select(n => (byte)(double)n).ToArray();
			CatchRate = (byte)(double)dict["CatchRate"];
			Happiness =(byte)(double)dict["Happiness"];
			BaseExp = (ushort)(double)dict["BaseExp"];
			Flags = ((List<object>)dict["Flags"]).Select(n => (string)n).ToArray();
			EVs = ((List<object>)dict["EVs"]).ToArray();

			TutorMoves = ((List<object>)dict["TutorMoves"]).Select(n => Enum.TryParse((string)n,out MoveKey mv) ? mv : MoveKey.NONE).ToArray();
			EggMoves = ((List<object>)dict["EggMoves"]).Select(n => Enum.TryParse((string)n,out MoveKey mv) ? mv : MoveKey.NONE).ToArray();
			

		}

	}

	class Specie : BaseSpecie 
	{
		public string Name { get; set; }
		public PokemonKey Key {get; set; }
		public string GrowthRate { get; set; }
		public string GenderRatio { get; set; }
		public SpecieForm[] Forms { get; set; }

		public Specie(Dictionary<string,object> dict): base(dict)
		{
			Name = (string)dict["Name"];
			Key = Enum.TryParse((string)dict["Key"],out PokemonKey T1) ? T1 : PokemonKey.MISSINGNO;
			GrowthRate = (string)dict["GrowthRate"];
			GenderRatio = (string)dict["GenderRatio"];
			Forms = ((List<Object>)dict["Forms"]).Select(n => new SpecieForm((Dictionary<string,object>)n)).ToArray();
		}
			
	}
	class SpecieForm : BaseSpecie
	{
		public string FormKey { get; set; }
		public string FormName { get; set; }
		public SpecieForm(Dictionary<string,object> dict) : base(dict)
		{
			FormKey = (string)dict["Key"];
			FormName = (string)dict["FormName"];
		}
    }
	
}
