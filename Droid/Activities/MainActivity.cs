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
using Android.Support.V7.App;

namespace RevTrainer.Droid
{
    /// <summary>
    /// Main activity.
    /// </summary>
    [Activity(Label = "@string/app_name", Icon = "@mipmap/icon",
        Theme = "@style/Theme.AppCompat.Light.DarkActionBar",
        LaunchMode = LaunchMode.SingleInstance,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Landscape)]
    public class MainActivity : AppCompatActivity
    {
        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
		protected override void OnCreate(Bundle savedInstanceState)
		{
            base.OnCreate(savedInstanceState);

            AppCenter.Start("9a8ccfd3-c903-46b9-82a9-67afbd2af425", typeof(Analytics), typeof(Crashes));

            SetContentView(Resource.Layout.Main);
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
	}
}