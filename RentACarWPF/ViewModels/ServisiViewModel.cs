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
    public class ServisiViewModel : BindableBase
    {
        UnitOfWork unitOfWork = new UnitOfWork(new ModelContainer());

        public Window Window { get; set; }
        public MyICommand DodajServisCommand { get; set; }
        public MyICommand IzmeniServisCommand { get; set; }
        public MyICommand ObrisiServisCommand { get; set; }

        private ObservableCollection<Servis> servisi { get; set; }

        public ObservableCollection<Servis> Servisi
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
        }

        public void onDodajServis(object parameter)
        {
            new DodajIzmeniServisView(null).ShowDialog();
            onOsveziInterfejs(null);
        }

        public void onIzmeniServis(object parameter)
        {
            if (SelektovaniServis != null)
            {
                new DodajIzmeniServisView(SelektovaniServis).ShowDialog();
                onOsveziInterfejs(null);
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

            unitOfWork.Servisi.Remove(SelektovaniServis.Id);

            if (unitOfWork.Servisi.SaveChanges())
            {
                MessageBox.Show("Servis uspesno obrisan!");
                onOsveziInterfejs(null);
            }
        }

        public void onOsveziInterfejs(object parameter)
        {
            Servisi = new ObservableCollection<Servis>();

            foreach (var servis in unitOfWork.Servisi.GetAll())
            {
                Servisi.Add(servis);
            }
        }
    }
}
