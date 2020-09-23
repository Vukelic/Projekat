using RentACarWPF.ViewModels;
using System.Windows;

namespace RentACarWPF.Views
{
    public partial class RezervacijeView : Window
    {
        public RezervacijeView(bool daLiJeRegular)
        {
            InitializeComponent();
            DataContext = new RezervacijeViewModel(daLiJeRegular) { Window = this };
        }
    }
}
