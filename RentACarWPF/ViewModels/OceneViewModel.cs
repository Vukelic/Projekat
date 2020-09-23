using RentACar;
using RentACar.DAO;
using RentACarWPF.Helpers;
using RentACarWPF.Views;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace RentACarWPF.ViewModels
{
    public class OceneViewModel : BindableBase
    {

        private readonly Repository<Ocena> ocenerepo = new Repository<Ocena>(new ModelContainer());

        public Window Window { get; set; }
        public MyICommand DodajOcenuCommand { get; set; }
        public MyICommand IzmeniOcenuCommand { get; set; }
        public MyICommand ObrisiOcenuCommand { get; set; }
        public MyICommand OsveziCommand { get; set; }

        private BindingList<Ocena> ocene { get; set; }
        private List<Ocena> oceneLista { get; set; }

        public BindingList<Ocena> Ocene
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
         
            OsveziCommand = new MyICommand(onOsveziInterfejs);
        }

        public void onDodajOcenu(object parameter)
        {
            new DodajIzmeniOcenuView(null).ShowDialog();
        }

        public void onIzmeniOcenu(object parameter)
        {
            if (SelektovanaOcena != null)
            {
                new DodajIzmeniOcenuView(SelektovanaOcena).ShowDialog();
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

            ocenerepo.Remove(SelektovanaOcena.Id);

            if (ocenerepo.SaveChanges())
            {
                MessageBox.Show("Ocena uspesno obrisana!");
                onOsveziInterfejs(null);
            }
        }

        public void onOsveziInterfejs(object parameter)
        {
            oceneLista = ocenerepo.GetAll();
            Ocene = new BindingList<Ocena>();

            foreach (var ocena in oceneLista)
            {
                Ocene.Add(ocena);
            }
        }
    }
}
