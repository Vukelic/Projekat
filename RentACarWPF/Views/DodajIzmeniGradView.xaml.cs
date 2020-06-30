using RentACar;
using RentACarWPF.ViewModels;
using System.Windows;

namespace RentACarWPF.Views
{
    public partial class DodajIzmeniGradView : Window
    {
        public DodajIzmeniGradView(Grad grad)
        {
            InitializeComponent();
            DataContext = new DodajIzmeniGradViewModel(grad) { Window = this };
        }
    }
}
