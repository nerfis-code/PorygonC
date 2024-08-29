using System;
using GodotPlugins.Game;
using PorygonC.Pokemons.Application;
using PorygonC.Pokemons.Domain;
using PorygonC.Scenes.Domain;
using PorygonC.Trainers.Domain;

namespace PorygonC.Scenes.Infrastructure
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