using RentACar;
using RentACar.DAO;
using RentACarWPF.Helpers;
using RentACarWPF.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace RentACarWPF.ViewModels
{
    public class DodajIzmeniOcenuViewModel : BindableBase
    {
        public Window Window { get; set; }
        UnitOfWork unitOfWork = new UnitOfWork(new ModelContainer());
        ModelContainer model = new ModelContainer();

        AppOcena o = new AppOcena();

        public AppOcena O
        {
            get { return o; }
            set
            {
                o = value;
                OnPropertyChanged("O");
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

        string klijentError;
        public string KlijentError
        {
            get { return klijentError; }
            set
            {
                klijentError = value;
                OnPropertyChanged("KlijentError");
            }
        }

        string voziloError;
        public string VoziloError
        {
            get { return voziloError; }
            set
            {
                voziloError = value;
                OnPropertyChanged("VoziloError");
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

        Klijent selektovanKlijent;
        public Klijent SelektovanKlijent
        {
            get { return selektovanKlijent; }
            set
            {
                selektovanKlijent = value;
                OnPropertyChanged("SelektovanKlijent");
            }
        }

        Vozilo selektovanoVozilo;
        public Vozilo SelektovanoVozilo
        {
            get { return selektovanoVozilo; }
            set
            {
                selektovanoVozilo = value;
                OnPropertyChanged("SelektovanoVozilo");
            }
        }

        List<Klijent> klijentiLista = new List<Klijent>();

        BindingList<Klijent> klijenti = new BindingList<Klijent>();

        List<Vozilo> vozilaLista = new List<Vozilo>();

        BindingList<Vozilo> vozila = new BindingList<Vozilo>();

        public BindingList<Vozilo> Vozila
        {
            get { return vozila; }
            set
            {
                vozila = value;
                OnPropertyChanged("Vozila");
            }
        }

        public BindingList<Klijent> Klijenti
        {
            get { return klijenti; }
            set
            {
                klijenti = value;
                OnPropertyChanged("Klijenti");
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


        public MyICommand DodajIzmeniOcenuCommand { get; set; }

        public DodajIzmeniOcenuViewModel(Ocena ocena = null)
        {
            vozilaLista = unitOfWork.Vozila.GetAll();
            Vozila = new BindingList<Vozilo>();

            foreach (var vozilo in vozilaLista)
            {
                Vozila.Add(vozilo);
            }

            klijentiLista = unitOfWork.Klijenti.GetAll();
            Klijenti = new BindingList<Klijent>();

            foreach (var klijent in klijentiLista)
            {
                Klijenti.Add(klijent);
            }

            if (ocena == null)
            {
                TextBoxEnabled = true;
                TitleContent = "Dodaj ocenu";
                ButtonContent = "Dodaj";
                DodajIzmeniOcenuCommand = new MyICommand(onDodajOcenu);
            }
            else
            {
                TextBoxEnabled = false;
                o = new AppOcena(ocena);
                SelektovanKlijent = unitOfWork.Klijenti.GetKlijentByJmbg(ocena.KlijentJmbg);
                SelektovanoVozilo = unitOfWork.Vozila.Get(ocena.VoziloId);
                TitleContent = "Izmeni ocenu";
                ButtonContent = "Izmeni";
                DodajIzmeniOcenuCommand = new MyICommand(onIzmeniOcenu);
            }
        }

        public void onDodajOcenu(object parameter)
        {
            bool error = false;

            O.Validate();
            if (SelektovanKlijent == null)
            {
                KlijentError = "Polje ne moze biti prazno!";
                error = true;
            }
            else
            {
                KlijentError = "";
            }

            if (SelektovanoVozilo == null)
            {
                VoziloError = "Polje ne moze biti prazno!";
                error = true;
            }
            else
            {
                VoziloError = "";
            }


            Ocena ocenaIzBaze = unitOfWork.Ocene.Get(O.Id);

            if(ocenaIzBaze == null)
            {
                IdPostoji = "";
                if (!error && O.IsValid)
                {
                    Ocena ocena = new Ocena();
                    ocena.KlijentJmbg = SelektovanKlijent.Jmbg;
                    ocena.VoziloId = SelektovanoVozilo.Id;
                    ocena.Vrednost = O.Vrednost;
                    ocena.Id = O.Id;

                    unitOfWork.Ocene.Add(ocena);
            
                    if (unitOfWork.Complete() > 0)
                    {
                        Uspesno = "Uspesno ste dodali ocenu u bazu!";
                        O = new AppOcena();
                    }
                    var avgNum = model.Funkcija3(SelektovanoVozilo.Id);
                    foreach (var item2 in avgNum)
                    {
                        SelektovanoVozilo.ProsecnaOcena = item2.ToString();
                    }
                    unitOfWork.Vozila.Update(selektovanoVozilo);
                    unitOfWork.Complete();

                }

            }
            else
            {
                IdPostoji = "Id je zauzet!";
            }

        }

        public void onIzmeniOcenu(object parameter)
        {
            bool error = false;

            O.Validate();
            if (SelektovanKlijent == null)
            {
                KlijentError = "Polje ne moze biti prazno!";
                error = true;
            }
            else
            {
                KlijentError = "";
            }

            if (SelektovanoVozilo == null)
            {
                VoziloError = "Polje ne moze biti prazno!";
                error = true;
            }
            else
            {
                VoziloError = "";
            }


            if (!error && O.IsValid)
            {
                Ocena ocena = unitOfWork.Ocene.Get(O.Id);
                ocena.KlijentJmbg = SelektovanKlijent.Jmbg;
                ocena.VoziloId = SelektovanoVozilo.Id;
                ocena.Vrednost = O.Vrednost;

                unitOfWork.Ocene.Update(ocena);

                if (unitOfWork.Complete() > 0)
                {
                    Uspesno = "Uspesno ste izmenili ocenu!";
                    IdPostoji = "";
                }

                var avgNum = model.Funkcija3(SelektovanoVozilo.Id);
                foreach (var item2 in avgNum)
                {
                    SelektovanoVozilo.ProsecnaOcena = item2.ToString();
                }
                unitOfWork.Vozila.Update(selektovanoVozilo);
                unitOfWork.Complete();

            }
        }
    }
}
