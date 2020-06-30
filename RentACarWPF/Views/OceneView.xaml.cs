using RentACarWPF.ViewModels;
using System.Windows;

namespace RentACarWPF.Views
{
    public partial class OceneView : Window
    {
        public OceneView()
        {
            InitializeComponent();
            DataContext = new OceneViewModel() { Window = this };
        }
    }
}
