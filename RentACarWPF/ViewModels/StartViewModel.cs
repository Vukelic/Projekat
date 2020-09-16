using RentACarWPF.Helpers;
using RentACarWPF.Views;
using System.Windows;

namespace RentACarWPF.ViewModels
{
    public class StartViewModel : BindableBase
    {
        private string KorisnickoIme;
        public Window Window { get; set; }
        public MyICommand ViewFilijaleCommand { get; set; }
        public MyICommand ViewVozilaCommand { get; set; }
        public MyICommand ViewRezervacijeCommand { get; set; }
        public MyICommand ViewKlijentiCommand { get; set; }
        public MyICommand ViewOceneCommand { get; set; }
        public MyICommand ViewGradoviCommand { get; set; }
        public MyICommand ViewServisiCommand { get; set; }
        public MyICommand ViewZaposleniCommand { get; set; }
        public MyICommand ViewOsiguranjaCommand { get; set; }
        public MyICommand ViewAgentiCommand { get; set; }
        public MyICommand ViewServiseriCommand { get; set; }
        public MyICommand ViewFunkcijeCommand { get; set; }
        public MyICommand ViewNalogCommand { get; set; }

        public StartViewModel(string korisnickoIme)
        {
            ViewFilijaleCommand = new MyICommand(onViewFilijale);
            ViewVozilaCommand = new MyICommand(onViewVozila);
            ViewRezervacijeCommand = new MyICommand(onViewRezervacije);
            ViewKlijentiCommand = new MyICommand(onViewKlijenti);
            ViewOceneCommand = new MyICommand(onViewOcene);
            ViewGradoviCommand = new MyICommand(onViewGradovi);
            ViewServisiCommand = new MyICommand(onViewServisi);
            ViewZaposleniCommand = new MyICommand(onViewZaposleni);
            ViewOsiguranjaCommand = new MyICommand(onViewOsiguranja);
            ViewAgentiCommand = new MyICommand(onViewAgenti);
            ViewServiseriCommand = new MyICommand(onViewServiseri);
            ViewFunkcijeCommand = new MyICommand(onViewFunkcije);
            ViewNalogCommand = new MyICommand(onViewNalog);
            KorisnickoIme = korisnickoIme;
        }

        public void onViewFilijale(object parameter)
        {
            new FilijaleView().ShowDialog();
        }
        public void onViewNalog(object parameter)
        {
            new NalogView(KorisnickoIme).ShowDialog();
        }
        public void onViewVozila(object parameter)
        {
            new VozilaView().ShowDialog();
        }
        public void onViewRezervacije(object parameter)
        {
            new RezervacijeView().ShowDialog();
        }
        public void onViewKlijenti(object parameter)
        {
            new KlijentiView().ShowDialog();
        }
        public void onViewOcene(object parameter)
        {
            new OceneView().ShowDialog();
        }
        public void onViewGradovi(object parameter)
        {
            new GradoviView().ShowDialog();
        }
        public void onViewServisi(object parameter)
        {
            new ServisiView().ShowDialog();
        }

        public void onViewZaposleni(object parameter)
        {
            new ZaposleniView().ShowDialog();
        }

        public void onViewOsiguranja(object parameter)
        {
            new OsiguranjaView().ShowDialog();
        }

        public void onViewAgenti(object parameter)
        {
            new AgentiView().ShowDialog();
        }

        public void onViewServiseri(object parameter)
        {
            new ServiseriView().ShowDialog();
        }

        public void onViewFunkcije(object parameter)
        {
            new FunkcijeView().ShowDialog();
        }
    }
}
