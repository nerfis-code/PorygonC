using System;
using PorygonC.Application;
using PorygonC.Domain;


namespace PorygonC.Infrastructure
{
	static class SceneManager
	{
		public static Scene Scene;
		public static void InitializeScene(Trainer player, Trainer opponent)
		{
			var root = new Scene{};
			Scene = root;
			var PkC = new PokemonConstructor{};
			var r = new Random{};

			root.AssigPlayerGroup(player.Team);
			root.AssigOpponentGroup(opponent.Team);

			//GameLoop.Main(root);
		}
	}
}
