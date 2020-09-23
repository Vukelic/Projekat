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
    public class ServiseriViewModel : BindableBase
    {
        public Window Window { get; set; }
        UnitOfWork unitOfWork = new UnitOfWork(new ModelContainer());

        public MyICommand DodajServiseraCommand { get; set; }
        public MyICommand IzmeniServiseraCommand { get; set; }
        public MyICommand ObrisiServiseraCommand { get; set; }

        private ObservableCollection<Serviser> serviseri { get; set; }

        public ObservableCollection<Serviser> Serviseri
        {
            get { return serviseri; }
            set
            {
                serviseri = value;
                OnPropertyChanged("Serviseri");
            }
        }

        public Serviser SelektovaniServiser { get; set; }

        public ServiseriViewModel()
        {
            onOsveziInterfejs(null);

            DodajServiseraCommand = new MyICommand(onDodajServisera);
            IzmeniServiseraCommand = new MyICommand(onIzmeniServisera);
            ObrisiServiseraCommand = new MyICommand(onObrisiServisera);
        }

        public void onDodajServisera(object parameter)
        {
            new DodajIzmeniServiseraView(null).ShowDialog();
            onOsveziInterfejs(null);
        }

        public void onIzmeniServisera(object parameter)
        {
            if (SelektovaniServiser != null)
            {
                new DodajIzmeniServiseraView(SelektovaniServiser).ShowDialog();
                onOsveziInterfejs(null);
            }
            else
            {
                MessageBox.Show("Morate prvo izabrati servisera!");
            }
        }

        public void onObrisiServisera(object parameter)
        {
            if (SelektovaniServiser == null)
            {
                MessageBox.Show("Morate prvo izabrati servisera!");
                return;
            }

            var servisi = unitOfWork.Servisi.GetServisiOdServisera(SelektovaniServiser.Jmbg);

            if(servisi.Count > 0)
            {
                MessageBox.Show("Ne mozete obrisati servisera jer ima servise koje je izvrsio! Prvo obrisite servise pa probajte ponovo!");
            }
            else
            {
                unitOfWork.Serviseri.RemoveByJmbg(SelektovaniServiser.Jmbg);

                if (unitOfWork.Complete() > 0)
                {
                    MessageBox.Show("Serviser uspesn obrisan!");
                    onOsveziInterfejs(null);
                }
            }
        }

        public void onOsveziInterfejs(object parameter)
        {
            Serviseri = new ObservableCollection<Serviser>();

            foreach (var serviser in unitOfWork.Serviseri.GetAll())
            {
                Serviseri.Add(serviser);
            }
        }
    }
}
