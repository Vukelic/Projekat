using RentACar;
using RentACar.DAO;
using RentACarWPF.Helpers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace RentACarWPF.ViewModels
{
    public class FunkcijeViewModel : BindableBase
    {
        public Window Window { get; set; }
        UnitOfWork unitOfWork = new UnitOfWork(new ModelContainer());
        ModelContainer model = new ModelContainer();
        List<Vozilo> vozilaLista = new List<Vozilo>();
        BindingList<Vozilo> vozila = new BindingList<Vozilo>();
        public MyICommand PrikaziOcenuCommand { get; set; }

        Vozilo selektovanoVozilo;
        public Vozilo SelektovanoVozilo
        {
            get { return selektovanoVozilo; }
            set
            {
                selektovanoVozilo = value;
                OnPropertyChanged("SelektovanoVozilo");
            }
        }

        string voziloError;
        public string VoziloError
        {
            get { return voziloError; }
            set
            {
                voziloError = value;
                OnPropertyChanged("VoziloError");
            }
        }

        string prosecnaOcena;
        public string ProsecnaOcena
        {
            get { return prosecnaOcena; }
            set
            {
                prosecnaOcena = value;
                OnPropertyChanged("ProsecnaOcena");
            }
        }
        public BindingList<Vozilo> Vozila
        {
            get { return vozila; }
            set
            {
                vozila = value;
                OnPropertyChanged("Vozila");
            }
        }

        public FunkcijeViewModel()
        {
            vozilaLista = unitOfWork.Vozila.GetAll();
            Vozila = new BindingList<Vozilo>();

            foreach (var item in vozilaLista)
            {
                Vozila.Add(item);
            }


            PrikaziOcenuCommand = new MyICommand(onPrikaziOcenu);
        }

        public void onPrikaziOcenu(object parameter)
        {
            bool error = false;
            if (SelektovanoVozilo == null)
            {
                VoziloError = "Polje ne moze biti prazno!";
                error = true;
            }

            if (!error)
            {
                var avgNum = model.Funkcija(selektovanoVozilo.Id);
                foreach (var item in avgNum)
                {
                    ProsecnaOcena = item.ToString();
                }


            }
        }
    }
}
