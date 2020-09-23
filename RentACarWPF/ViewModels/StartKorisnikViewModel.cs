using RentACarWPF.Helpers;
using RentACarWPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RentACarWPF.ViewModels
{
    public class StartKorisnikViewModel : BindableBase
    {
        private string KorisnickoIme;
        public Window Window { get; set; }

        public MyICommand ViewVozilaCommand { get; set; }
        public MyICommand ViewRezervacijeCommand { get; set; }
        public MyICommand ViewOceneCommand { get; set; }
        public MyICommand ViewNalogCommand { get; set; }
        public MyICommand ViewCenovnikCommand { get; set; }

        public StartKorisnikViewModel(string korisnickoIme)
        {
            ViewVozilaCommand = new MyICommand(onViewVozila);
            ViewRezervacijeCommand = new MyICommand(onViewRezervacije);
            ViewNalogCommand = new MyICommand(onViewNalog);
            ViewCenovnikCommand = new MyICommand(onViewCenovnik);
            ViewOceneCommand = new MyICommand(onViewOcene);
            KorisnickoIme = korisnickoIme;
        }

        public void onViewCenovnik(object parameter)
        {
           new CenovnikView(true).ShowDialog();
        }

        public void onViewOcene(object parameter)
        {
            new OceneView(true).ShowDialog();
        }

        public void onViewVozila(object parameter)
        {
            new VozilaView(true).ShowDialog();
        }

        public void onViewRezervacije(object parameter)
        {
            new RezervacijeView(true).ShowDialog();
        }

        public void onViewNalog(object parameter)
        {
            new NalogView(KorisnickoIme).ShowDialog();
        }
    }
}
