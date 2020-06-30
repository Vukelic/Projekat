using RentACar;
using RentACar.DAO;
using RentACarWPF.Helpers;
using RentACarWPF.Models;
using System.Windows;

namespace RentACarWPF.ViewModels
{
    public class DodajIzmeniKlijentaViewModel : BindableBase
    {
        public Window Window { get; set; }
        UnitOfWork unitOfWork = new UnitOfWork(new ModelContainer());

        AppKlijent k = new AppKlijent();

        public AppKlijent K
        {
            get { return k; }
            set
            {
                k = value;
                OnPropertyChanged("K");
            }
        }
        bool textBoxEnabled;

        public bool TextBoxEnabled
        {
            get { return textBoxEnabled; }
            set
            {
                textBoxEnabled = value;
                OnPropertyChanged("TextBoxEnabled");

            }
        }

        string titleContent;
        public string TitleContent
        {
            get { return titleContent; }
            set
            {
                titleContent = value;
                OnPropertyChanged("TitleContent");
            }
        }

        string buttonContent;
        public string ButtonContent
        {
            get { return buttonContent; }
            set
            {
                buttonContent = value;
                OnPropertyChanged("ButtonContent");
            }
        }

        string uspesno;
        public string Uspesno
        {
            get { return uspesno; }
            set
            {
                uspesno = value;
                OnPropertyChanged("Uspesno");
            }
        }

        string idPostoji;
        public string IdPostoji
        {
            get { return idPostoji; }
            set
            {
                idPostoji = value;
                OnPropertyChanged("IdPostoji");
            }
        }

        public MyICommand DodajIzmeniKlijentaCommand { get; set; }

        public DodajIzmeniKlijentaViewModel(Klijent klijent = null)
        {
            if (klijent == null)
            {
                TextBoxEnabled = true;
                TitleContent = "Dodaj klijenta";
                ButtonContent = "Dodaj";
                DodajIzmeniKlijentaCommand = new MyICommand(onDodajKlijenta);
            }
            else
            {
                TextBoxEnabled = false;
                k = new AppKlijent(klijent);
                TitleContent = "Izmeni klijenta";
                ButtonContent = "Izmeni";
                DodajIzmeniKlijentaCommand = new MyICommand(onIzmeniKlijenta);
            }
        }

        public void onDodajKlijenta(object parameter)
        {
            K.Validate();

            Klijent klijentIzBaze = unitOfWork.Klijenti.GetKlijentByJmbg(K.Jmbg);

            if (klijentIzBaze == null)
            {
                IdPostoji = "";
                if (K.IsValid)
                {
                    Klijent klijent = new Klijent();
                    klijent.Jmbg = K.Jmbg;
                    klijent.Ime = K.Ime;
                    klijent.Prezime = K.Prezime;
                    unitOfWork.Klijenti.Add(klijent);

                    if (unitOfWork.Complete() > 0)
                    {
                        Uspesno = "Uspesno ste dodali klijenta u bazu!";
                        IdPostoji = "";
                        K = new AppKlijent();
                    }
                }
            }
            else
            {
                IdPostoji = "Jmbg zauzet!";
            }
        }

        public void onIzmeniKlijenta(object parameter)
        {
            K.Validate();

            if (K.IsValid)
            {
                Klijent klijent = unitOfWork.Klijenti.GetKlijentByJmbg(K.Jmbg);
                klijent.Jmbg = K.Jmbg;
                klijent.Ime = K.Ime;
                klijent.Prezime = K.Prezime;

                unitOfWork.Klijenti.Update(klijent);

                if (unitOfWork.Complete() > 0)
                {
                    Uspesno = "Uspesno ste izmenili klijenta!";
                    IdPostoji = "";
                }
            }
        }
    }
}
