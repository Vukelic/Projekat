using RentACar;
using RentACarWPF.ViewModels;
using System.Windows;

namespace RentACarWPF.Views
{
    public partial class DodajIzmeniOcenuView : Window
    {
        public DodajIzmeniOcenuView(Ocena ocena)
        {
            InitializeComponent();
            DataContext = new DodajIzmeniOcenuViewModel(ocena) { Window = this };
        }
    }
}
