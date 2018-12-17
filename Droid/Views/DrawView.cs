
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using RevTrainer.Models;

namespace RevTrainer.Droid.Views
{
    /// <summary>
    /// Draw view.
    /// </summary>
    public class DrawView : View
    {
        private Paint _paint = null;
        private Team _team = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RevTrainer.Droid.Views.DrawView"/> class.
        /// </summary>
        /// <param name="context">Context.</param>
        public DrawView(Context context) : base(context)
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RevTrainer.Droid.Views.DrawView"/> class.
        /// </summary>
        /// <param name="context">Context.</param>
        /// <param name="attrs">Attrs.</param>
        public DrawView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RevTrainer.Droid.Views.DrawView"/> class.
        /// </summary>
        /// <param name="context">Context.</param>
        /// <param name="attrs">Attrs.</param>
        /// <param name="defStyle">Def style.</param>
        public DrawView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
            Initialize();
        }

        private void Initialize()
        {
            _paint = new Paint();
            _paint.Color = Color.Black;
            _paint.StrokeWidth = 1.0f;
        }

        /// <summary>
        /// Updates the team.
        /// </summary>
        /// <param name="team">Team.</param>
        public void UpdateTeam(Team team)
        {
            _team = team;
        }

        /// <summary>
        /// Ons the draw.
        /// </summary>
        /// <param name="canvas">Canvas.</param>
        protected override void OnDraw(Canvas canvas)
        {
            if (_team == null || _team.Pilots == null)
            {
                return;
            }

            foreach (var pilot in _team.Pilots)
            {
                float kiteY = pilot.Kite.Position.Y;
                if (pilot.Kite.Rotation >= 90 && pilot.Kite.Rotation <= 270)
                {
                    kiteY += 40;
                }
                else
                {
                    kiteY += 20;
                }
                canvas.DrawLine(pilot.Position.X + 10, pilot.Position.Y, pilot.Kite.Position.X + 90, kiteY, _paint);
            }
        }
    }
}
