using System;
using System.Threading.Tasks;
using CoreGraphics;
using RevTrainer.iOS.Views;
using RevTrainer.Models;
using RevTrainer.ViewModels;
using UIKit;

namespace RevTrainer.iOS.ViewControllers
{
    /// <summary>
    /// Main view controller.
    /// </summary>
    public partial class MainViewController : UIViewController
    {
        private static nint VIENNA_KITE_TAG = 1;
        private static nint TIM_KITE_TAG = 2;
        private static nint MARIO_KITE_TAG = 3;
        private static nint TWAN_KITE_TAG = 4;
        private static nint JUDITH_KITE_TAG = 5;
        private static nint SANNE_KITE_TAG = 6;

        private IMainViewModel _viewModel;

        private GridView _gridView;
        private DrawView _drawView;
        private UILabel _commentView;

        private UIBarButtonItem _ccwMenuItem;
        private UIBarButtonItem _cwMenuItem;

        private int _oldX;
        private int _oldY;

        private int _oldRawX;
        private int _oldRawY;

        private UIImageView _pilotVienna;
        private UIImageView _pilotTim;
        private UIImageView _pilotMario;
        private UIImageView _pilotTwan;
        private UIImageView _pilotJudith;
        private UIImageView _pilotSanne;

        private UIImageView _kiteVienna;
        private UIImageView _kiteTim;
        private UIImageView _kiteMario;
        private UIImageView _kiteTwan;
        private UIImageView _kiteJudith;
        private UIImageView _kiteSanne;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RevTrainer.iOS.ViewControllers.MainViewController"/> class.
        /// </summary>
        public MainViewController() : base("MainViewController", null)
        {
            _viewModel = new MainViewModel();
        }

        /// <summary>
        /// Views the did load.
        /// </summary>
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.White;
            Reset();
        }

        /// <summary>
        /// Dids the receive memory warning.
        /// </summary>
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        private void AskForResetConfirmation()
        {
            /*var alertDialog = new Android.App.AlertDialog.Builder(this);
            alertDialog.SetTitle("Reset");
            alertDialog.SetMessage("Are you sure you want to reset the simulation?");
            alertDialog.SetCancelable(false);
            alertDialog.SetPositiveButton("Yes", (s, e) =>
            {
                Reset();
            });

            alertDialog.SetNegativeButton("No", (s, e) => { });

            alertDialog.Show();*/
        }

