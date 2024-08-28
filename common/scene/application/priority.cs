using System.Linq;

using PorygonC.Pokemons.Domain;
using PorygonC.Scenes.Domain;

namespace PorygonC.Scenes.Application
{
    class Priority
    {
        public static Pokemon[] Main(Scene scene){
            Pokemon[] pokemonList = scene.PokemonsPlayerGroup.Concat(scene.PokemonsOpponentGroup).ToArray();
            return pokemonList.OrderByDescending(n => n.Stats[3]).ToArray();
        }
    }
}