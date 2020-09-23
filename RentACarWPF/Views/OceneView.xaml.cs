using RentACarWPF.ViewModels;
using System.Windows;

namespace RentACarWPF.Views
{
    public partial class OceneView : Window
    {
        public OceneView(bool daLiJeRegular)
        {
            InitializeComponent();
            DataContext = new OceneViewModel(daLiJeRegular) { Window = this };
        }
    }
}
