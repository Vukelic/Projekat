using RentACarWPF.ViewModels;
using System.Windows;

namespace RentACarWPF.Views
{
    public partial class FunkcijeView : Window
    {
        public FunkcijeView()
        {
            InitializeComponent();
            DataContext = new FunkcijeViewModel() { Window = this };
        }
    }
}
