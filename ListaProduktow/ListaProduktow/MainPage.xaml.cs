using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListaProduktow
{
    public partial class MainPage : ContentPage
    {
        public List<Produkt> Products = new List<Produkt>();
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Products = Plik.ReadFromFile();
            lista.ItemsSource = Products;
        }
        public void Dodaj_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ManageProduct());
        }
        public void Edytuj_Clicked(object sender, EventArgs e)
        {
            if (lista.SelectedItem != null)
                Navigation.PushAsync(new ManageProduct((Produkt)lista.SelectedItem));
            else
                DisplayAlert("Błąd", "Najpierw wybierz element!", "OK");
        }
        public void Usun_Clicked(object sender, EventArgs e)
        {
            if (lista.SelectedItem != null)
            {
                Products.Remove((Produkt)lista.SelectedItem);
                Plik.WriteToFile(Products);
                Products = Plik.ReadFromFile();
                lista.ItemsSource = Products;
                lista.SelectedItem = null;
            }
            else
                DisplayAlert("Błąd", "Najpierw wybierz element!", "OK");
        }
    }
}
