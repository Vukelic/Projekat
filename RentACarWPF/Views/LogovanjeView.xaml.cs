using RentACarWPF.Models;
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
    /// Interaction logic for LogovanjeWindow.xaml
    /// </summary>
    public partial class LogovanjeView : Window
    {
        public LogovanjeView()
        {
            InitializeComponent();
            DataContext = new LogovanjeViewModel(this);
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox pBox = sender as PasswordBox;

            PasswordModel.SetEncryptedPassword(pBox, pBox.SecurePassword);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
