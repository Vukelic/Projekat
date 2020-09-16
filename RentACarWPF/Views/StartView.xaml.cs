using RentACarWPF.ViewModels;
using System.Windows;

namespace RentACarWPF.Views
{
    public partial class StartView : Window
    {
        public StartView(string korisnickoIme)
        {
            InitializeComponent();
            DataContext = new StartViewModel (korisnickoIme) { Window = this };
        }
    }
}
