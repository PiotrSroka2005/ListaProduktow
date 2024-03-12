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
        private Produkt wybranyProdukt;
        public ObservableCollection<Produkt> produkty = new ObservableCollection<Produkt>();

        public void AktualizujListe()
        {
            lista.ItemsSource = null;
            lista.ItemsSource = produkty;
        }
        public MainPage()
        {
            InitializeComponent();
            OnAppearing();
        }

        public void Dodaj_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ManageProduct(produkty));
        }
        public void Edytuj_Clicked(object sender, EventArgs e)
        {
            if (lista.SelectedItem != null)
            {
                wybranyProdukt = (Produkt)lista.SelectedItem;
                Navigation.PushAsync(new ManageProduct(wybranyProdukt));
                wybranyProdukt = null;
            }
            else
            {
                DisplayAlert("Błąd", "Nie wybrano elementu", "OK");
            }
        }
        public void Usun_Clicked(object sender, EventArgs e)
        {
            if (lista.SelectedItem != null)
            {
                wybranyProdukt = (Produkt)lista.SelectedItem;
                produkty.Remove(wybranyProdukt);
                AktualizujListe();
                wybranyProdukt = null;
            }
            else
            {
                DisplayAlert("Błąd", "Nie wybrano elementu", "OK");
            }
        }
    }
}
