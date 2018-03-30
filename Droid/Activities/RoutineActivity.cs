using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using RevTrainer.Models;

namespace RevTrainer.Droid.Activities
{
    /// <summary>
    /// Routine activity.
    /// </summary>
    [Activity(Label = "RoutineActivity", Theme = "@style/android:Theme.Holo.Light")]
    public class RoutineActivity : AppCompatActivity
    {
        private Level _level;

        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.RoutineActivity);

            _level = JsonConvert.DeserializeObject<Level>(Intent.GetStringExtra("Level"));

            SupportActionBar.Title = _level.Title;
        }

        /// <summary>
        /// Ons the start.
        /// </summary>
        protected override void OnStart()
        {
            base.OnStart();
        }

        /// <summary>
        /// Ons the restart.
        /// </summary>
		protected override void OnRestart()
        {
            base.OnRestart();
        }

        /// <summary>
        /// Ons the resume.
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();
        }

        /// <summary>
        /// Ons the pause.
        /// </summary>
        protected override void OnPause()
        {
            base.OnPause();
        }

        /// <summary>
        /// Ons the stop.
        /// </summary>
        protected override void OnStop()
        {
            base.OnStop();
        }

        /// <summary>
        /// Ons the destroy.
        /// </summary>
        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        /// <summary>
        /// Ons the create options menu.
        /// </summary>
        /// <returns><c>true</c>, if create options menu was oned, <c>false</c> otherwise.</returns>
        /// <param name="menu">Menu.</param>
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.RoutineMenu, menu);

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
                case 1:
                    Toast.MakeText(this, "Rewind is Clicked", ToastLength.Short).Show();
                    return true;
                case 2:
                    Toast.MakeText(this, "Play is Clicked", ToastLength.Short).Show();
                    return true;
                case 3:
                    Toast.MakeText(this, "Pause is Clicked", ToastLength.Short).Show();
                    return true;
                case 4:
                    Toast.MakeText(this, "Stop is Clicked", ToastLength.Short).Show();
                    return true;
                case 5:
                    Toast.MakeText(this, "Fast Forward is Clicked", ToastLength.Short).Show();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}
