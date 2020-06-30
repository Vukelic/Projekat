using RentACarWPF.ViewModels;
using System.Windows;

namespace RentACarWPF.Views
{
    public partial class GradoviView : Window
    {
        public GradoviView()
        {
            InitializeComponent();
            DataContext = new GradoviViewModel() { Window = this };
        }
    }
}
