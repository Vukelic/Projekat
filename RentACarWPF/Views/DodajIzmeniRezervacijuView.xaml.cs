using RentACar;
using RentACarWPF.ViewModels;
using System.Windows;

namespace RentACarWPF.Views
{
    public partial class DodajIzmeniRezervacijuView : Window
    {
        public DodajIzmeniRezervacijuView(Rezervacija rezervacija)
        {
            InitializeComponent();
            DataContext = new DodajIzmeniRezervacijuViewModel(rezervacija) { Window = this };
        }
    }
}
