using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;

namespace RentACarWPF.Helpers
{
    public class MyICommand : ICommand
    {
        Action<object> _TargetExecuteMethod;

         public MyICommand(Action<object> executeMethod)
         {
            _TargetExecuteMethod = executeMethod;
         }


        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        bool ICommand.CanExecute(object parameter)
        { 
            if (_TargetExecuteMethod != null)
            {
                return true;
            }

            return false;
        }

        public event EventHandler CanExecuteChanged = delegate { };

        void ICommand.Execute(object parameter)
        {
            if (_TargetExecuteMethod != null)
            {
                _TargetExecuteMethod(parameter);
            }
        }

        public void Execute(object parameter)
        {
            if (_TargetExecuteMethod != null)
            {
                _TargetExecuteMethod(parameter);
            }
        }
    }

    public class MyICommand<T> : RelayCommand<T>
    {
        public MyICommand(Action<T> execute, bool keepTargetAlive = false) : base(execute, keepTargetAlive) { }

        public MyICommand(Action<T> execute, Func<T, bool> canExecute, bool keepTargetAlive = false) : base(execute, canExecute, keepTargetAlive) { }


        public override void Execute(object parameter)
        {
            base.Execute(parameter);
        }
    }
}
