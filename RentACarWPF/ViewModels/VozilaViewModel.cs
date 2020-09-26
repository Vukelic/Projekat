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
    public class VozilaViewModel : BindableBase
    {
        public Window Window { get; set; }
        UnitOfWork unitOfWork = new UnitOfWork(new ModelContainer());

        public MyICommand DodajVoziloCommand { get; set; }
        public MyICommand IzmeniVoziloCommand { get; set; }
        public MyICommand ObrisiVoziloCommand { get; set; }

        private ObservableCollection<Vozilo> vozila { get; set; }

        public ObservableCollection<Vozilo> Vozila
        {
            get { return vozila; }
            set
            {
                vozila = value;
                OnPropertyChanged("Vozila");
            }
        }

        private string vidljivo { get; set; }
        public string Vidljivo
        {
            get { return vidljivo; }
            set
            {
                vidljivo = value;
                OnPropertyChanged("Vidljivo");
            }
        }

        public Vozilo SelektovanoVozilo { get; set; }

        public VozilaViewModel(bool daLiJeRegular)
        {
            onOsveziInterfejs(null);

            

            if (daLiJeRegular == true)
            {
                Vidljivo = "Hidden";
            }
            else
            {
                DodajVoziloCommand = new MyICommand(onDodajVozilo);
                IzmeniVoziloCommand = new MyICommand(onIzmeniVozilo);
                ObrisiVoziloCommand = new MyICommand(onObrisiVozilo);
            }
        }

        public void onDodajVozilo(object parameter)
        {
            new DodajIzmeniVoziloView(null).ShowDialog();
            onOsveziInterfejs(null);
        }

        public void onIzmeniVozilo(object parameter)
        {
            if (SelektovanoVozilo != null)
            {
                new DodajIzmeniVoziloView(SelektovanoVozilo).ShowDialog();
                onOsveziInterfejs(null);
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
            Vozila = new ObservableCollection<Vozilo>();

            foreach (var vozilo in unitOfWork.Vozila.GetAll())
            {
                Vozila.Add(vozilo);
            }
        }
    }
}
