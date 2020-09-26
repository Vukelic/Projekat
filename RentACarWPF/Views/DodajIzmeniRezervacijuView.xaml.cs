using RentACar;
using RentACarWPF.ViewModels;
using System.Windows;

namespace RentACarWPF.Views
{
    public partial class DodajIzmeniRezervacijuView : Window
    {
        public DodajIzmeniRezervacijuView(Rezervacija rezervacija,string jmbg)
        {
            InitializeComponent();
            DataContext = new DodajIzmeniRezervacijuViewModel(rezervacija,jmbg) { Window = this };
        }
    }
}
