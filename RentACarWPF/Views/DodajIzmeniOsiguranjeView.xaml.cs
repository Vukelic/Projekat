using RentACar;
using RentACarWPF.ViewModels;
using System.Windows;

namespace RentACarWPF.Views
{
    public partial class DodajIzmeniOsiguranjeView : Window
    {
        public DodajIzmeniOsiguranjeView(Osiguranje osiguranje)
        {
            InitializeComponent();
            DataContext = new DodajIzmeniOsiguranjeViewModel(osiguranje) { Window = this };
        }
    }
}
