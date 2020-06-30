using RentACar;
using RentACar.DAO;
using RentACarWPF.Helpers;
using RentACarWPF.Views;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace RentACarWPF.ViewModels
{
    public class GradoviViewModel : BindableBase
    {
        UnitOfWork unitOfWork = new UnitOfWork(new ModelContainer());
        public Window Window { get; set; }
        public MyICommand DodajGradCommand { get; set; }
        public MyICommand IzmeniGradCommand { get; set; }
        public MyICommand ObrisiGradCommand { get; set; }
        public MyICommand OsveziCommand { get; set; }

        private BindingList<Grad> gradovi { get; set; }
        private List<Grad> gradoviLista { get; set; }

        public BindingList<Grad> Gradovi
        {
            get { return gradovi; }
            set
            {
                gradovi = value;
                OnPropertyChanged("Gradovi");
            }
        }

        public Grad SelektovaniGrad { get; set; }

        public GradoviViewModel()
        {
            onOsveziInterfejs(null);

            DodajGradCommand = new MyICommand(onDodajGrad);
            IzmeniGradCommand = new MyICommand(onIzmeniGrad);
            ObrisiGradCommand = new MyICommand(onObrisiGrad);
            OsveziCommand = new MyICommand(onOsveziInterfejs);
        }

        public void onDodajGrad(object parameter)
        {
            new DodajIzmeniGradView(null).ShowDialog();
        }

        public void onIzmeniGrad(object parameter)
        {
           if(SelektovaniGrad != null)
           {
                new DodajIzmeniGradView(SelektovaniGrad).ShowDialog();
           }
           else
           {
                MessageBox.Show("Morate prvo izabrati grad!");
           }
        }

        public void onOsveziInterfejs(object parameter)  
        {
            gradoviLista = unitOfWork.Gradovi.GetAll();
            Gradovi = new BindingList<Grad>();

            foreach(var grad in gradoviLista)
            {
                Gradovi.Add(grad);
            }
        }

        public void onObrisiGrad(object parameter)
        {
            if (SelektovaniGrad == null)
            {
                MessageBox.Show("Morate prvo izabrati grad!");
                return;
            }

            var filijale = unitOfWork.Filijale.GetFilijaleZaGrad(SelektovaniGrad.PostanskiBroj);

            if(filijale.Count > 0)
            {
                MessageBox.Show("Ne mozete obrisati grad jer ima filijale u njoj! Obrisite filijale pa pokusajte ponovo!");
            }
            else
            {
                unitOfWork.Gradovi.RemoveByPostanskiBroj(SelektovaniGrad.PostanskiBroj);

                if(unitOfWork.Complete() > 0)
                {
                    MessageBox.Show("Grad uspesno obrisan!");
                    onOsveziInterfejs(null);
                }
            }
        }
    }
}
