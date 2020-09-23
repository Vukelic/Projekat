using RentACar;
using RentACar.DAO;
using RentACarWPF.Helpers;
using RentACarWPF.Views;
using System;
using System.Collections.Generic;
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
        public MyICommand OsveziCommand { get; set; }

        public Cenovnik SelektovaniCenovnik { get; set; }

        private BindingList<Cenovnik> cenovnici { get; set; }
        private List<Cenovnik> cenovniciLista { get; set; }

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

          
            OsveziCommand = new MyICommand(onOsveziInterfejs);
        }

        public BindingList<Cenovnik> Cenovnici
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
        }

        public void onIzmeniCenovnik(object parameter)
        {
            if (SelektovaniCenovnik != null)
            {
                new DodajIzmeniCenovnikView(SelektovaniCenovnik).ShowDialog();
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

           // var cenovnici = unitOfWork.Cenovnici.ProveraBrisanja(SelektovaniCenovnik.Id);

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
            }
        }

        public void onOsveziInterfejs(object parameter)
        {
            cenovniciLista = unitOfWork.Cenovnici.GetAll();
            Cenovnici = new BindingList<Cenovnik>();

            foreach (var item in cenovniciLista)
            {
                Cenovnici.Add(item);
            }
        }
    }
}
