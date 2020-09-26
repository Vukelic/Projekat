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
    public class KlijentiViewModel : BindableBase
    {
        public Window Window { get; set; }

        UnitOfWork unitOfWork = new UnitOfWork(new ModelContainer());

       
        public MyICommand ObrisiKlijentaCommand { get; set; }

        private ObservableCollection<Klijent> klijenti { get; set; }

        public ObservableCollection<Klijent> Klijenti
        {
            get { return klijenti; }
            set
            {
                klijenti = value;
                OnPropertyChanged("Klijenti");
            }
        }

        public Klijent SelektovaniKlijent{ get; set; }

        public KlijentiViewModel()
        {
            onOsveziInterfejs(null);
          
            ObrisiKlijentaCommand = new MyICommand(onObrisiKlijenta);
        }

            

        public void onOsveziInterfejs(object parameter)
        {
  
            Klijenti = new ObservableCollection<Klijent>();

            foreach (var klijent in unitOfWork.Klijenti.GetAll())
            {
                Klijenti.Add(klijent);
            }
        }

        public void onObrisiKlijenta(object parameter)
        {
            if (SelektovaniKlijent == null)
            {
                MessageBox.Show("Morate prvo izabrati klijenta!");
                return;
            }

            var oceneOdKlijenta = unitOfWork.Ocene.OceneOdKlijenta(SelektovaniKlijent.Jmbg);
            var rezervacijeOdKliejnta = unitOfWork.Rezervacije.RezervacijeOdKlijenta(SelektovaniKlijent.Jmbg);

            if(oceneOdKlijenta != null)
            {
                foreach(var ocena in oceneOdKlijenta)
                {
                    unitOfWork.Ocene.Remove(ocena.Id);
                }
            }

            if(rezervacijeOdKliejnta != null)
            {
                foreach(var rezervacija in rezervacijeOdKliejnta)
                {
                    unitOfWork.Rezervacije.Remove(rezervacija.Id);
                }
            }

            unitOfWork.Klijenti.RemoveByJmbg(SelektovaniKlijent.Jmbg);

            if (unitOfWork.Complete() > 0)
            {
                MessageBox.Show("Klijent uspesno obrisan!");
                onOsveziInterfejs(null);
            }
        }
    }
}
