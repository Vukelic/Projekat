using RentACar;
using RentACar.DAO;
using RentACarWPF.Helpers;
using RentACarWPF.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace RentACarWPF.ViewModels
{
    public class DodajizmeniFilijaluViewModel : BindableBase
    {
        public Window Window { get; set; }
        UnitOfWork unitOfWork = new UnitOfWork(new ModelContainer());

        AppFilijala f = new AppFilijala();

        public AppFilijala F
        {
            get { return f; }
            set
            {
                f = value;
                OnPropertyChanged("F");
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

        string gradError;
        public string GradError
        {
            get { return gradError; }
            set
            {
                gradError = value;
                OnPropertyChanged("GradError");
            }
        }


        Grad selektovanGrad;
        public Grad SelektovanGrad
        {
            get { return selektovanGrad; }
            set
            {
                selektovanGrad = value;
                OnPropertyChanged("SelektovanGrad");
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

        List<Grad> gradoviLista = new List<Grad>();

        BindingList<Grad> gradovi = new BindingList<Grad>();

        public BindingList<Grad> Gradovi
        {
            get { return gradovi; }
            set
            {
                gradovi = value;
                OnPropertyChanged("Gradovi");
            }
        }

        public MyICommand DodajIzmeniFilijaluCommand { get; set; }

        public DodajizmeniFilijaluViewModel(Filijala filijala = null)
        {
            gradoviLista = unitOfWork.Gradovi.GetAll();
            Gradovi = new BindingList<Grad>();

            foreach(var grad in gradoviLista)
            {
                Gradovi.Add(grad);
            }

            if(filijala == null)
            {
                TextBoxEnabled = true;
                TitleContent = "Dodaj filijalu";
                ButtonContent = "Dodaj";
                DodajIzmeniFilijaluCommand = new MyICommand(onDodajFilijalu);
            }  
            else
            {
                TextBoxEnabled = false;
                f = new AppFilijala(filijala);
                TitleContent = "Izmeni filjalu";
                ButtonContent = "Izmeni";
                SelektovanGrad = unitOfWork.Gradovi.GetGradByPostanskiBroj(filijala.GradPostanskiBroj);
                DodajIzmeniFilijaluCommand = new MyICommand(onIzmeniFilijalu);
            }

        }

        public void onDodajFilijalu(object parameter)
        {
            bool error = false;

            F.Validate();

            if (SelektovanGrad == null)
            {
                GradError = "Polje ne moze biti prazno!";
                error = true;
            }
            else
            {
                GradError = "";
            }


            Filijala filijalaIzBaze = unitOfWork.Filijale.Get(F.Id);

            if(filijalaIzBaze == null)
            {
                IdPostoji = "";
                if (!error && F.IsValid)
                {
                    Filijala filijala = new Filijala();
                    filijala.Id = F.Id;
                    filijala.Naziv = F.Naziv;
                    filijala.Adresa = F.Adresa;
                    filijala.BrojTelefona = F.BrojTelefona;
                    filijala.GradPostanskiBroj = SelektovanGrad.PostanskiBroj;

                    unitOfWork.Filijale.Add(filijala);

                    if (unitOfWork.Complete() > 0)
                    {
                        Uspesno = "Uspesno ste dodali filijalu u bazu!";
                        F = new AppFilijala();
                    }

                }
            }
            else
            {
                IdPostoji = "Id je zauzet!";
            }

        }

        public void onIzmeniFilijalu(object parameter)
        {
            bool error = false;

            F.Validate();

            if (SelektovanGrad == null)
            {
                GradError = "Polje ne moze biti prazno!";
                error = true;
            }

            else
            {
                GradError = "";
            }

            if (!error && F.IsValid)
            {
                Filijala filijala = unitOfWork.Filijale.Get(F.Id);
                filijala.Naziv = F.Naziv;
                filijala.Adresa = F.Adresa;
                filijala.BrojTelefona = F.BrojTelefona;
                filijala.Grad = unitOfWork.Gradovi.GetGradByPostanskiBroj(SelektovanGrad.PostanskiBroj);

                unitOfWork.Filijale.Update(filijala);

                if (unitOfWork.Complete() > 0)
                {
                    Uspesno = "Uspesno ste izmenili filijalu!";
                }
            }
        }
    }
}
