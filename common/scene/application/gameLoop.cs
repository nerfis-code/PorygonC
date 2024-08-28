using System.Linq;
using Godot;
using PorygonC.Pokemons.Domain;
using PorygonC.Scenes.Domain;

namespace PorygonC.Scenes.Application
{
    class GameLoop
    {
        public static void Main(Scene scene){
            // Initialize the scene
            
            // Initialize the game loop
            while (true){
                scene.Turn++;
                var order = Priority.Main(scene);
                foreach (var any in order){
                    GD.Print(any.Name); 
                }

                break;

            }
        }
    }
}