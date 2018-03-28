using System;
using System.Windows.Input;

namespace RevTrainer.ViewModels
{
    /// <summary>
    /// Relay command.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action _handler;
        private bool _isEnabled;
        private readonly Func<bool> _canExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RevTrainer.ViewModels.RelayCommand"/> class.
        /// </summary>
        /// <param name="handler">Handler.</param>
        /// <param name="canExecute">Can execute.</param>
        public RelayCommand(Action handler, Func<bool> canExecute = null)
        {
            _handler = handler;
            _canExecute = canExecute;
            if (_canExecute == null)
            {
                _isEnabled = true;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:RevTrainer.ViewModels.RelayCommand"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if is enabled; otherwise, <c>false</c>.</value>
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                if (value != _isEnabled)
                {
                    _isEnabled = value;
                    if (CanExecuteChanged != null)
                    {
                        CanExecuteChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        /// <summary>
        /// Cans the execute.
        /// </summary>
        /// <returns><c>true</c>, if execute was caned, <c>false</c> otherwise.</returns>
        /// <param name="parameter">Parameter.</param>
        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
                IsEnabled = _canExecute();

            return IsEnabled;
        }

        /// <summary>
        /// Occurs when can execute changed.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Execute the specified parameter.
        /// </summary>
        /// <returns>The execute.</returns>
        /// <param name="parameter">Parameter.</param>
        public void Execute(object parameter)
        {
            _handler();
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

    /// <summary>
    /// Relay command.
    /// </summary>
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _handler;
        private bool _isEnabled = true;

        private readonly Func<T, bool> _canExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RevTrainer.ViewModels.RelayCommand`1"/> class.
        /// </summary>
        /// <param name="handler">Handler.</param>
        /// <param name="canExecute">Can execute.</param>
        public RelayCommand(Action<T> handler, Func<T, bool> canExecute = null)
        {
            _handler = handler;
            _canExecute = canExecute;
            if (canExecute == null)
            {
                _isEnabled = true;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:RevTrainer.ViewModels.RelayCommand`1"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if is enabled; otherwise, <c>false</c>.</value>
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                if (value != _isEnabled)
                {
                    _isEnabled = value;
                    if (CanExecuteChanged != null)
                    {
                        CanExecuteChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        /// <summary>
        /// Cans the execute.
        /// </summary>
        /// <returns><c>true</c>, if execute was caned, <c>false</c> otherwise.</returns>
        /// <param name="parameter">Parameter.</param>
        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
            {
                IsEnabled = _canExecute((T)parameter);
            }

            return IsEnabled;
        }

        /// <summary>
        /// Occurs when can execute changed.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Execute the specified parameter.
        /// </summary>
        /// <returns>The execute.</returns>
        /// <param name="parameter">Parameter.</param>
        public void Execute(object parameter)
        {
            _handler((T)parameter);
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
}
