using RentACarWPF.ViewModels;
using System.Windows;

namespace RentACarWPF.Views
{
    public partial class AgentiView : Window
    {
        public AgentiView()
        {
            InitializeComponent();
            DataContext = new AgentiViewModel() { Window = this };
        }
    }
}
