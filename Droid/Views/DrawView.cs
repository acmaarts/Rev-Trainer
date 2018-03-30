
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
    /// Draw view.
    /// </summary>
    public class DrawView : View
    {
        private Paint _paint;
        private Path _path;
        private Bitmap _revkite;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RevTrainer.Droid.DrawView"/> class.
        /// </summary>
        /// <param name="context">Context.</param>
        public DrawView(Context context) : base(context)
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RevTrainer.Droid.DrawView"/> class.
        /// </summary>
        /// <param name="context">Context.</param>
        /// <param name="attrs">Attrs.</param>
        public DrawView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RevTrainer.Droid.DrawView"/> class.
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
            //_revkite.SetImageResource(Resource.Drawable.revolution_xx_red_white_black);

            _paint = new Paint();
            _paint.Color = Color.Blue;
            _paint.StrokeWidth = 10;
            _paint.SetStyle(Paint.Style.Stroke);

            _path = new Path();
            _path.MoveTo(50, 50);
            _path.LineTo(50, 500);
            _path.LineTo(200, 500);
            _path.LineTo(200, 300);
            _path.LineTo(350, 300);
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            canvas.DrawPath(_path, _paint);
        }



















        /*private static final float MINP = 0.25f;
        private static final float MAXP = 0.75f;

        private Bitmap mBitmap;
        private Canvas mCanvas;
        private Path mPath;
        private Paint mBitmapPaint;

        public MyView(Context c)
        {
            super(c);

            mPath = new Path();
            mBitmapPaint = new Paint(Paint.DITHER_FLAG);
        }

        @Override
       protected void onSizeChanged(int w, int h, int oldw, int oldh)
        {
            super.onSizeChanged(w, h, oldw, oldh);
            mBitmap = Bitmap.createBitmap(w, h, Bitmap.Config.ARGB_8888);
            mCanvas = new Canvas(mBitmap);
        }

        @Override
        protected void onDraw(Canvas canvas)
        {
            canvas.drawColor(0xFFAAAAAA);
            // canvas.drawLine(mX, mY, Mx1, My1, mPaint);
            // canvas.drawLine(mX, mY, x, y, mPaint);
            canvas.drawBitmap(mBitmap, 0, 0, mBitmapPaint);
            canvas.drawPath(mPath, mPaint);

        }

        private float mX, mY;
        private static final float TOUCH_TOLERANCE = 4;

        private void touch_start(float x, float y)
        {
            mPath.reset();
            mPath.moveTo(x, y);
            mX = x;
            mY = y;
        }
        private void touch_move(float x, float y)
        {
            float dx = Math.abs(x - mX);
            float dy = Math.abs(y - mY);
            if (dx >= TOUCH_TOLERANCE || dy >= TOUCH_TOLERANCE)
            {
                // mPath.quadTo(mX, mY, (x + mX)/2, (y + mY)/2);
                mX = x;
                mY = y;
            }
        }
        private void touch_up()
        {
            mPath.lineTo(mX, mY);
            // commit the path to our offscreen
            mCanvas.drawPath(mPath, mPaint);
            // kill this so we don't double draw
            mPath.reset();
        }

        @Override
        public boolean onTouchEvent(MotionEvent event) {
            float x = event.getX();
            float y = event.getY();

            switch (event.getAction()) {
                case MotionEvent.ACTION_DOWN:
                    touch_start(x, y);
        invalidate();
                    break;
                case MotionEvent.ACTION_MOVE:
                    touch_move(x, y);
        invalidate();
                    break;
                case MotionEvent.ACTION_UP:
                    touch_up();
        //   Mx1=(int) event.getX();
        //  My1= (int) event.getY();
        invalidate();
                    break;
            }
            return true;
        }*/
    }
}
