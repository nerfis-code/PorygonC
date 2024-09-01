using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Godot;

namespace PorygonC.Domain
{
    public class Scene
    {
        public int Id { get; set; }
        public ushort Turn { get; set; } = 0;
        public List<Pokemon> PokemonsPlayerGroup { get; set; }
        public List<Pokemon> PokemonsOpponentGroup { get; set; }


        public event Action<Scene,List<Pokemon>,List<Pokemon>> OnAction;
        public event Action<Scene,List<Pokemon>,List<Pokemon>,Pokemon,short> OnReceived;

        public event Action EndTurn;

        public void AssigPlayerGroup(List<Pokemon> group)
        {
            PokemonsPlayerGroup = group;
        }
        public void AssigOpponentGroup(List<Pokemon> group)
        {
            PokemonsOpponentGroup = group;
        }

        public async Task InitializeTurn()
        {
            Ia();
            foreach (var item in PokemonsPlayerGroup)
            {
                if (item.CurrMove == null){
                    GD.Print("Pendejo");
                    return;
                }
            }
            Turn++;
            var order = Priority();
            foreach (var item in order)
            {
                await item.Attk([item]);
            }

            EndTurn?.Invoke();
            EndTurn = null;
            
        }

        private void Ia()
        {
            var r = new Random {};
            foreach (var item in PokemonsOpponentGroup)
            {
                item.CurrMove = item.Moves[r.Next(0,4)];
            }
            
        }
        private void GameLoop()
        {

        }
        private List<Pokemon> Priority()
        {
            List<Pokemon> pokemonList = PokemonsPlayerGroup.Concat(PokemonsOpponentGroup).ToList();
            return pokemonList.OrderByDescending(n => n.Stats[3]).ToList();
        }
    }


}