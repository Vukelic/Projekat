using RentACar;
using RentACarWPF.ViewModels;
using System.Windows;

namespace RentACarWPF.Views
{
    public partial class DodajIzmeniVoziloView : Window
    {
        public DodajIzmeniVoziloView(Vozilo vozilo)
        {
            InitializeComponent();
            DataContext = new DodajIzmeniVoziloViewModel(vozilo) { Window = this };
        }
    }
}
