using CoreGraphics;
using UIKit;

namespace RevTrainer.iOS.Views
{
    /// <summary>
    /// Grid view.
    /// </summary>
    public class GridView : UIView
    {

        public override void Draw(CGRect rect)
        {
            var context = UIGraphics.GetCurrentContext();
            context.SetStrokeColor(UIColor.LightGray.CGColor);
            context.SetLineWidth(1.0f);

            var distanceBetweenHorizalLines = Superview.Frame.Height / 9;
            var distanceBetweenVerticalLines = Superview.Frame.Width / 9;

            // Draw Horizontal lines
            for (int idx = 2; idx < 10; idx++)
            {
                context.MoveTo(0, distanceBetweenHorizalLines * idx);
                context.AddLineToPoint(Superview.Frame.Width, distanceBetweenHorizalLines * idx);
                context.StrokePath();
            }

            // Draw Vertical lines
            for (int idx = 1; idx < 10; idx++)
            {
                context.MoveTo(distanceBetweenVerticalLines * idx, 0);
                context.AddLineToPoint(distanceBetweenVerticalLines * idx, Superview.Frame.Height);
                context.StrokePath();
            }
        }
    }
}
