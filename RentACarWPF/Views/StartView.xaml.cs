using RentACarWPF.ViewModels;
using System.Windows;

namespace RentACarWPF.Views
{
    public partial class StartView : Window
    {
        public StartView()
        {
            InitializeComponent();
            DataContext = new StartViewModel() { Window = this };
        }
    }
}
