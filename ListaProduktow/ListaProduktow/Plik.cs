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


        public static void WriteToFile(List<Produkt> products)
        {
            List<string> outputFile = new List<string>();
            foreach (var result in products)
            {
                string line = $"{result.Id};{result.Nazwa};{result.Ilosc};{result.Cena}";
                outputFile.Add(line);
            }
            File.WriteAllLines(filePath, outputFile);
        }
        public static List<Produkt> ReadFromFile()
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, string.Empty);
            }
            List<string> lines = File.ReadAllLines(filePath).ToList();
            List<Produkt> products = new List<Produkt>();
            foreach (var line in lines)
            {
                string[] entries = line.Split(';');
                Produkt produkt = new Produkt
                {
                    Id = int.Parse(entries[0]),
                    Nazwa = entries[1],
                    Ilosc = int.Parse(entries[2]),
                    Cena = decimal.Parse(entries[3])
                };
                products.Add(produkt);
            }
            return products;
        }

    }
}