        private void Reset()
        {
            TurningButtonPressed(true);

            //View.RemoveAllViews();

            _gridView = new GridView();
            View.AddSubview(_gridView);

            _drawView = new DrawView();
            View.AddSubview(_drawView);

            _commentView = new UILabel(new CGRect(100, 100, 400, 250))
            {
                TextColor = UIColor.Red
            };
            View.AddSubview(_commentView);

            DrawPilots();
            DrawRevKites();

            _viewModel.Team.Pilots.Clear();
            _viewModel.AddPilot(new Pilot
            {
                Name = "Vienna",
                PlaceInLine = 1,
                Position = new Position
                {
                    X = (float)_pilotVienna.Frame.X,
                    Y = (float)_pilotVienna.Frame.Y
                },
                Kite = new Kite
                {
                    //Rotation = _kiteVienna.Rotation,
                    Position = new Position
                    {
                        X = (float)_kiteVienna.Frame.X,
                        Y = (float)_kiteVienna.Frame.Y
                    }
                }
            });

            _viewModel.AddPilot(new Pilot
            {
                Name = "Tim",
                PlaceInLine = 2,
                Position = new Position
                {
                    X = (float)_pilotTim.Frame.X,
                    Y = (float)_pilotTim.Frame.Y
                },
                Kite = new Kite
                {
                    //Rotation = _kiteTim.Rotation,
                    Position = new Position
                    {
                        X = (float)_kiteTim.Frame.X,
                        Y = (float)_kiteTim.Frame.Y
                    }
                }
            });

            _viewModel.AddPilot(new Pilot
            {
                Name = "Mario",
                PlaceInLine = 3,
                Position = new Position
                {
                    X = (float)_pilotMario.Frame.X,
                    Y = (float)_pilotMario.Frame.Y
                },
                Kite = new Kite
                {
                    //Rotation = _kiteMario.Rotation,
                    Position = new Position
                    {
                        X = (float)_kiteMario.Frame.X,
                        Y = (float)_kiteMario.Frame.Y
                    }
                }
            });

            _viewModel.AddPilot(new Pilot
            {
                Name = "Twan",
                PlaceInLine = 4,
                Position = new Position
                {
                    X = (float)_pilotTwan.Frame.X,
                    Y = (float)_pilotTwan.Frame.Y
                },
                Kite = new Kite
                {
                    //Rotation = _kiteTwan.Rotation,
                    Position = new Position
                    {
                        X = (float)_kiteTwan.Frame.X,
                        Y = (float)_kiteTwan.Frame.Y
                    }
                }
            });

            _viewModel.AddPilot(new Pilot
            {
                Name = "Judith",
                PlaceInLine = 5,
                Position = new Position
                {
                    X = (float)_pilotJudith.Frame.X,
                    Y = (float)_pilotJudith.Frame.Y
                },
                Kite = new Kite
                {
                    //Rotation = _kiteJudith.Rotation,
                    Position = new Position
                    {
                        X = (float)_kiteJudith.Frame.X,
                        Y = (float)_kiteJudith.Frame.Y
                    }
                }
            });

            _viewModel.AddPilot(new Pilot
            {
                Name = "Sanne",
                PlaceInLine = 6,
                Position = new Position
                {
                    X = (float)_pilotSanne.Frame.X,
                    Y = (float)_pilotSanne.Frame.Y
                },
                Kite = new Kite
                {
                    //Rotation = _kiteSanne.Rotation,
                    Position = new Position
                    {
                        X = (float)_kiteSanne.Frame.X,
                        Y = (float)_kiteSanne.Frame.Y
                    }
                }
            });

            //_drawView.UpdateTeam(_viewModel.Team);
            //_drawView.Invalidate();
        }

        private void DrawPilots()
        {
            var horizontalCenter = View.Frame.Width / 2;

            _pilotVienna = new UIImageView(new CGRect(horizontalCenter + 490, View.Frame.Height - 10, 20, 20))
            {
                Image = new UIImage("Pilot")
            };
            View.AddSubview(_pilotVienna);

            _pilotTim = new UIImageView(new CGRect(horizontalCenter + 290, View.Frame.Height - 10, 20, 20))
            {
                Image = new UIImage("Pilot")
            };
            View.AddSubview(_pilotTim);

            _pilotMario = new UIImageView(new CGRect(horizontalCenter + 90, View.Frame.Height - 10, 20, 20))
            {
                Image = new UIImage("Pilot")
            };
            View.AddSubview(_pilotMario);

            _pilotTwan = new UIImageView(new CGRect(horizontalCenter - 110, View.Frame.Height - 10, 20, 20))
            {
                Image = new UIImage("Pilot")
            };
            View.AddSubview(_pilotTwan);

            _pilotJudith = new UIImageView(new CGRect(horizontalCenter - 310, View.Frame.Height - 10, 20, 20))
            {
                Image = new UIImage("Pilot")
            };
            View.AddSubview(_pilotJudith);

            _pilotSanne = new UIImageView(new CGRect(horizontalCenter - 510, View.Frame.Height - 10, 20, 20))
            {
                Image = new UIImage("Pilot")
            };
            View.AddSubview(_pilotSanne);
        }

