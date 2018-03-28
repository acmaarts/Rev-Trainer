using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using RevTrainer.Droid.Activities;
using RevTrainer.Droid.Adapters;
using RevTrainer.ViewModels;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace RevTrainer.Droid
{
    /// <summary>
    /// Main activity.
    /// </summary>
    [Activity(Label = "@string/app_name", Icon = "@mipmap/icon",
        LaunchMode = LaunchMode.SingleInstance,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : ListActivity
    {
        private static MasterViewModel _viewModel;

        /// <summary>
        /// Gets the view model.
        /// </summary>
        /// <value>The view model.</value>
        public static MasterViewModel ViewModel
        {
            get { return _viewModel ?? (_viewModel = new MasterViewModel()); }
        }


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            AppCenter.Start("9a8ccfd3-c903-46b9-82a9-67afbd2af425", typeof(Analytics), typeof(Crashes));

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Master);

            ListAdapter = new MasterAdapter(this, ViewModel.Items);

            ListView.ItemLongClick += (sender, e) => {
                ViewModel.DeleteCommand.Execute(e.Position);
                ((MasterAdapter)ListAdapter).NotifyDataSetChanged();
            };
        }

        private void NavigateToDetails(int index)
        {
            var intent = new Intent(this, typeof(DetailActivity));
            intent.PutExtra("item", ViewModel.Items[index].ToString());
            StartActivity(intent);
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);
            NavigateToDetails(position);
        }

        /// <summary>
        /// Ons the create options menu.
        /// </summary>
        /// <returns><c>true</c>, if create options menu was oned, <c>false</c> otherwise.</returns>
        /// <param name="menu">Menu.</param>
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.master_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        /// <summary>
        /// Ons the options item selected.
        /// </summary>
        /// <returns><c>true</c>, if options item selected was oned, <c>false</c> otherwise.</returns>
        /// <param name="item">Item.</param>
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_add:
                    ViewModel.AddCommand.Execute(null);
                    ((MasterAdapter)ListAdapter).NotifyDataSetChanged();
                    return true;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}