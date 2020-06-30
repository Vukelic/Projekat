using RentACar;
using RentACar.DAO;
using RentACarWPF.Helpers;
using RentACarWPF.Views;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace RentACarWPF.ViewModels
{
    public class VozilaViewModel : BindableBase
    {
        public Window Window { get; set; }
        UnitOfWork unitOfWork = new UnitOfWork(new ModelContainer());

        public MyICommand DodajVoziloCommand { get; set; }
        public MyICommand IzmeniVoziloCommand { get; set; }
        public MyICommand ObrisiVoziloCommand { get; set; }
        public MyICommand OsveziCommand { get; set; }

        private BindingList<Vozilo> vozila { get; set; }
        private List<Vozilo> vozilaLista { get; set; }

        public BindingList<Vozilo> Vozila
        {
            get { return vozila; }
            set
            {
                vozila = value;
                OnPropertyChanged("Vozila");
            }
        }

        public Vozilo SelektovanoVozilo { get; set; }

        public VozilaViewModel()
        {
            onOsveziInterfejs(null);

            DodajVoziloCommand = new MyICommand(onDodajVozilo);
            IzmeniVoziloCommand = new MyICommand(onIzmeniVozilo);
            ObrisiVoziloCommand = new MyICommand(onObrisiVozilo);
            OsveziCommand = new MyICommand(onOsveziInterfejs);
        }

        public void onDodajVozilo(object parameter)
        {
            new DodajIzmeniVoziloView(null).ShowDialog();
        }

        public void onIzmeniVozilo(object parameter)
        {
            if (SelektovanoVozilo != null)
            {
                new DodajIzmeniVoziloView(SelektovanoVozilo).ShowDialog();
            }
            else
            {
                MessageBox.Show("Morate prvo izabrati vozilo!");
            }
        }

        public void onObrisiVozilo(object parameter)
        {
            if (SelektovanoVozilo == null)
            {
                MessageBox.Show("Morate prvo izabrati vozilo!");
                return;
            }

            var rezervacije = unitOfWork.Rezervacije.RezervacijeZaVozilo(SelektovanoVozilo.Id);

            if(rezervacije.Count > 0)
            {
                MessageBox.Show("Ne mozete obrisati vozilo jer postoje aktivne rezervacije! Obrisite rezervacije pa pokusajte ponovo!");
            }
            else
            {
                var ocene = unitOfWork.Ocene.OceneZaVozilo(SelektovanoVozilo.Id);
                var servisi = unitOfWork.Servisi.GetServisiZaVozilo(SelektovanoVozilo.Id);

                foreach(var ocena in ocene)
                {
                    unitOfWork.Ocene.Remove(ocena.Id);
                }

                foreach(var servis in servisi)
                {
                    unitOfWork.Servisi.Remove(servis.Id);
                }

                unitOfWork.Vozila.Remove(SelektovanoVozilo.Id);

                if (unitOfWork.Complete() > 0)
                {
                    MessageBox.Show("Vozilo uspesno obrisano!");
                    onOsveziInterfejs(null);
                }
            }
        }

        public void onOsveziInterfejs(object parameter)
        {
            vozilaLista = unitOfWork.Vozila.GetAll();
            Vozila = new BindingList<Vozilo>();

            foreach (var vozilo in vozilaLista)
            {
                Vozila.Add(vozilo);
            }
        }
    }
}
