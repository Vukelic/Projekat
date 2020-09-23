using RentACarWPF.ViewModels;
using System.Windows;

namespace RentACarWPF.Views
{
    public partial class RezervacijeView : Window
    {
        public RezervacijeView(string jmbg)
        {
            InitializeComponent();
            DataContext = new RezervacijeViewModel(jmbg) { Window = this };
        }
    }
}
