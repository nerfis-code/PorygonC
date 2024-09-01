using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Godot;
using PorygonC.Moves.Domain;
using PorygonC.Pokemons.Domain;

namespace PorygonC.Scenes.Domain
{
    public class Scene
    {
        public int Id { get; set; }
        public ushort Turn { get; set; } = 0;
        public List<Pokemon> PokemonsPlayerGroup { get; set; }
        public List<Pokemon> PokemonsOpponentGroup { get; set; }

        public delegate Task ActionHandler(Move move, Pokemon user);
        public event ActionHandler OnAction;

        public delegate Task receivedHandler(Move move, Pokemon target , short received);
        public event receivedHandler OnReceived;

        public event Action EndTurn;

        public void AssigPlayerGroup(List<Pokemon> group)
        {
            PokemonsPlayerGroup = group;
        }
        public void AssigOpponentGroup(List<Pokemon> group)
        {
            PokemonsOpponentGroup = group;
        }

        public async void InitializeTurn()
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
            for(int i=0;i<order.Length;i++){
                if (order[i].IsDefeated) continue;
                await CarryOutAttack(order[i].CurrMove,order[i],[order[(i+1) % order.Length]]);
                order[i].CurrMove = null;
            }
            EndTurn?.Invoke();
            EndTurn = null;
        }
        private async Task CarryOutAttack(Move move, Pokemon user, List<Pokemon> targets)
        {
            await OnAction?.Invoke(move, user);
            foreach (var target in targets)
            {
                target.Ps -= move.Power;
                await OnReceived?.Invoke(move, target, move.Power);
            }
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
        private Pokemon[] Priority()
        {
            Pokemon[] pokemonList = PokemonsPlayerGroup.Concat(PokemonsOpponentGroup).ToArray();
            return pokemonList.OrderByDescending(n => n.Stats[3]).ToArray();
        }
    }


}