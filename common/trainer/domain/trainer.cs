using System.Collections.Generic;
using System.Linq;

namespace PorygonC.Domain
{
	public class Trainer
	{
		public string Name { get; set;}
		public List<Pokemon> Team { get; private set; }

		public Trainer(string name)
		{
			Name = name;
			Team = [];
		}

		public bool AddPokemonsToTeam(Pokemon[] pks)
		{
			if (pks.Length + Team.Count > 6) return false;

			Team = Team.Concat(pks).ToList();
			return true;
		}
	}
}
