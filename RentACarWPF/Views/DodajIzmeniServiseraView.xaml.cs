using RentACar;
using RentACarWPF.ViewModels;
using System.Windows;

namespace RentACarWPF.Views
{
    public partial class DodajIzmeniServiseraView : Window
    {
        public DodajIzmeniServiseraView(Serviser serviser)
        {
            InitializeComponent();
            DataContext = new DodajIzmeniServiseraViewModel(serviser) { Window = this };
        }
    }
}
