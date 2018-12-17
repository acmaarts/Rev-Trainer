using System;
using RevTrainer.Models;

namespace RevTrainer.ViewModels
{
    /// <summary>
    /// Main view model.
    /// </summary>
    public interface IMainViewModel
    {
        /// <summary>
        /// Gets or sets the team.
        /// </summary>
        /// <value>The team.</value>
        Team Team { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:RevTrainer.ViewModels.IMainViewModel"/> is turning clockwise.
        /// </summary>
        /// <value><c>true</c> if is turning clockwise; otherwise, <c>false</c>.</value>
        bool IsTurningClockwise { get; set; }

        /// <summary>
        /// Adds the pilot.
        /// </summary>
        /// <param name="pilot">Pilot.</param>
        void AddPilot(Pilot pilot);

        /// <summary>
        /// Moves the kite.
        /// </summary>
        /// <param name="number">Number.</param>
        /// <param name="position">Position.</param>
        void MoveKite(int number, Position position);

        /// <summary>
        /// Rotates the kite.
        /// </summary>
        /// <param name="number">Number.</param>
        void RotateKite(int number);
    }
}
