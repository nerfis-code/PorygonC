using System;
using GodotPlugins.Game;
using PorygonC.Pokemons.Application;
using PorygonC.Scenes.Application;
using PorygonC.Scenes.Domain;

namespace PorygonC.Scenes.Infrastructure
{
    static class InitScene
    {
        public static Scene scene;
        public static void Main()
        {
            var root = new Scene{};
            scene = root;
            var PkC = new PokemonConstructor{};
            var r = new Random{};

            root.AssigPlayerGroup(PkC.Main(r.Next(1,1026)));
            root.AssigOpponentGroup(PkC.Main(r.Next(1,1026)));

            GameLoop.Main(root);
        }
    }
}