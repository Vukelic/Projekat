using RentACar;
using RentACarWPF.ViewModels;
using System.Windows;

namespace RentACarWPF.Views
{
    public partial class DodajIzmeniAgentaView : Window
    {
        public DodajIzmeniAgentaView(Agent agent)
        {
            InitializeComponent();
            DataContext = new DodajIzmeniAgentaViewModel(agent) { Window = this };
        }
    }
}
