using RentACar;
using RentACar.DAO;
using RentACarWPF.Helpers;
using RentACarWPF.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace RentACarWPF.ViewModels
{
    public class RezervacijeViewModel : BindableBase
    {
        UnitOfWork unitOfWork = new UnitOfWork(new ModelContainer());
        private ObservableCollection<Rezervacija> rezervacije;
        public Window Window { get; set; }

        public MyICommand DodajRezervacijuCommand { get; set; }
        public MyICommand IzmeniRezervacijuCommand { get; set; }
        public MyICommand ObrisiRezervacijuCommand { get; set; }

        public ObservableCollection<Rezervacija> Rezervacije { get => rezervacije; set { rezervacije = value; OnPropertyChanged("Rezervacije"); } }   
        public Rezervacija SelektovanaRezervacija { get; set; }

        private string vidljivo { get; set; }

        private string jmbg { get; set; }
        public string Vidljivo
        {
            get { return vidljivo; }
            set
            {
                vidljivo = value;
                OnPropertyChanged("Vidljivo");
            }
        }

        public RezervacijeViewModel(string Jmbg)
        {
            jmbg = Jmbg;
            var korisnik = unitOfWork.Klijenti.GetKlijentByJmbg(Jmbg);
            if(korisnik.Uloga == TipUloga.regular)
            {
                DodajRezervacijuCommand = new MyICommand(onDodajRezervaciju);
                Vidljivo = "Hidden";
                onOsveziInterfejs(true,jmbg);
            }
            else
            {
                DodajRezervacijuCommand = new MyICommand(onDodajRezervaciju);
                IzmeniRezervacijuCommand = new MyICommand(onIzmeniRezervaciju);
                ObrisiRezervacijuCommand = new MyICommand(onObrisiRezervaciju);
                onOsveziInterfejs(false,jmbg);
            }

            
        }    
         
        public void onDodajRezervaciju(object parameter)
        {
            var korisnik = unitOfWork.Klijenti.GetKlijentByJmbg(jmbg);
            if (korisnik.Uloga == TipUloga.regular)
            {
                new DodajIzmeniRezervacijuView(null,jmbg).ShowDialog();
                onOsveziInterfejs(true,jmbg);
            }
            else
            {
                new DodajIzmeniRezervacijuView(null,jmbg).ShowDialog();
                onOsveziInterfejs(false,jmbg);
            }
           
        }

        public void onIzmeniRezervaciju(object parameter)
        {
            if (SelektovanaRezervacija != null)
            {
                new DodajIzmeniRezervacijuView(SelektovanaRezervacija,jmbg).ShowDialog();
                onOsveziInterfejs(false,jmbg);
            }
            else
            {
                MessageBox.Show("Morate prvo izabrati rezervaciju!");
            }
        }

        public void onObrisiRezervaciju(object parameter)
        {
            if (SelektovanaRezervacija == null)
            {
                MessageBox.Show("Morate prvo izabrati rezervaciju!");
                return;
            }

            unitOfWork.Rezervacije.Remove(SelektovanaRezervacija.Id);

            if (unitOfWork.Rezervacije.SaveChanges())
            {
                MessageBox.Show("Rezervacija uspesno obrisana!");
                onOsveziInterfejs(false,jmbg);
            }
        }

        public void onOsveziInterfejs(bool daLiJeRegular, string jmbg)
        {
            Rezervacije = new ObservableCollection<Rezervacija>();
            if (daLiJeRegular == true)
            {
                foreach (var rezervacija in unitOfWork.Rezervacije.RezervacijeOdKlijenta(jmbg))
                {
                    Rezervacije.Add(rezervacija);
                }
            }
            else
            {
                foreach (var rezervacija in unitOfWork.Rezervacije.GetAll())
                {
                    Rezervacije.Add(rezervacija);
                }
            }
                      
        }
    }
}
