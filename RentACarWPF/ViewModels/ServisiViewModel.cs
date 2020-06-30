using RentACar;
using RentACar.DAO;
using RentACarWPF.Helpers;
using RentACarWPF.Views;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace RentACarWPF.ViewModels
{
    public class ServisiViewModel : BindableBase
    {
        private readonly Repository<Servis> servisirepo = new Repository<Servis>(new ModelContainer());

        public Window Window { get; set; }
        public MyICommand DodajServisCommand { get; set; }
        public MyICommand IzmeniServisCommand { get; set; }
        public MyICommand ObrisiServisCommand { get; set; }
        public MyICommand OsveziCommand { get; set; }

        private BindingList<Servis> servisi { get; set; }
        private List<Servis> servisiLista { get; set; }

        public BindingList<Servis> Servisi
        {
            get { return servisi; }
            set
            {
                servisi = value;
                OnPropertyChanged("Servisi");
            }
        }

        public Servis SelektovaniServis { get; set; }

        public ServisiViewModel()
        {
            onOsveziInterfejs(null);

            DodajServisCommand = new MyICommand(onDodajServis);
            IzmeniServisCommand = new MyICommand(onIzmeniServis);
            ObrisiServisCommand = new MyICommand(onObrisiServis);
            OsveziCommand = new MyICommand(onOsveziInterfejs);
        }

        public void onDodajServis(object parameter)
        {
            new DodajIzmeniServisView(null).ShowDialog();
        }

        public void onIzmeniServis(object parameter)
        {
            if (SelektovaniServis != null)
            {
                new DodajIzmeniServisView(SelektovaniServis).ShowDialog();
            }
            else
            {
                MessageBox.Show("Morate prvo izabrati servis!");
            }
        }

        public void onObrisiServis(object parameter)
        {
            if (SelektovaniServis == null)
            {
                MessageBox.Show("Morate prvo izabrati servis!");
                return;
            }

            servisirepo.Remove(SelektovaniServis.Id);

            if (servisirepo.SaveChanges())
            {
                MessageBox.Show("Servis uspesno obrisan!");
                onOsveziInterfejs(null);
            }
        }

        public void onOsveziInterfejs(object parameter)
        {
            servisiLista = servisirepo.GetAll();
            Servisi = new BindingList<Servis>();

            foreach (var servis in servisiLista)
            {
                Servisi.Add(servis);
            }
        }
    }
}
