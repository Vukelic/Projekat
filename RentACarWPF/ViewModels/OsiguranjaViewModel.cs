using RentACar;
using RentACar.DAO;
using RentACarWPF.Helpers;
using RentACarWPF.Views;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace RentACarWPF.ViewModels
{
    public class OsiguranjaViewModel : BindableBase
    {
        public Window Window { get; set; }

        UnitOfWork unitOfWork = new UnitOfWork(new ModelContainer());

        public MyICommand DodajOsiguranjeCommand { get; set; }
        public MyICommand IzmeniOsiguranjeCommand { get; set; }
        public MyICommand ObrisiOsiguranjeCommand { get; set; }
        public MyICommand OsveziCommand { get; set; }

        private BindingList<Osiguranje> osiguranja { get; set; }
        private List<Osiguranje> osiguranjaLista { get; set; }

        public BindingList<Osiguranje> Osiguranja
        {
            get { return osiguranja; }
            set
            {
                osiguranja = value;
                OnPropertyChanged("Osiguranja");
            }
        }

        public Osiguranje SelektovanoOsiguranje { get; set; }

        public OsiguranjaViewModel()
        {
            onOsveziInterfejs(null);

            DodajOsiguranjeCommand = new MyICommand(onDodajOsiguranje);
            IzmeniOsiguranjeCommand = new MyICommand(onIzmeniOsiguranje);
            ObrisiOsiguranjeCommand = new MyICommand(onObrisiOsiguranje);
            OsveziCommand = new MyICommand(onOsveziInterfejs);
        }

        public void onDodajOsiguranje(object parameter)
        {
            new DodajIzmeniOsiguranjeView(null).ShowDialog();
        }

        public void onOsveziInterfejs(object parameter)
        {
            osiguranjaLista = unitOfWork.Osiguranja.GetAll();
            Osiguranja = new BindingList<Osiguranje>();

            foreach (var osiguranje in osiguranjaLista)
            {
                Osiguranja.Add(osiguranje);
            }
        }

        public void onIzmeniOsiguranje(object parameter)
        {
            if (SelektovanoOsiguranje != null)
            {
                new DodajIzmeniOsiguranjeView(SelektovanoOsiguranje).ShowDialog();
            }
            else
            {
                MessageBox.Show("Morate prvo izabrati osiguranje!");
            }
        }

        public void onObrisiOsiguranje(object parameter)
        {
            if (SelektovanoOsiguranje == null)
            {
                MessageBox.Show("Morate prvo izabrati osiguranje!");
                return;
            }

            var rezervacije = unitOfWork.Rezervacije.RezervacijaSaOsiguranjem(SelektovanoOsiguranje.Id);

            if(rezervacije.Count > 0)
            {
                MessageBox.Show("Ne mozete obrisati osiguranje jer ima rezervacija sa ovim brojem polise! Obrisite rezervacije pa pokusajte ponovo!");
            }
            else
            {
                unitOfWork.Osiguranja.Remove(SelektovanoOsiguranje.Id);

                if (unitOfWork.Complete() > 0)
                {
                    MessageBox.Show("Osiguranje uspesno obrisano!");
                    onOsveziInterfejs(null);
                }
            }
        }
    }
}
