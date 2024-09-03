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
        public List<Pokemon> Group0 { get; set; } = [];
        public List<Pokemon> Group1 { get; set; } = [];
        public Trainer Player { get; set; }
        public Trainer Opponent{ get; set; }

        public event Action<Pokemon> Deleted; 
        public event Action<Pokemon> Entred; 
        public event Action EndTurn;
        public delegate Task _Task(Pokemon pokemon);
        public event _Task Change;

        public Scene(Trainer player, Trainer opponent = null){
            Player = player;
            Opponent = opponent;

            AssigGroup(Player.Team.GetRange(0,2),Group0);
            if(Opponent == null) return;
            AssigGroup(Opponent.Team.GetRange(0,2),Group1);
        }
        public void AssigGroup(List<Pokemon> group, List<Pokemon> Party)
        {
            int n = 0;
            while(group.Count > 0){
                var curr = group[0];
                if(n >= Party.Count){
                    Party.Add(curr);
                    curr.Defeated += async() =>{
                        await TrySwitch(curr);
                    };
                    Entred?.Invoke(curr);
                    group.RemoveAt(0);
                    continue;
                }
                if(Party[n] == null){
                    Party[n] = curr;
                    curr.Defeated += async() =>{
                        await TrySwitch(curr);
                    };
                    Entred?.Invoke(curr);
                    group.RemoveAt(0);
                }
                n++;
            }
        }

        public void RemovePokemon(Pokemon pokemon){
            Where(pokemon)[Where(pokemon).IndexOf(pokemon)] = null;
            Deleted?.Invoke(pokemon);
        }

        public List<Pokemon> NullOrEmpty(List<Pokemon> pokemons){
            return pokemons.Where(n => n!=null).ToList();
        }
        public async Task TrySwitch(Pokemon pokemon){
            var exist = false;
            var ia = Where(pokemon) == Group1;

            foreach (var item in Owner(pokemon).Team)
            {
                if(!item.IsDefeated && Where(item) == null) exist = true;
            }
            RemovePokemon(pokemon);
            if(exist && !ia){
                await Change?.Invoke(pokemon);
            }
        }
        public void Switch(Pokemon target, Pokemon pokemon ){

        }

        public async Task InitializeTurn()
        {
            Ia();
            var order = Priority();
            foreach (var pokemon in order)
            {
                await pokemon.Attack([pokemon]);
            }
            Turn++;
            EndTurn?.Invoke();
            EndTurn = null;
            
        }

        private void Ia()
        {
            var r = new Random {};
            foreach (var item in Group1)
            {
                item.CurrMove = item.Moves[r.Next(0,4)];
            }
            
        }
        public List<Pokemon> Where(Pokemon pokemon)
        {
            if (Group0.Contains(pokemon)) return Group0;
            else if(Group1.Contains(pokemon)) return Group1;
            return null;
        }
        public Trainer Owner(Pokemon pokemon){
            return Where(pokemon) == Group0 ? Player : Opponent;
        }
        private List<Pokemon> Priority()
        {
            List<Pokemon> pokemonList = Group0.Concat(Group1).ToList();
            return pokemonList.OrderByDescending(n => n.Stats[3]).ToList();
        }
    }


}