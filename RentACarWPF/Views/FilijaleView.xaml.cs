using RentACarWPF.ViewModels;
using System.Windows;

namespace RentACarWPF.Views
{
    public partial class FilijaleView : Window
    {
        public FilijaleView()
        {
            InitializeComponent();
            DataContext = new FilijaleViewModel() { Window = this };
        }
    }
}
