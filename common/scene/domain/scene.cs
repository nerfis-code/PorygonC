using System;
using System.Collections.Generic;
using System.Linq;
using Godot;
using PorygonC.Pokemons.Domain;

namespace PorygonC.Scenes.Domain
{
    public class Scene
    {
        public int Id { get; set; }
        public ushort Turn { get; set; } = 0;
        public List<Pokemon> PokemonsPlayerGroup { get; set; }
        public List<Pokemon> PokemonsOpponentGroup { get; set; }


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
            Ia();
            foreach (var item in PokemonsPlayerGroup)
            {
                if (item.CurrMove == Move.NONE){
                    GD.Print("Pendejo");
                    return;
                }
            }
            Turn++;
            var order = Priority();
            for(int i=0;i<order.Length;i++){

                GD.Print(order[i].Name + " ha realizado " + order[i].CurrMove.ToString());
                GD.Print(order[i].Name + " ha ataquado a " + order[(i+1) % order.Length].Name);
                order[(i+1) % order.Length].Ps -= 10;
                order[i].CurrMove = Move.NONE;
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