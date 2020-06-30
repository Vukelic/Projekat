using RentACar;
using RentACar.DAO;
using RentACarWPF.Helpers;
using RentACarWPF.Views;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace RentACarWPF.ViewModels
{
    public class RezervacijeViewModel : BindableBase
    {
        public Window Window { get; set; }
        private readonly Repository<Rezervacija> rezervacijerepo = new Repository<Rezervacija>(new ModelContainer());

        public MyICommand DodajRezervacijuCommand { get; set; }
        public MyICommand IzmeniRezervacijuCommand { get; set; }
        public MyICommand ObrisiRezervacijuCommand { get; set; }
        public MyICommand OsveziCommand { get; set; }

        private BindingList<Rezervacija> rezervacije { get; set; }
        private List<Rezervacija> rezervacijeLista { get; set; }

        public BindingList<Rezervacija> Rezervacije
        {
            get { return rezervacije; }
            set
            {
                rezervacije = value;
                OnPropertyChanged("Rezervacije");
            }
        }

        public Rezervacija SelektovanaRezervacija { get; set; }

        public RezervacijeViewModel()
        {
            onOsveziInterfejs(null);

            DodajRezervacijuCommand = new MyICommand(onDodajRezervaciju);
            IzmeniRezervacijuCommand = new MyICommand(onIzmeniRezervaciju);
            ObrisiRezervacijuCommand = new MyICommand(onObrisiRezervaciju);
            OsveziCommand = new MyICommand(onOsveziInterfejs);
        }    
         
        public void onDodajRezervaciju(object parameter)
        {
            new DodajIzmeniRezervacijuView(null).ShowDialog();
        }

        public void onIzmeniRezervaciju(object parameter)
        {
            if (SelektovanaRezervacija != null)
            {
                new DodajIzmeniRezervacijuView(SelektovanaRezervacija).ShowDialog();
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

            rezervacijerepo.Remove(SelektovanaRezervacija.Id);

            if (rezervacijerepo.SaveChanges())
            {
                MessageBox.Show("Rezervacija uspesno obrisana!");
                onOsveziInterfejs(null);
            }
        }

        public void onOsveziInterfejs(object parameter)
        {
            rezervacijeLista = rezervacijerepo.GetAll();
            Rezervacije = new BindingList<Rezervacija>();

            foreach (var rezervacija in rezervacijeLista)
            {
                Rezervacije.Add(rezervacija);
            }
        }
    }
}
