using CoreGraphics;
using RevTrainer.Models;
using UIKit;

namespace RevTrainer.iOS.Views
{
    /// <summary>
    /// Draw view.
    /// </summary>
    public class DrawView : UIView
    {
        private Team _team = null;

        /// <summary>
        /// Draw the specified rect.
        /// </summary>
        /// <param name="rect">Rect.</param>
        public override void Draw(CGRect rect)
        {
            if (_team == null || _team.Pilots == null)
            {
                return;
            }

            var context = UIGraphics.GetCurrentContext();
            context.SetStrokeColor(UIColor.Black.CGColor);
            context.SetLineWidth(1.0f);

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

                context.MoveTo(pilot.Position.X + 2, pilot.Position.Y);

                if (pilot.Kite.Rotation == 270)
                {
                    context.AddLineToPoint(pilot.Kite.Position.X, kiteY);
                }
                else if (pilot.Kite.Rotation == 90)
                {
                    context.AddLineToPoint(pilot.Kite.Position.X + 25, kiteY);
                }
                else
                {
                    context.AddLineToPoint(pilot.Kite.Position.X + 55, kiteY);
                }

                context.StrokePath();
            }
        }

        /// <summary>
        /// Updates the team.
        /// </summary>
        /// <param name="team">Team.</param>
        public void UpdateTeam(Team team)
        {
            _team = team;
        }
    }
}
