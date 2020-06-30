using RentACarWPF.ViewModels;
using System.Windows;

namespace RentACarWPF.Views
{
    public partial class ZaposleniView : Window
    {
        public ZaposleniView()
        {
            InitializeComponent();
            DataContext = new ZaposleniViewModel() { Window = this };
        }
    }
}
