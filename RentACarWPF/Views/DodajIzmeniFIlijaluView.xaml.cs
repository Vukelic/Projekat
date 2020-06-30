using RentACar;
using RentACarWPF.ViewModels;
using System.Windows;

namespace RentACarWPF.Views
{
    public partial class DodajIzmeniFilijaluView : Window
    {
        public DodajIzmeniFilijaluView(Filijala filijala)
        {
            InitializeComponent();
            DataContext = new DodajizmeniFilijaluViewModel(filijala) { Window = this };
        }

    }
}
