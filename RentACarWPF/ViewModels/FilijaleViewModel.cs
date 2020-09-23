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
    public class FilijaleViewModel : BindableBase
    {
        public Window Window { get; set; }

        UnitOfWork unitOfWork = new UnitOfWork(new ModelContainer());

        public MyICommand DodajFilijaluCommand { get; set; }
        public MyICommand IzmeniFilijaluCommand { get; set; }
        public MyICommand ObrisiFilijaluCommand { get; set; }

        private ObservableCollection<Filijala> filijale { get; set; }

        public ObservableCollection<Filijala> Filijale
        {
            get { return filijale; }
            set
            {
                filijale = value;
                OnPropertyChanged("Filijale");
            }
        }

        public Filijala SelektovanaFilijala { get; set; }

        public FilijaleViewModel()
        {
            onOsveziInterfejs(null);

            DodajFilijaluCommand = new MyICommand(onDodajFilijalu);
            IzmeniFilijaluCommand = new MyICommand(onIzmeniFilijalu);
            ObrisiFilijaluCommand = new MyICommand(onObrisiFilijalu);
        }

        public void onDodajFilijalu(object parameter)
        {
            new DodajIzmeniFilijaluView(null).ShowDialog();
            onOsveziInterfejs(null);
        }

        public void onIzmeniFilijalu(object parameter)
        {
            if (SelektovanaFilijala != null)
            {
                new DodajIzmeniFilijaluView(SelektovanaFilijala).ShowDialog();
                onOsveziInterfejs(null);
            }
            else
            {
                MessageBox.Show("Morate prvo izabrati filijalu!");
            }
        }
          
        public void onOsveziInterfejs(object parameter)
        {
            Filijale = new ObservableCollection<Filijala>();

            foreach (var filijala in unitOfWork.Filijale.GetAll())
            {
                Filijale.Add(filijala);
            }
        }


        public void onObrisiFilijalu(object parameter)
        {
            if (SelektovanaFilijala == null)
            {
                MessageBox.Show("Morate prvo izabrati filijalu!");
                return;
            }

            var vozila = unitOfWork.Vozila.GetVozilaZaFilijalu(SelektovanaFilijala.Id);
            var zaposleni = unitOfWork.Zaposleni.GetZaposleniUFilijali(SelektovanaFilijala.Id);

            string vozilaError = "Ne mozete obrisati filijalu jer ima vozila u njoj! Obrisite vozila pa pokusajte ponovo!";
            string zaposleniError = "Ne mozete obrisati filijalu jer ima zaposlenih u njoj! Obrisite zaposlene pa pokusajte ponovo!";

            if(vozila.Count > 0)
            {
                MessageBox.Show(vozilaError);
            }

            if(zaposleni.Count > 0)
            {
                MessageBox.Show(zaposleniError);
            }

            if(vozila.Count == 0 && zaposleni.Count == 0)
            {
                unitOfWork.Filijale.Remove(SelektovanaFilijala.Id);

                if (unitOfWork.Complete() > 0)
                {
                    MessageBox.Show("Filijala uspesno obrisana!");
                    onOsveziInterfejs(null);
                }

                onOsveziInterfejs(null);
            }
        }
    }
}
