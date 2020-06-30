using RentACarWPF.ViewModels;
using System.Windows;

namespace RentACarWPF.Views
{
    public partial class RezervacijeView : Window
    {
        public RezervacijeView()
        {
            InitializeComponent();
            DataContext = new RezervacijeViewModel() { Window = this };
        }
    }
}
