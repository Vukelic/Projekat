using RentACarWPF.ViewModels;
using System.Windows;

namespace RentACarWPF.Views
{
    public partial class ServiseriView : Window
    {
        public ServiseriView()
        {
            InitializeComponent();
            DataContext = new ServiseriViewModel() { Window = this };
        }
    }
}
