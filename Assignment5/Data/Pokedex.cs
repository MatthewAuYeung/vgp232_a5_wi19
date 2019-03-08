using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assignment5.Data
{
    [XmlRoot("Pokedex")]
    public class Pokedex
    {
        [XmlArray("Pokemons")]
        [XmlArrayItem("Pokemon")]
        public List<Pokemon> Pokemons { get; set; }

        public Pokedex()
        {
            Pokemons = new List<Pokemon>();
        }

        Pokemon GetPokemonByIndex(int index)
        {
            Pokemon temp = new Pokemon();

            foreach (var pokemon in Pokemons)
            {
                if (pokemon.Index == index)
                {
                    temp = pokemon;
                }
            }
            return temp;
            //throw new NotImplementedException();
        }

        Pokemon GetPokemonByName(string name)
        {
            Pokemon temp = new Pokemon();

            foreach (var pokemon in Pokemons)
            {
                if (pokemon.Name == name)
                {
                    temp = pokemon;
                }
            }
            return temp;
            //throw new NotImplementedException();
        }

        List<Pokemon> GetPokemonsOfType(string type)
        {
            List<Pokemon> temp_list = new List<Pokemon>();

            foreach (var pokemon in Pokemons)
            {
                if (pokemon.Type1 == type || pokemon.Type2 == type)
                {
                    temp_list.Add(pokemon);
                }
            }
            return temp_list;
            // Note to check both Type1 and Type2
            //throw new NotImplementedException();
        }

        Pokemon GetHighestHPPokemon()
        {
            Pokemon temp = new Pokemon();
            temp.HP = 0;
            foreach (var pokemon in Pokemons)
            {
                if (pokemon.HP > temp.HP)
                {
                    temp = pokemon;
                }
            }
            return temp;
            //throw new NotImplementedException();
        }

        Pokemon GetHighestAttackPokemon()
        {
            Pokemon temp = new Pokemon();
            temp.Attack = 0;
            foreach (var pokemon in Pokemons)
            {
                if (pokemon.Attack > temp.Attack)
                {
                    temp = pokemon;
                }
            }
            return temp;
            //throw new NotImplementedException();
        }

        Pokemon GetHighestDefensePokemon()
        {
            Pokemon temp = new Pokemon();
            temp.Defense = 0;
            foreach (var pokemon in Pokemons)
            {
                if (pokemon.Defense > temp.Defense)
                {
                    temp = pokemon;
                }
            }
            return temp;
            //throw new NotImplementedException();
        }

        Pokemon GetHighestMaxCPPokemon()
        {
            Pokemon temp = new Pokemon();
            temp.MaxCP = 0;
            foreach (var pokemon in Pokemons)
            {
                if (pokemon.MaxCP > temp.MaxCP)
                {
                    temp = pokemon;
                }
            }
            return temp;
            //throw new NotImplementedException();
        }

    }
}
