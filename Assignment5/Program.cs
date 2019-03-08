using Assignment5.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Assignment 5 - Pokemon Edition");

            PokemonReader reader = new PokemonReader();
            Pokedex pokedex = reader.Load("pokemon151.xml");

            // TODO: Add item reader and print out all the items
            using (XmlReader itemReader = XmlReader.Create("itemData.xml"))
            {
                while (itemReader.Read())
                {
                    if (itemReader.IsStartElement())
                    {
                        switch (itemReader.Name.ToString())
                        {
                            case "Name":
                                Console.WriteLine("Item Name : " + itemReader.ReadElementContentAsString());
                                break;
                            case "UnlockRequirement":
                                Console.WriteLine("UnlockRequirement : " + itemReader.ReadElementContentAsFloat());
                                break;
                            case "Description":
                                Console.WriteLine("Description : " + itemReader.ReadElementContentAsString());
                                break;
                            case "Effect":
                                Console.WriteLine("Effect : " + itemReader.ReadElementContentAsString());
                                break;
                        }
                    }
                    Console.WriteLine("");
                }
            }
            // List out all the pokemons loaded
            foreach (Pokemon pokemon in pokedex.Pokemons)
            {
                Console.WriteLine(pokemon.Name);
            }

            // TODO: Add a pokemon bag with 2 bulbsaur, 1 charlizard, 1 mew and 1 dragonite
            PokemonBag pokemonBag = new PokemonBag();

            pokemonBag.Pokemons.Add(1); // bulbsaur
            pokemonBag.Pokemons.Add(1); // bulbsaur
            pokemonBag.Pokemons.Add(6); // charlizard
            pokemonBag.Pokemons.Add(151); // mew
            pokemonBag.Pokemons.Add(149); // dragonite
            // and save it out and load it back and list it out.

            Console.ReadKey();
        }
    }
}
