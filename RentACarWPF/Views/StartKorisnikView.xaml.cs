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
    /// Interaction logic for StartKorisnikView.xaml
    /// </summary>
    public partial class StartKorisnikView : Window
    {
        public StartKorisnikView(string korisnickoIme)
        {
            InitializeComponent();

            DataContext = new StartKorisnikViewModel(korisnickoIme) { Window = this };
        }
    }
}
