using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
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
    public class MainActivity : AppCompatActivity, View.IOnTouchListener, ViewTreeObserver.IOnGlobalLayoutListener
    {
        private ViewGroup root;

        private int xDelta;
        private int yDelta;

        private ImageView vienna;
        private ImageView tim;
        private ImageView mario;
        private ImageView twan;
        private ImageView judith;
        private ImageView sanne;

        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
		protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            AppCenter.Start("9a8ccfd3-c903-46b9-82a9-67afbd2af425", typeof(Analytics), typeof(Crashes));

            SetContentView(Resource.Layout.Main);

            root = FindViewById<ViewGroup>(Resource.Id.root);
            root.ViewTreeObserver.AddOnGlobalLayoutListener(this);
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

        private void DrawRevKites()
        {
            var baseWidth = (root.Width - 1175) / 2;
            var baseHeight = root.Height - 90;

            System.Console.WriteLine("Root Width: " + Window.DecorView.Width);
            System.Console.WriteLine("Root Height: " + Window.DecorView.Height);

            System.Console.WriteLine("Base Width: " + baseWidth);
            System.Console.WriteLine("Base Height: " + baseHeight);

            root.RemoveAllViews();

            vienna = new ImageView(this);
            vienna.SetImageResource(Resource.Drawable.Vienna);
            var layoutParams = new RelativeLayout.LayoutParams(175, 60)
            {
                LeftMargin = baseWidth + 1000,
                TopMargin = baseHeight
            };
            vienna.LayoutParameters = layoutParams;

            vienna.SetOnTouchListener(this);
            root.AddView(vienna);

            tim = new ImageView(this);
            tim.SetImageResource(Resource.Drawable.Tim);
            layoutParams = new RelativeLayout.LayoutParams(175, 60)
            {
                LeftMargin = baseWidth + 800,
                TopMargin = baseHeight
            };
            tim.LayoutParameters = layoutParams;

            tim.SetOnTouchListener(this);
            root.AddView(tim);

            mario = new ImageView(this);
            mario.SetImageResource(Resource.Drawable.Mario);
            layoutParams = new RelativeLayout.LayoutParams(175, 60)
            {
                LeftMargin = baseWidth + 600,
                TopMargin = baseHeight
            };
            mario.LayoutParameters = layoutParams;

            mario.SetOnTouchListener(this);
            root.AddView(mario);

            twan = new ImageView(this);
            twan.SetImageResource(Resource.Drawable.Twan);
            layoutParams = new RelativeLayout.LayoutParams(175, 60)
            {
                LeftMargin = baseWidth + 400,
                TopMargin = baseHeight
            };
            twan.LayoutParameters = layoutParams;

            twan.SetOnTouchListener(this);
            root.AddView(twan);

            judith = new ImageView(this);
            judith.SetImageResource(Resource.Drawable.Judith);
            layoutParams = new RelativeLayout.LayoutParams(175, 60)
            {
                LeftMargin = baseWidth + 200,
                TopMargin = baseHeight
            };
            judith.LayoutParameters = layoutParams;

            judith.SetOnTouchListener(this);
            root.AddView(judith);

            sanne = new ImageView(this);
            sanne.SetImageResource(Resource.Drawable.Sanne);
            layoutParams = new RelativeLayout.LayoutParams(175, 60)
            {
                LeftMargin = baseWidth,
                TopMargin = baseHeight
            };
            sanne.LayoutParameters = layoutParams;

            sanne.SetOnTouchListener(this);
            root.AddView(sanne);
        }

        bool View.IOnTouchListener.OnTouch(View v, MotionEvent e)
        {
            RelativeLayout.LayoutParams layoutParams;
            int rawX = (int)e.RawX;
            int rawY = (int)e.RawY;

            switch (e.Action & MotionEventActions.Mask)
            {
                case MotionEventActions.Down:
                    layoutParams = v.LayoutParameters as RelativeLayout.LayoutParams;
                    xDelta = rawX - layoutParams.LeftMargin;
                    yDelta = rawY - layoutParams.TopMargin;
                    break;
                case MotionEventActions.Up:
                    break;
                case MotionEventActions.PointerDown:
                    break;
                case MotionEventActions.PointerUp:
                    break;
                case MotionEventActions.Move:
                    layoutParams = v.LayoutParameters as RelativeLayout.LayoutParams;
                    layoutParams.LeftMargin = rawX - xDelta;
                    layoutParams.TopMargin = rawY - yDelta;
                    v.LayoutParameters = layoutParams;
                    break;
            }

            root.Invalidate();
            return true;
        }

        void ViewTreeObserver.IOnGlobalLayoutListener.OnGlobalLayout()
        {
            root.ViewTreeObserver.RemoveOnGlobalLayoutListener(this);
            DrawRevKites();
        }
    }
}