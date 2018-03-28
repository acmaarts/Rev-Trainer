using System;
using System.ComponentModel;

namespace RevTrainer.ViewModels
{
    /// <summary>
    /// View model base.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// When a property is changed notify the UI (WP/WinStore)
        /// </summary>
        /// <param name="propName"></param>
        protected virtual void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
