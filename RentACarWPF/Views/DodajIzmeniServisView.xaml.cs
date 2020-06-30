using RentACar;
using RentACarWPF.ViewModels;
using System.Windows;

namespace RentACarWPF.Views
{
    public partial class DodajIzmeniServisView : Window
    {
        public DodajIzmeniServisView(Servis servis)
        {
            InitializeComponent();
            DataContext = new DodajIzmeniServisViewModel(servis) { Window = this };
        }
    }
}
