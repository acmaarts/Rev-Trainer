
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

namespace RevTrainer.Droid.Views
{
    /// <summary>
    /// Grid view.
    /// </summary>
    public class GridView : View
    {
        private Paint _paint = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RevTrainer.Droid.Views.GridView"/> class.
        /// </summary>
        /// <param name="context">Context.</param>
        public GridView(Context context) : base(context)
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RevTrainer.Droid.Views.GridView"/> class.
        /// </summary>
        /// <param name="context">Context.</param>
        /// <param name="attrs">Attrs.</param>
        public GridView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RevTrainer.Droid.Views.GridView"/> class.
        /// </summary>
        /// <param name="context">Context.</param>
        /// <param name="attrs">Attrs.</param>
        /// <param name="defStyle">Def style.</param>
        public GridView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
            Initialize();
        }

        private void Initialize()
        {
            _paint = new Paint();
            _paint.Color = Color.LightGray;
            _paint.StrokeWidth = 1.0f;
        }

        /// <summary>
        /// Ons the draw.
        /// </summary>
        /// <param name="canvas">Canvas.</param>
        protected override void OnDraw(Canvas canvas)
        {
            var distanceBetweenHorizalLines = RootView.Height / 10;
            var distanceBetweenVerticalLines = RootView.Width / 10;

            // Draw Horizontal lines
            for (int idx = 1; idx < 10; idx++)
            {
                canvas.DrawLine(0, distanceBetweenHorizalLines * idx, RootView.Width, distanceBetweenHorizalLines * idx, _paint);
            }

            // Draw Vertical lines
            for (int idx = 1; idx < 10; idx++)
            {
                canvas.DrawLine(distanceBetweenVerticalLines * idx, 0, distanceBetweenVerticalLines * idx, RootView.Height, _paint);
            }
        }
    }
}
