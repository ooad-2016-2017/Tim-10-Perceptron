using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InteraktivnaMapaEvenata.Helpers
{
    /// Taken from https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/XamlUIBasics/cs/AppUIBasics/Common/RelayCommand.cs
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        /// <summary>
        /// Raised when RaiseCanExecuteChanged is called.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Creates a new command that can always execute.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public RelayCommand(Action execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Determines whether this <see cref="RelayCommand"/> can execute in its current state.
        /// </summary>
        /// <param name="parameter">
        /// Data used by the command. If the command does not require data to be passed, this object can be set to null.
        /// </param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }

        /// <summary>
        /// Executes the <see cref="RelayCommand"/> on the current command target.
        /// </summary>
        /// <param name="parameter">
        /// Data used by the command. If the command does not require data to be passed, this object can be set to null.
        /// </param>
        public void Execute(object parameter)
        {
            _execute();
        }

        /// <summary>
        /// Method used to raise the <see cref="CanExecuteChanged"/> event
        /// to indicate that the return value of the <see cref="CanExecute"/>
        /// method has changed.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }


    class RelayCommand<T> : ICommand
    {
        private readonly Func<T, bool> _canExecuteMethod;
        private readonly Action<T> _executeMethod;

        #region Constructors

        public RelayCommand(Action<T> executeMethod)
            : this(executeMethod, null)
        {
        }

        public RelayCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }

        #endregion Constructors

        #region ICommand Members

        public event EventHandler CanExecuteChanged;

        bool ICommand.CanExecute(object parameter)
        {
            try
            {
                return CanExecute((T)parameter);
            }
            catch { return false; }
        }

        void ICommand.Execute(object parameter)
        {
            Execute((T)parameter);
        }

        #endregion ICommand Members

        #region Public Methods

        public bool CanExecute(T parameter)
        {
            return ((_canExecuteMethod == null) || _canExecuteMethod(parameter));
        }

        public void Execute(T parameter)
        {
            if (_executeMethod != null)
            {
                _executeMethod(parameter);
            }
        }

        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged(EventArgs.Empty);
        }

        #endregion Public Methods

        #region Protected Methods

        protected virtual void OnCanExecuteChanged(EventArgs e)
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion Protected Methods

    }
}
