using PorygonC.Pokemons.Domain;

namespace PorygonC.Scenes.Domain
{
    class Scene
    {
        public int Id { get; set; }
        public ushort Turn { get; set; }
        public Pokemon[] PokemonsPlayerGroup { get; private set; }
        public Pokemon[] PokemonsOpponentGroup { get; private set; }

        public void AssigPlayerGroup(params Pokemon[] group)
        {
            PokemonsPlayerGroup = group;
        }
        public void AssigOpponentGroup(params Pokemon[] group)
        {
            PokemonsOpponentGroup = group;
        }
    }
}