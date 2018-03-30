using System.Collections.Generic;
using System.Collections.ObjectModel;
using Android.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using RevTrainer.Models;

namespace RevTrainer.Droid.Adapters
{
    /// <summary>
    /// Level list adapter.
    /// </summary>
    public class LevelListAdapter : BaseAdapter
    {
        private Activity _activity;
        private readonly IList<Level> _items;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RevTrainer.Droid.Adapters.LevelListAdapter"/> class.
        /// </summary>
        /// <param name="activity">Activity.</param>
        /// <param name="items">Items.</param>
        public LevelListAdapter(Activity activity, IList<Level> items)
        {
            _activity = activity;
            _items = items;
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
            var view = convertView ?? _activity.LayoutInflater.Inflate(Resource.Layout.LevelListView, parent, false);

            var levelTitle = view.FindViewById<TextView>(Resource.Id.title);
            levelTitle.Text = _items[position].Title;

            return view;
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <returns>The item.</returns>
        /// <param name="position">Position.</param>
		public override Object GetItem(int position)
        {
            return null;
        }

        /// <summary>
        /// Gets the item identifier.
        /// </summary>
        /// <returns>The item identifier.</returns>
        /// <param name="position">Position.</param>
		public override long GetItemId(int position)
        {
            return _items[position].Id;
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public override int Count
        {
            get { return _items.Count; }
        }
    }
}