using System;
using System.Collections.Generic;
using System.Text;

namespace ListaProduktow
{
    public class Produkt
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public decimal Cena { get; set; }
        public int Ilosc { get; set; }

        public Produkt(int id, string nazwa, decimal cena, int ilosc)
        {
            Id = id;
            Nazwa = nazwa;
            Cena = cena;
            Ilosc = ilosc;
        }
        public Produkt() { }
    }
}
