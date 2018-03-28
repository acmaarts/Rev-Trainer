using System.Collections.ObjectModel;
using Android.App;
using Android.Views;
using Android.Widget;
using RevTrainer.Models;

namespace RevTrainer.Droid.Adapters
{
    /// <summary>
    /// Master adapter.
    /// </summary>
    public class MasterAdapter : BaseAdapter
    {
        private Activity _activity;
        private ObservableCollection<TimeEntry> _items;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RevTrainer.Droid.Adapters.MasterAdapter"/> class.
        /// </summary>
        /// <param name="activity">Activity.</param>
        /// <param name="items">Items.</param>
        public MasterAdapter(Activity activity, ObservableCollection<TimeEntry> items)
        {
            _activity = activity;
            _items = items;
        }

        //Wrapper class for adapter for cell re-use
        private class MasterAdapterHelper : Java.Lang.Object
        {
            public TextView Title { get; set; }
        }

        #region implemented abstract members of BaseAdapter

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <returns>The item.</returns>
        /// <param name="position">Position.</param>
        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        /// <summary>
        /// Gets the item identifier.
        /// </summary>
        /// <returns>The item identifier.</returns>
        /// <param name="position">Position.</param>
        public override long GetItemId(int position)
        {
            return position;
        }

        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <returns>The view.</returns>
        /// <param name="position">Position.</param>
        /// <param name="convertView">Convert view.</param>
        /// <param name="parent">Parent.</param>
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            MasterAdapterHelper helper = null;
            if (convertView == null)
            {
                convertView = _activity.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
                helper = new MasterAdapterHelper();
                helper.Title = convertView.FindViewById<TextView>(Android.Resource.Id.Text1);
                convertView.Tag = helper;
            }
            else
            {
                helper = convertView.Tag as MasterAdapterHelper;
            }

            helper.Title.Text = _items[position].ToString();

            return convertView;
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public override int Count
        {
            get
            {
                return _items.Count;
            }
        }

        #endregion
    }
}
