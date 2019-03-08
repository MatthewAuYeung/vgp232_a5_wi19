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

            Inventory myObject;
            XmlSerializer mySerializer = new XmlSerializer(typeof(Inventory));
            FileStream myFileStream = new FileStream("inventory.xml", FileMode.Open);
            myObject = (Inventory)
            mySerializer.Deserialize(myFileStream);

            Console.ReadKey();
        }
    }
}
