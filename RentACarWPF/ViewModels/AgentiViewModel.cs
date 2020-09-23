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
    public class AgentiViewModel : BindableBase
    {
        public Window Window { get; set; }
        UnitOfWork unitOfWork = new UnitOfWork(new ModelContainer());

        public MyICommand DodajAgentaCommand { get; set; }
        public MyICommand IzmeniAgentaCommand { get; set; }
        public MyICommand ObrisiAgentaCommand { get; set; }

        private ObservableCollection<Agent> agenti { get; set; }

        public ObservableCollection<Agent> Agenti
        {
            get { return agenti; }
            set
            {
                agenti = value;
                OnPropertyChanged("Agenti");
            }
        }

        public Agent SelektovaniAgent { get; set; }

        public AgentiViewModel()
        {
            onOsveziInterfejs(null);

            DodajAgentaCommand = new MyICommand(onDodajAgenta);
            IzmeniAgentaCommand = new MyICommand(onIzmeniAgenta);
            ObrisiAgentaCommand = new MyICommand(onObrisiAgenta);
            
        }

        public void onDodajAgenta(object parameter)
        {
            new DodajIzmeniAgentaView(null).ShowDialog();
            onOsveziInterfejs(null);
        }

        public void onIzmeniAgenta(object parameter)
        {
            if (SelektovaniAgent != null)
            {
                new DodajIzmeniAgentaView(SelektovaniAgent).ShowDialog();
                onOsveziInterfejs(null);
            }
            else
            {
                MessageBox.Show("Morate prvo izabrati agenta!");
            }
        }

        public void onObrisiAgenta(object parameter)
        {
            if(SelektovaniAgent == null)
            {
                MessageBox.Show("Morate prvo izabrati agenta!");
                return;
            }

            var rezervacije = unitOfWork.Rezervacije.RezervacijeOdAgenta(SelektovaniAgent.Jmbg);

            if(rezervacije.Count > 0)
            {
                MessageBox.Show("Ne mozete obrisati agenta jer ima napravljene rezervacije! Prvo obrisite rezervacije pa probajte ponovo!");
            }
            else
            {
                unitOfWork.Agenti.RemoveByJmbg(SelektovaniAgent.Jmbg);

                if (unitOfWork.Complete() > 0)
                {
                    MessageBox.Show("Agent uspesno obrisan!");
                }
                onOsveziInterfejs(null);
            }
        }

        public void onOsveziInterfejs(object parameter)
        {
            Agenti = new ObservableCollection<Agent>();

            foreach (var agent in unitOfWork.Agenti.GetAll())
            {
                Agenti.Add(agent);
            }
        }

    }
}
