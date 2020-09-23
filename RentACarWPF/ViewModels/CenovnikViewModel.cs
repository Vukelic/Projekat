using RentACar;
using RentACar.DAO;
using RentACarWPF.Helpers;
using RentACarWPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RentACarWPF.ViewModels
{
    public class CenovnikViewModel : BindableBase
    {
        public Window Window { get; set; }
        UnitOfWork unitOfWork = new UnitOfWork(new ModelContainer());

        public MyICommand DodajCenovnikCommand { get; set; }
        public MyICommand IzmeniCenovnikCommand { get; set; }
        public MyICommand ObrisiCenovnikCommand { get; set; }

        public Cenovnik SelektovaniCenovnik { get; set; }

        private ObservableCollection<Cenovnik> cenovnici { get; set; }

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

        public CenovnikViewModel(bool daLiJeRegular)
        {
            onOsveziInterfejs(null);

            if(daLiJeRegular ==true)
            {
                Vidljivo = "Hidden";
            }
            else
            {
                DodajCenovnikCommand = new MyICommand(onDodajCenovnik);
                IzmeniCenovnikCommand = new MyICommand(onIzmeniCenovnik);
                ObrisiCenovnikCommand = new MyICommand(onObrisiCenovnik);
            }

        }

        public ObservableCollection<Cenovnik> Cenovnici
        {
            get { return cenovnici; }
            set
            {
                cenovnici = value;
                OnPropertyChanged("Cenovnici");
            }
        }


        public void onDodajCenovnik(object parameter)
        {
            new DodajIzmeniCenovnikView(null).ShowDialog();
            onOsveziInterfejs(null);
        }

        public void onIzmeniCenovnik(object parameter)
        {
            if (SelektovaniCenovnik != null)
            {
                new DodajIzmeniCenovnikView(SelektovaniCenovnik).ShowDialog();
                onOsveziInterfejs(null);
            }
            else
            {
                MessageBox.Show("Morate prvo izabrati agenta!");
            }
        }

        public void onObrisiCenovnik(object parameter)
        {
            if (SelektovaniCenovnik == null)
            {
                MessageBox.Show("Morate prvo izabrati cenovnik!");
                return;
            }

            if (!unitOfWork.Cenovnici.ProveraBrisanja(SelektovaniCenovnik.Id))
            {
                MessageBox.Show("Ne mozete obrisati cenovnik jer ima napravljene rezervacije! Prvo obrisite rezervacije pa probajte ponovo!");
            }
            else
            {
                unitOfWork.Cenovnici.Remove(SelektovaniCenovnik.Id);

                if (unitOfWork.Complete() > 0)
                {
                    MessageBox.Show("Cenovnik uspesno obrisan!");
                }

                onOsveziInterfejs(null);
            }
        }

        public void onOsveziInterfejs(object parameter)
        {
            Cenovnici = new ObservableCollection<Cenovnik>();

            foreach (var item in unitOfWork.Cenovnici.GetAll())
            {
                Cenovnici.Add(item);
            }
        }
    }
}
