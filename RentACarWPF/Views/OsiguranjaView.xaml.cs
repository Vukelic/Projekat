using RentACarWPF.ViewModels;
using System.Windows;

namespace RentACarWPF.Views
{
    public partial class OsiguranjaView : Window
    {
        public OsiguranjaView()
        {
            InitializeComponent();
            DataContext = new OsiguranjaViewModel() { Window = this };
        }
    }
}
