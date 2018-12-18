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
        /// Updates the team.
        /// </summary>
        /// <param name="team">Team.</param>
        public void UpdateTeam(Team team)
        {
            _team = team;
        }
    }
}