        private void DrawRevKites()
        {
            var baseWidth = (View.Frame.Width - 1175) / 2;
            var baseHeight = View.Frame.Height - 50;

            _kiteVienna = new UIImageView(new CGRect(baseWidth + 1000, baseHeight, 175, 60))
            {
                Image = new UIImage("Vienna"),
                Tag = VIENNA_KITE_TAG
            };
            //_kiteVienna.SetOnTouchListener(this);
            View.AddSubview(_kiteVienna);

            _kiteTim = new UIImageView(new CGRect(baseWidth + 800, baseHeight, 175, 60))
            {
                Image = new UIImage("Tim"),
                Tag = TIM_KITE_TAG
            };
            //_kiteTim.SetOnTouchListener(this);
            View.AddSubview(_kiteTim);

            _kiteMario = new UIImageView(new CGRect(baseWidth + 600, baseHeight, 175, 60))
            {
                Image = new UIImage("Mario"),
                Tag = MARIO_KITE_TAG
            };
            //_kiteMario.SetOnTouchListener(this);
            View.AddSubview(_kiteMario);

            _kiteTwan = new UIImageView(new CGRect(baseWidth + 400, baseHeight, 175, 60))
            {
                Image = new UIImage("Twan"),
                Tag = TWAN_KITE_TAG
            };
            //_kiteTwan.SetOnTouchListener(this);
            View.AddSubview(_kiteTwan);

            _kiteJudith = new UIImageView(new CGRect(baseWidth + 200, baseHeight, 175, 60))
            {
                Image = new UIImage("Judith"),
                Tag = JUDITH_KITE_TAG
            };
            //_kiteJudith.SetOnTouchListener(this);
            View.AddSubview(_kiteJudith);

            _kiteSanne = new UIImageView(new CGRect(baseWidth, baseHeight, 175, 60))
            {
                Image = new UIImage("Sanne"),
                Tag = SANNE_KITE_TAG
            };
            //_kiteSanne.SetOnTouchListener(this);
            View.AddSubview(_kiteSanne);
        }

        /*bool View.IOnTouchListener.OnTouch(View v, MotionEvent e)
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
                    layoutParams = v.LayoutParameters as RelativeLayout.LayoutParams;
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
                        X = v.Frame.X,
                        Y = v.Frame.Y
                    });
                    break;
            }

            _drawView.UpdateTeam(_viewModel.Team);
            View.Invalidate();
            _drawView.Invalidate();
            return true;
        }*/

        private void AskForComment()
        {
            /*var alertDialog = new Android.App.AlertDialog.Builder(this);
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

            alertDialog.Show();*/
        }

        private async Task TakeScreenshot()
        {
            _commentView.Hidden = false;

            _gridView.Hidden = true;
            _drawView.Hidden = true;

            _pilotVienna.Hidden = true;
            _pilotTim.Hidden = true;
            _pilotMario.Hidden = true;
            _pilotTwan.Hidden = true;
            _pilotJudith.Hidden = true;
            _pilotSanne.Hidden = true;

            await Task.Delay(50).ConfigureAwait(false);

            /*View.DrawingCacheEnabled = true;
            View.BuildDrawingCache(true);
            var bitmap = Bitmap.CreateBitmap(View.DrawingCache);
            View.DrawingCacheEnabled = false;

            var fileName = string.Format("{0}.png", DateTimeOffset.Now.ToString());

            var basePath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            var filePath = System.IO.Path.Combine(basePath, "United Wings", fileName);

            if (!Directory.Exists(System.IO.Path.Combine(basePath, "United Wings")))
            {
                Directory.CreateDirectory(System.IO.Path.Combine(basePath, "United Wings"));
            }

            var stream = new FileStream(filePath, FileMode.Create);
            await bitmap.CompressAsync(Bitmap.CompressFormat.Png, 100, stream).ConfigureAwait(false);
            stream.Close();*/

            _commentView.Hidden = true;

            _gridView.Hidden = false;
            _drawView.Hidden = false;

            _pilotVienna.Hidden = false;
            _pilotTim.Hidden = false;
            _pilotMario.Hidden = false;
            _pilotTwan.Hidden = false;
            _pilotJudith.Hidden = false;
            _pilotSanne.Hidden = false;

            //Toast.MakeText(BaseContext, "Screenshot saved", ToastLength.Short).Show();
        }

        private void AddComment(string comment)
        {
            _commentView.Text = comment;
        }

        private void TurningButtonPressed(bool turningClockwise)
        {
            _viewModel.IsTurningClockwise = turningClockwise;

            if (_ccwMenuItem != null && _cwMenuItem != null)
            {
                _ccwMenuItem.Enabled = _viewModel.IsTurningClockwise;
                _cwMenuItem.Enabled = !_viewModel.IsTurningClockwise;
            }
        }
    }
}

