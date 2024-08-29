using System.Collections.Generic;
using System.Linq;
using Godot;
using PorygonC.Pokemons.Domain;

namespace PorygonC.Scenes.Domain
{
    class Scene
    {
        public int Id { get; set; }
        public ushort Turn { get; set; } = 0;
        public List<Pokemon> PokemonsPlayerGroup { get; private set; }
        public List<Pokemon> PokemonsOpponentGroup { get; private set; }
        public List<Move> CurrPlayerMove { get; set; } = [];
        public List<Move> CurrOpponentMove { get; set; } = [];

        public void AssigPlayerGroup(List<Pokemon> group)
        {
            PokemonsPlayerGroup = group;
        }
        public void AssigOpponentGroup(List<Pokemon> group)
        {
            PokemonsOpponentGroup = group;
        }

        public void InitializeTurn()
        {
            if(CurrPlayerMove.Count != PokemonsPlayerGroup.Count || CurrOpponentMove.Count != PokemonsOpponentGroup.Count) return;
            Turn++;
            var order = Priority();
            var currMoves = CurrPlayerMove.Concat(CurrOpponentMove).ToArray();
            for(int i=0;i<order.Length;i++){
                var m = i < CurrPlayerMove.Count ? 0 : CurrPlayerMove.Count;
                var currMove = currMoves[i+m]; 
                GD.Print(order[i].Name + "ha realizado " + currMove.ToString());
            }
            CurrPlayerMove = [];
            CurrOpponentMove = [];
        }
        private void GameLoop()
        {

        }
        private Pokemon[] Priority()
        {
            Pokemon[] pokemonList = PokemonsPlayerGroup.Concat(PokemonsOpponentGroup).ToArray();
            return pokemonList.OrderByDescending(n => n.Stats[3]).ToArray();
        }
    }
}