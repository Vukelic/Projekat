using RentACar;
using RentACarWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RentACarWPF.Views
{
    /// <summary>
    /// Interaction logic for DodajIzmeniCenovnikView.xaml
    /// </summary>
    public partial class DodajIzmeniCenovnikView : Window
    {
        public DodajIzmeniCenovnikView(Cenovnik cenovnik)
        {
            InitializeComponent();
            DataContext = new DodajIzmeniCenovnikViewModel(cenovnik) { Window = this };
        }
    }
}
