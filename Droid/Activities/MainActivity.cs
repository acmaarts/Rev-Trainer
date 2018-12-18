using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Android.Support.V7.App;
using System;
using Android.Graphics;
using RevTrainer.Droid.Views;
using RevTrainer.ViewModels;
using RevTrainer.Models;
using GridView = RevTrainer.Droid.Views.GridView;
using Android.Media;
using System.IO;
using Android;
using Android.Content;
using System.Threading.Tasks;

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
    public class MainActivity : AppCompatActivity,
                    View.IOnTouchListener,
                    ViewTreeObserver.IOnGlobalLayoutListener,
                    MediaScannerConnection.IOnScanCompletedListener
    {
        private static Java.Lang.Object VIENNA_KITE_TAG = 1;
        private static Java.Lang.Object TIM_KITE_TAG = 2;
        private static Java.Lang.Object MARIO_KITE_TAG = 3;
        private static Java.Lang.Object TWAN_KITE_TAG = 4;
        private static Java.Lang.Object JUDITH_KITE_TAG = 5;
        private static Java.Lang.Object SANNE_KITE_TAG = 6;

        private IMainViewModel _viewModel;

        private ViewGroup _root;
        private GridView _gridView;
        private DrawView _drawView;
        private TextView _commentView;

        private EditText _input;

        private IMenuItem _ccwMenuItem;
        private IMenuItem _cwMenuItem;

        private int _oldX;
        private int _oldY;

        private int _oldRawX;
        private int _oldRawY;

        private ImageView _pilotVienna;
        private ImageView _pilotTim;
        private ImageView _pilotMario;
        private ImageView _pilotTwan;
        private ImageView _pilotJudith;
        private ImageView _pilotSanne;

        private ImageView _kiteVienna;
        private ImageView _kiteTim;
        private ImageView _kiteMario;
        private ImageView _kiteTwan;
        private ImageView _kiteJudith;
        private ImageView _kiteSanne;

        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _viewModel = new MainViewModel();

            AppCenter.Start("9a8ccfd3-c903-46b9-82a9-67afbd2af425", typeof(Analytics), typeof(Crashes));

            SetContentView(Resource.Layout.Main);

            _root = FindViewById<ViewGroup>(Resource.Id.root);
            _root.SetBackgroundColor(Color.White);
            _root.ViewTreeObserver.AddOnGlobalLayoutListener(this);
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

            if (CheckSelfPermission(Manifest.Permission.WriteExternalStorage) != Permission.Granted)
            {
                RequestPermissions(new string[] { Manifest.Permission.WriteExternalStorage }, 0);
            }
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

        private void AskForResetConfirmation()
        {
            var alertDialog = new Android.App.AlertDialog.Builder(this);
            alertDialog.SetTitle("Reset");
            alertDialog.SetMessage("Are you sure you want to reset the simulation?");
            alertDialog.SetCancelable(false);
            alertDialog.SetPositiveButton("Yes", (s, e) =>
            {
                Reset();
            });

            alertDialog.SetNegativeButton("No", (s, e) => { });

            alertDialog.Show();
        }

        private void Reset()
        {
            TurningButtonPressed(true);

            _root.RemoveAllViews();

            _gridView = new GridView(this);
            _root.AddView(_gridView);

            _drawView = new DrawView(this);
            _root.AddView(_drawView);

            _commentView = new TextView(this);
            _commentView.SetTextColor(Color.DarkRed);
            var layoutParams = new RelativeLayout.LayoutParams(400, 250)
            {
                LeftMargin = 100,
                TopMargin = 100
            };
            _commentView.LayoutParameters = layoutParams;
            _root.AddView(_commentView);

            DrawPilots();
            DrawRevKites();

            _root.Post(() =>
            {
                _viewModel.Team.Pilots.Clear();
                _viewModel.AddPilot(new Pilot
                {
                    Name = "Vienna",
                    PlaceInLine = 1,
                    Position = new Position
                    {
                        X = _pilotVienna.GetX(),
                        Y = _pilotVienna.GetY()
                    },
                    Kite = new Kite
                    {
                        Rotation = _kiteVienna.Rotation,
                        Position = new Position
                        {
                            X = _kiteVienna.GetX(),
                            Y = _kiteVienna.GetY()
                        }
                    }
                });

                _viewModel.AddPilot(new Pilot
                {
                    Name = "Tim",
                    PlaceInLine = 2,
                    Position = new Position
                    {
                        X = _pilotTim.GetX(),
                        Y = _pilotTim.GetY()
                    },
                    Kite = new Kite
                    {
                        Rotation = _kiteTim.Rotation,
                        Position = new Position
                        {
                            X = _kiteTim.GetX(),
                            Y = _kiteTim.GetY()
                        }
                    }
                });

                _viewModel.AddPilot(new Pilot
                {
                    Name = "Mario",
                    PlaceInLine = 3,
                    Position = new Position
                    {
                        X = _pilotMario.GetX(),
                        Y = _pilotMario.GetY()
                    },
                    Kite = new Kite
                    {
                        Rotation = _kiteMario.Rotation,
                        Position = new Position
                        {
                            X = _kiteMario.GetX(),
                            Y = _kiteMario.GetY()
                        }
                    }
                });

                _viewModel.AddPilot(new Pilot
                {
                    Name = "Twan",
                    PlaceInLine = 4,
                    Position = new Position
                    {
                        X = _pilotTwan.GetX(),
                        Y = _pilotTwan.GetY()
                    },
                    Kite = new Kite
                    {
                        Rotation = _kiteTwan.Rotation,
                        Position = new Position
                        {
                            X = _kiteTwan.GetX(),
                            Y = _kiteTwan.GetY()
                        }
                    }
                });

                _viewModel.AddPilot(new Pilot
                {
                    Name = "Judith",
                    PlaceInLine = 5,
                    Position = new Position
                    {
                        X = _pilotJudith.GetX(),
                        Y = _pilotJudith.GetY()
                    },
                    Kite = new Kite
                    {
                        Rotation = _kiteJudith.Rotation,
                        Position = new Position
                        {
                            X = _kiteJudith.GetX(),
                            Y = _kiteJudith.GetY()
                        }
                    }
                });

                _viewModel.AddPilot(new Pilot
                {
                    Name = "Sanne",
                    PlaceInLine = 6,
                    Position = new Position
                    {
                        X = _pilotSanne.GetX(),
                        Y = _pilotSanne.GetY()
                    },
                    Kite = new Kite
                    {
                        Rotation = _kiteSanne.Rotation,
                        Position = new Position
                        {
                            X = _kiteSanne.GetX(),
                            Y = _kiteSanne.GetY()
                        }
                    }
                });

                _drawView.UpdateTeam(_viewModel.Team);
                _drawView.Invalidate();
            });
        }

        private void DrawPilots()
        {
            var horizontalCenter = _root.Width / 2;

            _pilotVienna = new ImageView(this);
            _pilotVienna.SetImageResource(Resource.Drawable.Pilot);
            var layoutParams = new RelativeLayout.LayoutParams(20, 20)
            {
                LeftMargin = horizontalCenter + 490,
                TopMargin = _root.Height - 10
            };
            _pilotVienna.LayoutParameters = layoutParams;
            _root.AddView(_pilotVienna);

            _pilotTim = new ImageView(this);
            _pilotTim.SetImageResource(Resource.Drawable.Pilot);
            layoutParams = new RelativeLayout.LayoutParams(20, 20)
            {
                LeftMargin = horizontalCenter + 290,
                TopMargin = _root.Height - 10
            };
            _pilotTim.LayoutParameters = layoutParams;
            _root.AddView(_pilotTim);

            _pilotMario = new ImageView(this);
            _pilotMario.SetImageResource(Resource.Drawable.Pilot);
            layoutParams = new RelativeLayout.LayoutParams(20, 20)
            {
                LeftMargin = horizontalCenter + 90,
                TopMargin = _root.Height - 10
            };
            _pilotMario.LayoutParameters = layoutParams;
            _root.AddView(_pilotMario);

            _pilotTwan = new ImageView(this);
            _pilotTwan.SetImageResource(Resource.Drawable.Pilot);
            layoutParams = new RelativeLayout.LayoutParams(20, 20)
            {
                LeftMargin = horizontalCenter - 110,
                TopMargin = _root.Height - 10
            };
            _pilotTwan.LayoutParameters = layoutParams;
            _root.AddView(_pilotTwan);

            _pilotJudith = new ImageView(this);
            _pilotJudith.SetImageResource(Resource.Drawable.Pilot);
            layoutParams = new RelativeLayout.LayoutParams(20, 20)
            {
                LeftMargin = horizontalCenter - 310,
                TopMargin = _root.Height - 10
            };
            _pilotJudith.LayoutParameters = layoutParams;
            _root.AddView(_pilotJudith);

            _pilotSanne = new ImageView(this);
            _pilotSanne.SetImageResource(Resource.Drawable.Pilot);
            layoutParams = new RelativeLayout.LayoutParams(20, 20)
            {
                LeftMargin = horizontalCenter - 510,
                TopMargin = _root.Height - 10
            };
            _pilotSanne.LayoutParameters = layoutParams;
            _root.AddView(_pilotSanne);
        }

        private void DrawRevKites()
        {
            var baseWidth = (_root.Width - 1175) / 2;
            var baseHeight = _root.Height - 50;

            _kiteVienna = new ImageView(this);
            _kiteVienna.SetImageResource(Resource.Drawable.Vienna);
            _kiteVienna.Tag = VIENNA_KITE_TAG;
            var layoutParams = new RelativeLayout.LayoutParams(175, 60)
            {
                LeftMargin = baseWidth + 1000,
                TopMargin = baseHeight
            };
            _kiteVienna.LayoutParameters = layoutParams;
            _kiteVienna.SetOnTouchListener(this);
            _root.AddView(_kiteVienna);

            _kiteTim = new ImageView(this);
            _kiteTim.SetImageResource(Resource.Drawable.Tim);
            _kiteTim.Tag = TIM_KITE_TAG;
            layoutParams = new RelativeLayout.LayoutParams(175, 60)
            {
                LeftMargin = baseWidth + 800,
                TopMargin = baseHeight
            };
            _kiteTim.LayoutParameters = layoutParams;
            _kiteTim.SetOnTouchListener(this);
            _root.AddView(_kiteTim);

            _kiteMario = new ImageView(this);
            _kiteMario.SetImageResource(Resource.Drawable.Mario);
            _kiteMario.Tag = MARIO_KITE_TAG;
            layoutParams = new RelativeLayout.LayoutParams(175, 60)
            {
                LeftMargin = baseWidth + 600,
                TopMargin = baseHeight
            };
            _kiteMario.LayoutParameters = layoutParams;
            _kiteMario.SetOnTouchListener(this);
            _root.AddView(_kiteMario);

            _kiteTwan = new ImageView(this);
            _kiteTwan.SetImageResource(Resource.Drawable.Twan);
            _kiteTwan.Tag = TWAN_KITE_TAG;
            layoutParams = new RelativeLayout.LayoutParams(175, 60)
            {
                LeftMargin = baseWidth + 400,
                TopMargin = baseHeight
            };
            _kiteTwan.LayoutParameters = layoutParams;
            _kiteTwan.SetOnTouchListener(this);
            _root.AddView(_kiteTwan);

            _kiteJudith = new ImageView(this);
            _kiteJudith.SetImageResource(Resource.Drawable.Judith);
            _kiteJudith.Tag = JUDITH_KITE_TAG;
            layoutParams = new RelativeLayout.LayoutParams(175, 60)
            {
                LeftMargin = baseWidth + 200,
                TopMargin = baseHeight
            };
            _kiteJudith.LayoutParameters = layoutParams;
            _kiteJudith.SetOnTouchListener(this);
            _root.AddView(_kiteJudith);

            _kiteSanne = new ImageView(this);
            _kiteSanne.SetImageResource(Resource.Drawable.Sanne);
            _kiteSanne.Tag = SANNE_KITE_TAG;
            layoutParams = new RelativeLayout.LayoutParams(175, 60)
            {
                LeftMargin = baseWidth,
                TopMargin = baseHeight
            };
            _kiteSanne.LayoutParameters = layoutParams;
            _kiteSanne.SetOnTouchListener(this);
            _root.AddView(_kiteSanne);
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
                    _oldX = rawX - layoutParams.LeftMargin;
                    _oldY = rawY - layoutParams.TopMargin;

                    _oldRawX = rawX;
                    _oldRawY = rawY;
                    break;
                case MotionEventActions.Up:
                    var rawXDelta = Math.Abs(rawX - _oldRawX);
                    var rawYDelta = Math.Abs(rawY - _oldRawY);

                    if (rawXDelta < 15 && rawYDelta < 15)
                    {
                        if (_viewModel.IsTurningClockwise)
                        {
                            v.Rotation += 45.0f;
                        }
                        else
                        {
                            v.Rotation -= 45.0f;
                        }

                        _viewModel.RotateKite((int)v.Tag);
                    }
                    break;
                case MotionEventActions.PointerDown:
                    break;
                case MotionEventActions.PointerUp:
                    break;
                case MotionEventActions.Move:
                    var xDelta = rawX - _oldX;
                    var yDelta = rawY - _oldY;

                    layoutParams = v.LayoutParameters as RelativeLayout.LayoutParams;
                    layoutParams.LeftMargin = xDelta;
                    layoutParams.TopMargin = yDelta;
                    v.LayoutParameters = layoutParams;

                    _viewModel.MoveKite((int)v.Tag, new Position
                    { 
                        X = v.GetX(),
                        Y = v.GetY()
                    });
                    break;
            }

            _drawView.UpdateTeam(_viewModel.Team);
            _root.Invalidate();
            _drawView.Invalidate();
            return true;
        }

        private void AskForComment()
        {
            var alertDialog = new Android.App.AlertDialog.Builder(this);
            alertDialog.SetTitle("Comment");
            alertDialog.SetMessage("Enter a comment to add on the image");
            _input = new EditText(this);
            var layoutParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);
            _input.LayoutParameters = layoutParams;
            alertDialog.SetView(_input);
            alertDialog.SetPositiveButton("Add", (s, e) =>
            {
                Reset();

                AddComment(_input.Text);
                Task.Run(TakeScreenshot);
            });
            alertDialog.SetNeutralButton("Proceed without", (s, e) =>
            {
                Task.Run(TakeScreenshot);
            });
            alertDialog.SetNegativeButton("Cancel", (s, e) => { });

            alertDialog.Show();
        }

        private async Task TakeScreenshot()
        {
            RunOnUiThread(() =>
            {
                _commentView.Visibility = ViewStates.Visible;

                _gridView.Visibility = ViewStates.Invisible;
                _drawView.Visibility = ViewStates.Invisible;

                _pilotVienna.Visibility = ViewStates.Invisible;
                _pilotTim.Visibility = ViewStates.Invisible;
                _pilotMario.Visibility = ViewStates.Invisible;
                _pilotTwan.Visibility = ViewStates.Invisible;
                _pilotJudith.Visibility = ViewStates.Invisible;
                _pilotSanne.Visibility = ViewStates.Invisible;
            });

            await Task.Delay(50).ConfigureAwait(false);

            _root.DrawingCacheEnabled = true;
            _root.BuildDrawingCache(true);
            var bitmap = Bitmap.CreateBitmap(_root.DrawingCache);
            _root.DrawingCacheEnabled = false;

            var fileName = string.Format("{0}.png", DateTimeOffset.Now.ToString());

            var basePath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            var filePath = System.IO.Path.Combine(basePath, "United Wings", fileName);

            if (!Directory.Exists(System.IO.Path.Combine(basePath, "United Wings")))
            {
                Directory.CreateDirectory(System.IO.Path.Combine(basePath, "United Wings"));
            }

            var stream = new FileStream(filePath, FileMode.Create);
            await bitmap.CompressAsync(Bitmap.CompressFormat.Png, 100, stream).ConfigureAwait(false);
            stream.Close();

            RunOnUiThread(() =>
            {
                _commentView.Visibility = ViewStates.Invisible;

                _gridView.Visibility = ViewStates.Visible;
                _drawView.Visibility = ViewStates.Visible;

                _pilotVienna.Visibility = ViewStates.Visible;
                _pilotTim.Visibility = ViewStates.Visible;
                _pilotMario.Visibility = ViewStates.Visible;
                _pilotTwan.Visibility = ViewStates.Visible;
                _pilotJudith.Visibility = ViewStates.Visible;
                _pilotSanne.Visibility = ViewStates.Visible;

                Toast.MakeText(BaseContext, "Screenshot saved", ToastLength.Short).Show();
            });

            MediaScannerConnection.ScanFile(ApplicationContext, new string[] { filePath }, null, this);
        }

        private void AddComment(string comment)
        {
            _commentView.Text = comment;
        }

        /// <summary>
        /// Ons the scan completed.
        /// </summary>
        /// <param name="path">Path.</param>
        /// <param name="uri">URI.</param>
        public void OnScanCompleted(string path, Android.Net.Uri uri)
        {
            Console.WriteLine(string.Format("ExternalStorage Scanned {0} : ExternalStorage -> uri={1}", path, uri));
        }

        void ViewTreeObserver.IOnGlobalLayoutListener.OnGlobalLayout()
        {
            _root.ViewTreeObserver.RemoveOnGlobalLayoutListener(this);
            Reset();
        }

        /// <summary>
        /// Ons the create options menu.
        /// </summary>
        /// <returns><c>true</c>, if create options menu was oned, <c>false</c> otherwise.</returns>
        /// <param name="menu">Menu.</param>
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);

            _cwMenuItem = menu.FindItem(Resource.Id.action_cw);
            _ccwMenuItem = menu.FindItem(Resource.Id.action_ccw);

            TurningButtonPressed(true);

            return true;
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
                case Resource.Id.action_cw:
                    TurningButtonPressed(true);
                    break;
                case Resource.Id.action_ccw:
                    TurningButtonPressed(false);
                    break;
                case Resource.Id.action_reset:
                    AskForResetConfirmation();
                    break;
                case Resource.Id.action_screenshot:
                    AskForComment();
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void TurningButtonPressed(bool turningClockwise)
        {
            _viewModel.IsTurningClockwise = turningClockwise;

            if (_ccwMenuItem != null && _cwMenuItem != null)
            {
                _ccwMenuItem.SetVisible(_viewModel.IsTurningClockwise);
                _cwMenuItem.SetVisible(!_viewModel.IsTurningClockwise);
            }
        }
    }
}