using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PorygonC.Moves.Domain;
using PorygonC.Pokemons.Domain;
using PorygonC.Species.Domain;
using Utf8Json;

namespace PorygonC.Pokemons.Application
{
	class PokemonConstructor
	{
		public Pokemon Create(PokemonKey dex = PokemonKey.BULBASAUR){
			var a = File.ReadAllText("pokemon.json");
			var b = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(a);
			var r = new Random{};
			var pkm = new Specie(b[(int)dex]);
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
			res.Defeated += ()=> res.IsDefeated = true;
			return res;
		}
		public Pokemon Create(int dex = 0){
			var a = File.ReadAllText("pokemon.json");
			var b = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(a);
			var r = new Random{};
			var pkm = new Specie(b[dex]);
			return new Pokemon
			{
				Name = pkm.Name,
				Type1 = pkm.Type1,
				Type2 = pkm.Type2,
				Level = 50,
				Stats = pkm.BaseStats.Select(n => (ushort)n).ToArray(),
				Ps = pkm.BaseStats[0],
				Key = pkm.Key,
				Moves = new int[] {0,0,0,0}.Select(n => new Move((MoveKey)r.Next(0,833))).ToList()
			};
		}
	} 
}
