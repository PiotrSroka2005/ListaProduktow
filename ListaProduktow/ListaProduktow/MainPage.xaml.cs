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
        public MainPage()
        {
            InitializeComponent();
        }
    }
}
