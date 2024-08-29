using System;
using GodotPlugins.Game;
using PorygonC.Pokemons.Application;
using PorygonC.Pokemons.Domain;
using PorygonC.Scenes.Application;
using PorygonC.Scenes.Domain;
using PorygonC.Trainers.Domain;

namespace PorygonC.Scenes.Infrastructure
{
    static class InitScene
    {
        public static Scene scene;
        public static void Main(Trainer player, Trainer opponent)
        {
            var root = new Scene{};
            scene = root;
            var PkC = new PokemonConstructor{};
            var r = new Random{};

            root.AssigPlayerGroup(player.Team);
            root.AssigOpponentGroup(opponent.Team);

            //GameLoop.Main(root);
        }
    }
}