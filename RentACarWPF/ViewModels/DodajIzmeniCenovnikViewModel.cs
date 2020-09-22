using RentACar;
using RentACar.DAO;
using RentACarWPF.Helpers;
using RentACarWPF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RentACarWPF.ViewModels
{
    public class DodajIzmeniCenovnikViewModel : BindableBase
    {
        public Window Window { get; set; }
        UnitOfWork unitOfWork = new UnitOfWork(new ModelContainer());

        AppCenovnik c = new AppCenovnik();

        public AppCenovnik C
        {
            get { return c; }
            set
            {
                c = value;
                OnPropertyChanged("C");
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

        List<Vozilo> voziloLista = new List<Vozilo>();
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

        public MyICommand DodajIzmeniCenovnikCommand { get; set; }
        public DodajIzmeniCenovnikViewModel(Cenovnik cenovnik = null)
        {
            voziloLista = unitOfWork.Vozila.GetAll();
            Vozila = new BindingList<Vozilo>();

            foreach (var item in voziloLista)
            {
                Vozila.Add(item);
            }

            if (cenovnik == null)
            {
                TextBoxEnabled = true;
                TitleContent = "Dodaj cenovnik";
                ButtonContent = "Dodaj";
                DodajIzmeniCenovnikCommand = new MyICommand(onDodajCenovnik);
            }
            else
            {
                TextBoxEnabled = false;
                SelektovanoVozilo = unitOfWork.Vozila.Get(cenovnik.VoziloId);
                c = new AppCenovnik(cenovnik);
                TitleContent = "Izmeni cenovnik";
                ButtonContent = "Izmeni";
                DodajIzmeniCenovnikCommand = new MyICommand(onIzmeniCenovnik);
            }
        }

        public void onDodajCenovnik(object parameter)
        {
            bool error = false;

            C.Validate();

            if (SelektovanoVozilo == null)
            {
                VoziloError = "Polje ne moze biti prazno!";
                error = true;
            }
            else
            {
                VoziloError = "";
            }

            Cenovnik zcenovniciIzBaze = unitOfWork.Cenovnici.Get(C.Id);

            if (zcenovniciIzBaze == null)
            {
                IdPostoji = "";
                if (!error && C.IsValid)
                {
                    if (unitOfWork.Cenovnici.ProveraRezervacije(C.DatumPocetka,C.DatumKraja, SelektovanoVozilo.Id))
                    {
                  
                    Cenovnik cenovnik = new Cenovnik();
                    cenovnik.DatumPocetka = C.DatumPocetka;
                    cenovnik.DatumKraja = C.DatumKraja;
                    cenovnik.CenaPoDanu = C.CenaPoDanu;
                    cenovnik.UkupnaCena = unitOfWork.Cenovnici.IzracunajCenu(C.DatumPocetka, C.DatumKraja, C.CenaPoDanu);
                    cenovnik.Vozilo = unitOfWork.Vozila.Get(SelektovanoVozilo.Id);
                    cenovnik.VoziloId = SelektovanoVozilo.Id;
                    cenovnik.Id = C.Id;

                    unitOfWork.Cenovnici.Add(cenovnik);


                    if (unitOfWork.Complete() > 0)
                    {
                        Uspesno = "Uspesno ste dodali cenovnik u bazu!";
                        C = new AppCenovnik();
                    }
                    }
                    else
                    {
                        MessageBox.Show("Za izabrano vozilo u tom periodu je vec napravljen cenovnik !");
                    }

                }
            }
            else
            {
                IdPostoji = "Id je zauzet!";
            }
        }

        public void onIzmeniCenovnik(object parameter)
        {
            bool error = false;

            C.Validate();

            if (SelektovanoVozilo == null)
            {
                VoziloError = "Polje ne moze biti prazno!";
                error = true;
            }
            else
            {
                VoziloError = "";
            }

            if (!error && C.IsValid)
            {
                if (unitOfWork.Cenovnici.ProveraIzmene(C.DatumPocetka, C.DatumKraja, SelektovanoVozilo.Id,C.Id))
                {
                    Cenovnik cenovnik = unitOfWork.Cenovnici.Get(C.Id);
                    cenovnik.DatumPocetka = C.DatumPocetka;
                    cenovnik.DatumKraja = C.DatumKraja;
                    cenovnik.UkupnaCena = unitOfWork.Cenovnici.IzracunajCenu(C.DatumPocetka, C.DatumKraja, C.CenaPoDanu);
                    cenovnik.CenaPoDanu = C.CenaPoDanu;
                    cenovnik.VoziloId = SelektovanoVozilo.Id;
                    cenovnik.Vozilo = unitOfWork.Vozila.Get(SelektovanoVozilo.Id);

                    unitOfWork.Cenovnici.Update(cenovnik);

                    if (unitOfWork.Complete() > 0)
                    {
                        Uspesno = "Uspesno ste izmenili cenovnik!";
                    }
                }
                else
                {
                    MessageBox.Show("Za izabrano vozilo u tom periodu je vec napravljen cenovnik !");
                }

            }

        }
    }
}
