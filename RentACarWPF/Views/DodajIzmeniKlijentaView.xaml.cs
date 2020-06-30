using RentACar;
using RentACarWPF.ViewModels;
using System.Windows;

namespace RentACarWPF.Views
{
    public partial class DodajIzmeniKlijentaView : Window
    {
        public DodajIzmeniKlijentaView(Klijent klijent)
        {
            InitializeComponent();
            DataContext = new DodajIzmeniKlijentaViewModel(klijent) { Window = this };
        }
    }
}
