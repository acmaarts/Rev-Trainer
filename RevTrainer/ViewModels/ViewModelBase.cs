using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
        /// Ons the property changed.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Ons the property changed.
        /// </summary>
        /// <param name="expression">Expression.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        protected void OnPropertyChanged<T>(System.Linq.Expressions.Expression<Func<T>> expression)
        {
            string propertyName = null;
            if (null != expression)
            {
                var member = expression.Body as System.Linq.Expressions.MemberExpression;
                if (null != member)
                {
                    propertyName = member.Member.Name;
                }
            }
            OnPropertyChanged(propertyName);
        }
    }
}
