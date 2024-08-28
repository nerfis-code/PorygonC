using System.Collections.Generic;
using System.IO;
using System.Linq;
using PorygonC.Pokemons.Domain;
using PorygonC.Species.Domain;
using Utf8Json;

namespace PorygonC.Pokemons.Application
{
	class PokemonConstructor
	{
		public Pokemon Main(int dex = 1){
			var a = File.ReadAllText("pokemon.json");
			var b = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(a);
			var pkm = new Specie(b[dex]);
			return new Pokemon
			{
				Name = pkm.Name,
				Type1 = pkm.Type1,
				Type2 = pkm.Type2,
				Level = 50,
				Stats = pkm.BaseStats.Select(n => (ushort)n).ToArray(),
				Ps = pkm.BaseStats[0],
				Key = pkm.Key
			};
		}
	} 
}
