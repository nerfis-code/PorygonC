using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Utf8Json;

using PorygonC.Domain;
using System.Threading.Tasks;

namespace PorygonC.Application
{
	
	class PokemonConstructor
	{
		public Pokemon Create(int dex = 0){
			var a = File.ReadAllText("Common/PBS/pokemon.json");
			var b = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(a);
			var r = new Random{};
			var pkm = new Specie(b[dex]);
			var res = new Pokemon
			{
				Name = pkm.Name,
				Type1 = pkm.Type1,
				Type2 = pkm.Type2,
				Level = 50,
				Stats = pkm.BaseStats.Select(n => (ushort)n).ToArray(),
				Ps = pkm.BaseStats[0],
				Key = pkm.Key,
				Moves = new int[] {0,0,0,0}.Select(n => new Move((MoveKey)r.Next(0,833))).ToList(),
				IsDefeated = false
			};
			async Task WasDefeate(){
				res.IsDefeated = true;
			}
			res.Defeated += WasDefeate;
			return res;
		}

	} 
}
