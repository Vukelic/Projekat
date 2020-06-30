using RentACarWPF.ViewModels;
using System.Windows;

namespace RentACarWPF.Views
{
    public partial class KlijentiView : Window
    {
        public KlijentiView()
        {
            InitializeComponent();
            DataContext = new KlijentiViewModel() { Window = this };
        }
    }
}
