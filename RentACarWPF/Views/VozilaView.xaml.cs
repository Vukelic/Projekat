using RentACarWPF.ViewModels;
using System.Windows;

namespace RentACarWPF.Views
{
    public partial class VozilaView : Window
    {
        public VozilaView(bool daLiJeRegular)
        {
            InitializeComponent(); 
            DataContext = new VozilaViewModel(daLiJeRegular) { Window = this };
        }
    }
}
