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
    public class OceneViewModel : BindableBase
    {

        UnitOfWork unitOfWork = new UnitOfWork(new ModelContainer());
        public Window Window { get; set; }
        public MyICommand DodajOcenuCommand { get; set; }
        public MyICommand IzmeniOcenuCommand { get; set; }
        public MyICommand ObrisiOcenuCommand { get; set; }

        private ObservableCollection<Ocena> ocene { get; set; }

        public ObservableCollection<Ocena> Ocene
        {
            get { return ocene; }
            set
            {
                ocene = value;
                OnPropertyChanged("Ocene");
            }
        }

        public Ocena SelektovanaOcena { get; set; }

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

        public OceneViewModel(bool daLiJeRegular)
        {
            onOsveziInterfejs(null);

            if(daLiJeRegular == true)
            {
                Vidljivo = "Hidden";
                DodajOcenuCommand = new MyICommand(onDodajOcenu);
            }
            else
            {
                DodajOcenuCommand = new MyICommand(onDodajOcenu);
                IzmeniOcenuCommand = new MyICommand(onIzmeniOcenu);
                ObrisiOcenuCommand = new MyICommand(onObrisiOcenu);
            }
         
        }

        public void onDodajOcenu(object parameter)
        {
            new DodajIzmeniOcenuView(null).ShowDialog();
            onOsveziInterfejs(null);
        }

        public void onIzmeniOcenu(object parameter)
        {
            if (SelektovanaOcena != null)
            {
                new DodajIzmeniOcenuView(SelektovanaOcena).ShowDialog();
                onOsveziInterfejs(null);
            }
            else
            {
                MessageBox.Show("Morate prvo izabrati ocenu!");
            }
        }

        public void onObrisiOcenu(object parameter)
        {
            if (SelektovanaOcena == null)
            {
                MessageBox.Show("Morate prvo izabrati ocenu!");
                return;
            }

            unitOfWork.Ocene.Remove(SelektovanaOcena.Id);

            if (unitOfWork.Ocene.SaveChanges())
            {
                MessageBox.Show("Ocena uspesno obrisana!");
                onOsveziInterfejs(null);
            }
        }

        public void onOsveziInterfejs(object parameter)
        {
            Ocene = new ObservableCollection<Ocena>();

            foreach (var ocena in unitOfWork.Ocene.GetAll())
            {
                Ocene.Add(ocena);
            }
        }
    }
}
