using Assignment5.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Assignment 5 - Pokemon Edition");

            // TODO: load the pokemon151 xml

            // TODO: Add item reader and print out all the items
            ItemReader itemReader = new ItemReader();
            ItemsData items = itemReader.Load("itemData.xml");
            foreach (Item item in items.Items)
            {
                Console.WriteLine(item.Name);
            }
          
            // TODO: hook up item data to display with the inventory

            var source = new Inventory()
            {
                ItemToQuantity =
                    new Dictionary<object, object> { { "Poke ball", 10 }, { "Potion", 10 } }
            };

            // TODO: move this into a inventory with a serialize and deserialize function.
            string inventoryFile = "inventory.xml";
            using (var writer = XmlWriter.Create(inventoryFile))
                (new XmlSerializer(typeof(Inventory))).Serialize(writer, source);

            using (var reader = new StreamReader(inventoryFile))
            {
                var serializer = new XmlSerializer(typeof(Inventory));
                try
                {
                    Inventory inventory = serializer.Deserialize(reader) as Inventory;
                    if (inventory != null)
                    {
                        foreach (var item in inventory.ItemToQuantity)
                        {
                            Console.WriteLine("Item: {0} Quantity: {1}", item.Key, item.Value);
                        }
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Cannot load {0} due to the following {1}", 
                        inventoryFile, ex.Message);
                }

            }


            Console.ReadKey();
        }
    }
}
