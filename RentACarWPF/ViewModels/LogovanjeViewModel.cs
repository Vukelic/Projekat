using RentACar;
using RentACar.DAO;
using RentACarWPF.Helpers;
using RentACarWPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RentACarWPF.ViewModels
{
    public class LogovanjeViewModel : BindableBase
    {
        private string korisnickoIme;
        private SecureString _password;
        public SecureString PasswordSecureString
        {
            get { return _password; }
            set
            {
                if (value != null)
                {
                    _password = value;
                    OnPropertyChanged("PasswordSecureString");
                }
            }
        }
        public Window Window { get; set; }

        UnitOfWork unitOfWork = new UnitOfWork(new ModelContainer());
        public string KorisnickoIme { get => korisnickoIme; set { korisnickoIme = value; OnPropertyChanged("KorisnickoIme"); } }

        public MyICommand LogovanjeCommand { get; set; }
        public MyICommand RegistracijaCommand { get; set; }
        public LogovanjeViewModel(LogovanjeView window)
        {
            this.Window = window;
            LogovanjeCommand = new MyICommand(onLogovanje);
            RegistracijaCommand = new MyICommand(onRegistracija);
        }

        public void onLogovanje(object parameter)
        {
                String pass = new System.Net.NetworkCredential(string.Empty, PasswordSecureString).Password;
                ProveraL = "";
                ProveraK = "";
                if (string.IsNullOrEmpty(KorisnickoIme))
                { 
                    ProveraK = "Morate uneti korisnicko ime!";
                }
       
                if(PasswordSecureString == null)
                {
                    ProveraL = "Morate uneti lozinku!";
                }
                if (unitOfWork.Korisnici.Login(KorisnickoIme, pass))
                {
                    
                new StartView(KorisnickoIme).Show();
               
                this.Window.Close();
                }        
                else
                 {
                
                MessageBox.Show("Korisnicko ime ili lozinka je pogresno!");         
                 }        
        }

        string proveraK;
        public string ProveraK
        {
            get { return proveraK; }
            set
            {
                proveraK = value;
                OnPropertyChanged("ProveraK");
            }
        }

        string proveraL;
        public string ProveraL
        {
            get { return proveraL; }
            set
            {
                proveraL = value;
                OnPropertyChanged("ProveraL");
            }
        }

        public void onRegistracija(object parameter)
        {
            new RegistracijaView().ShowDialog();
        }
    }
}
