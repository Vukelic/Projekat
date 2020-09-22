using RentACar;
using RentACar.DAO;
using RentACarWPF.Helpers;
using RentACarWPF.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;

namespace RentACarWPF.ViewModels
{
    public class DodajIzmeniGradViewModel : BindableBase
    {
        public Window Window { get; set; }
        UnitOfWork unitOfWork = new UnitOfWork(new ModelContainer());
        ModelContainer model = new ModelContainer();

        AppGrad g = new AppGrad();

        public AppGrad G
        {
            get { return g; }
            set
            {
                g = value;
                OnPropertyChanged("G");
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

         public MyICommand DodajIzmeniGradCommand { get; set; }

        public DodajIzmeniGradViewModel(Grad grad = null)
        {
            if (grad == null)
            {
                TextBoxEnabled = true;
                TitleContent = "Dodaj grad";
                ButtonContent = "Dodaj";
                DodajIzmeniGradCommand = new MyICommand(onDodajGrad);
            }
            else
            {
                TextBoxEnabled = false;
                g = new AppGrad(grad);
                TitleContent = "Izmeni grad";
                ButtonContent = "Izmeni";
                DodajIzmeniGradCommand = new MyICommand(onIzmeniGrad);
            }
        }

        public void onDodajGrad(object parameter)
        {
            G.Validate();

            Grad gradIzBaze = unitOfWork.Gradovi.GetGradByPostanskiBroj(G.PostanskiBroj);

            if(gradIzBaze == null)
            {
                IdPostoji = "";
                if (G.IsValid)
                 {
                     Grad grad = new Grad();
                     grad.Naziv = G.Naziv;
                     grad.PostanskiBroj = G.PostanskiBroj;
                     grad.Drzava = G.Drzava;
                     grad.Filijale = new List<Filijala>();
                     //unitOfWork.Gradovi.Add(grad);
                    var us = model.Procedure22(grad.PostanskiBroj, grad.Drzava, grad.Naziv);

                     if(us > 0)
                     {
                         Uspesno = "Uspesno ste dodali grad u bazu!";
                         G = new AppGrad();
                     }
                 }
            }
            else
            {
                IdPostoji = "Postanski broj zauzet!";
                Uspesno = "";
            }

        }

        public void onIzmeniGrad(object parameter)
        {
            G.Validate();
             
            if (G.IsValid)
            {
                Grad grad = unitOfWork.Gradovi.GetGradByPostanskiBroj(G.PostanskiBroj);
                grad.Naziv = G.Naziv;
                grad.PostanskiBroj = G.PostanskiBroj;
                grad.Drzava = G.Drzava;

                unitOfWork.Gradovi.Update(grad);
               
                if (unitOfWork.Complete() > 0)
                {
                    Uspesno = "Uspesno ste izmenili grad!";
                    IdPostoji = "";
                }
            }
        }
    }
}
