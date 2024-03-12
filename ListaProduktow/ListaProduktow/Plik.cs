using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ListaProduktow
{
    public class Plik
    {

        readonly static string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "products.txt");


        public static List<Produkt> ReadData()
        {
            if (File.Exists(filePath))
            {
                List<string> lines = File.ReadAllLines(filePath).ToList();
                List<Produkt> produkty = new List<Produkt>();

                foreach (string line in lines)
                {
                    string[] entries = line.Split(';');
                    
                    Produkt produkt = new Produkt();

                    produkt.Nazwa = entries[0];
                    produkt.Cena = int.Parse(entries[1]);
                    produkt.Ilosc = int.Parse(entries[2]);

                    produkty.Add(produkt);
                }
                return produkty;
            }    
            else
            {
                return null;
            }
        }


        public static void WriteToFile(List<Produkt> produkty)
        {
            List<string> outputFile = new List<string>();

            foreach(var produkt in produkty)
            {
                string line = $"{produkt.Nazwa};{produkt.Ilosc};{produkt.Cena}";
                outputFile.Add(line);
            }
            File.WriteAllLines(filePath, outputFile);
        }

        public static void RemoveFromFile()
        {

        }
    }
}
