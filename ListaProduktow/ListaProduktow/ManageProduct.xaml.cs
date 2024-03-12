using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListaProduktow
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManageProduct : ContentPage
    {
        private Produkt Product;
        public ManageProduct()
        {
            InitializeComponent();
        }
        public ManageProduct(Produkt product)
        {
            InitializeComponent();
            Product = product;
            labelTytul.Text = "Edytuj produkt";
            entryNazwa.Text = product.Nazwa;
            entryCena.Text = product.Cena.ToString();
            entryIlosc.Text = product.Ilosc.ToString();
            btn.Text = "Edytuj";
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(entryNazwa.Text) && !string.IsNullOrEmpty(entryCena.Text) && !string.IsNullOrEmpty(entryIlosc.Text))
            {
                if (int.TryParse(entryIlosc.Text, out int _) && decimal.TryParse(entryCena.Text, out decimal _))
                {
                    List<Produkt> products = Plik.ReadFromFile();
                    if (Product is null)
                        products.Add(new Produkt(products.Count > 0 ? products.Last().Id + 1 : 1, entryNazwa.Text, decimal.Parse(entryCena.Text), int.Parse(entryIlosc.Text)));
                    else
                    {
                        Produkt editProduct = products.Where(p => p.Id == Product.Id).FirstOrDefault();
                        editProduct.Nazwa = entryNazwa.Text;
                        editProduct.Cena = decimal.Parse(entryCena.Text);
                        editProduct.Ilosc = int.Parse(entryIlosc.Text);
                    }
                    Plik.WriteToFile(products);
                    Navigation.PopAsync();
                }
                else
                    DisplayAlert("Błąd", "Pola cena i ilość muszą być liczbami", "OK");
            }
            else
                DisplayAlert("Błąd", "Pola nie mogą byc puste", "OK");
        }
    }
}