using RentACarWPF.ViewModels;
using System.Windows;

namespace RentACarWPF.Views
{
    public partial class ServisiView : Window
    {
        public ServisiView()
        {
            InitializeComponent();
            DataContext = new ServisiViewModel() { Window = this };
        }
    }
}
