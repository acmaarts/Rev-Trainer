using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using RevTrainer.Models;

namespace RevTrainer.ViewModels
{
    /// <summary>
    /// Master view model.
    /// </summary>
    public class MasterViewModel : ViewModelBase
    {
        private ObservableCollection<TimeEntry> _items = new ObservableCollection<TimeEntry>();

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        public ObservableCollection<TimeEntry> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        private RelayCommand _addCommand;

        /// <summary>
        /// Gets the add command.
        /// </summary>
        /// <value>The add command.</value>
        public ICommand AddCommand
        {
            get { return _addCommand ?? (_addCommand = new RelayCommand(ExecuteAddCommand)); }
        }

        /// <summary>
        /// Executes the add command.
        /// </summary>
        public void ExecuteAddCommand()
        {
            Items.Insert(0, new TimeEntry());
            OnPropertyChanged("Items");
        }

        private RelayCommand<int> _deleteCommand;

        /// <summary>
        /// Gets the delete command.
        /// </summary>
        /// <value>The delete command.</value>
        public ICommand DeleteCommand
        {
            get { return _deleteCommand ?? (_deleteCommand = new RelayCommand<int>(ExecuteDeleteCommand)); }
        }

        /// <summary>
        /// Executes the delete command.
        /// </summary>
        /// <param name="index">Index.</param>
        public void ExecuteDeleteCommand(int index)
        {
            Items.RemoveAt(index);
            OnPropertyChanged("Items");
        }

        private RelayCommand<int> _deleteIdCommand;

        /// <summary>
        /// Gets the delete identifier command.
        /// </summary>
        /// <value>The delete identifier command.</value>
        public ICommand DeleteIdCommand
        {
            get { return _deleteIdCommand ?? (_deleteIdCommand = new RelayCommand<int>(ExecuteDeleteIdCommand)); }
        }

        /// <summary>
        /// Executes the delete identifier command.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void ExecuteDeleteIdCommand(int id)
        {
            Items.Remove(Items.FirstOrDefault(i => i.Id == id));
            OnPropertyChanged("Items");
        }
    }
}