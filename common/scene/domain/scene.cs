using System.Collections.Generic;
using PorygonC.Pokemons.Domain;

namespace PorygonC.Scenes.Domain
{
    class Scene
    {
        public int Id { get; set; }
        public ushort Turn { get; set; }
        public List<Pokemon> PokemonsPlayerGroup { get; private set; }
        public List<Pokemon> PokemonsOpponentGroup { get; private set; }

        public void AssigPlayerGroup(List<Pokemon> group)
        {
            PokemonsPlayerGroup = group;
        }
        public void AssigOpponentGroup(List<Pokemon> group)
        {
            PokemonsOpponentGroup = group;
        }
    }
}