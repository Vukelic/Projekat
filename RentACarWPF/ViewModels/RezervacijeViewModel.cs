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
                onOsveziInterfejs(Jmbg);
            }
            else
            {
                DodajRezervacijuCommand = new MyICommand(onDodajRezervaciju);
                IzmeniRezervacijuCommand = new MyICommand(onIzmeniRezervaciju);
                ObrisiRezervacijuCommand = new MyICommand(onObrisiRezervaciju);
                onOsveziInterfejs(null);
            }

            
        }    
         
        public void onDodajRezervaciju(object parameter)
        {
            if(jmbg != null)
            {
                new DodajIzmeniRezervacijuView(null).ShowDialog();
                onOsveziInterfejs(jmbg);
            }
            else
            {
                new DodajIzmeniRezervacijuView(null).ShowDialog();
                onOsveziInterfejs(null);
            }
           
        }

        public void onIzmeniRezervaciju(object parameter)
        {
            if (SelektovanaRezervacija != null)
            {
                new DodajIzmeniRezervacijuView(SelektovanaRezervacija).ShowDialog();
                onOsveziInterfejs(null);
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
                onOsveziInterfejs(null);
            }
        }

        public void onOsveziInterfejs(object parametar)
        {
            Rezervacije = new ObservableCollection<Rezervacija>();
            if (parametar != null)
            {
                foreach (var rezervacija in unitOfWork.Rezervacije.RezervacijeOdKlijenta(parametar.ToString()))
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
