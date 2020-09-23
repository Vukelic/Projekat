using RentACar;
using RentACar.DAO;
using RentACarWPF.Helpers;
using RentACarWPF.Models;
using RentACarWPF.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace RentACarWPF.ViewModels
{
    public class ZaposleniViewModel : BindableBase
    {
        UnitOfWork unitOfWork = new UnitOfWork(new ModelContainer());
        public Window Window { get; set; }
        public MyICommand ObrisiZaposlenogCommand { get; set; }
        private ObservableCollection<AppZaposleni> zaposleni { get; set; }

        public ObservableCollection<AppZaposleni> Zaposleni
        {
            get { return zaposleni; }
            set
            {
                zaposleni = value;
                OnPropertyChanged("Zaposleni");
            }
        }

        public AppZaposleni SelektovaniZaposleni { get; set; }

        public ZaposleniViewModel()
        {
            onOsveziInterfejs(null);

            ObrisiZaposlenogCommand = new MyICommand(onObrisiZaposlenog);
        }

        public void onOsveziInterfejs(object parameter)
        {
            var agenti = unitOfWork.Agenti.GetAll();
            var serviseri = unitOfWork.Serviseri.GetAll();
            Zaposleni = new ObservableCollection<AppZaposleni>();

            foreach (var agent in agenti)
            {
                AppZaposleni z = new AppZaposleni(agent);
                z.Uloga = "Agent";
                Zaposleni.Add(z);
            }

            foreach (var serviser in serviseri)
            {
                AppZaposleni z = new AppZaposleni(serviser);
                z.Uloga = "Serviser";
                Zaposleni.Add(z);
            }

        }

        public void onObrisiZaposlenog(object parameter)
        {
            if (SelektovaniZaposleni == null)
            {
                MessageBox.Show("Morate prvo izabrati zaposlenog!");
                return;
            }

            bool isAgent = false;

            var agenti = unitOfWork.Agenti.GetAll();

            foreach(var agent in agenti)
            {
                if (agent.Jmbg == SelektovaniZaposleni.Jmbg)
                {
                    isAgent = true;
                    break;
                }
            }

            if(isAgent)
            {
                var rezervacije = unitOfWork.Rezervacije.RezervacijeOdAgenta(SelektovaniZaposleni.Jmbg);

                if(rezervacije.Count > 0)
                {
                    MessageBox.Show("Ovaj zaposleni je agent koji ima aktivinih rezervacija. Prvo obrisite rezervacije pa pokusajte ponovo!");
                    return;
                }
                else
                {
                    ObrisiZaposlenogForce();
                    return;
                }
            }
            else
            {
                var servisi = unitOfWork.Servisi.GetServisiOdServisera(SelektovaniZaposleni.Jmbg);

                if (servisi.Count > 0)
                {
                    MessageBox.Show("Ovaj zaposleni je serviser koji ima aktivnih servisa. Prvo obrisite servise pa pokusajte ponovo!");
                    return;
                }
                else
                {
                    ObrisiZaposlenogForce();
                    return;
                }
            }
        }

        private void ObrisiZaposlenogForce()
        {
            unitOfWork.Zaposleni.RemoveByJmbg(SelektovaniZaposleni.Jmbg);

            if (unitOfWork.Complete() > 0)
            {
                MessageBox.Show("Zaposleni uspesno obrisan!");
                onOsveziInterfejs(null);
            }
        }
    }
}
