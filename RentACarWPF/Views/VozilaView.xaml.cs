using RentACarWPF.ViewModels;
using System.Windows;

namespace RentACarWPF.Views
{
    public partial class VozilaView : Window
    {
        public VozilaView()
        {
            InitializeComponent(); 
            DataContext = new VozilaViewModel() { Window = this };
        }
    }
}
