using System;
using System.Linq;
using RevTrainer.Models;

namespace RevTrainer.ViewModels
{
    /// <summary>
    /// Main view model.
    /// </summary>
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        private Team _team;
        private bool _isTurningClockwise;

        /// <summary>
        /// Gets or sets the team.
        /// </summary>
        /// <value>The team.</value>
        public Team Team
        {
            get { return _team; }
            private set
            {
                if (value != _team)
                {
                    _team = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:RevTrainer.ViewModels.MainViewModel"/> is turning clockwise.
        /// </summary>
        /// <value><c>true</c> if is turning clockwise; otherwise, <c>false</c>.</value>
        public bool IsTurningClockwise
        {
            get { return _isTurningClockwise; }
            set
            {
                if (value != _isTurningClockwise)
                {
                    _isTurningClockwise = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RevTrainer.ViewModels.MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            _team = new Team();
        }

        /// <summary>
        /// Adds the pilot.
        /// </summary>
        /// <param name="pilot">Pilot.</param>
        public void AddPilot(Pilot pilot)
        {
            _team.Pilots.Add(pilot);
            OnPropertyChanged(() => Team);
        }

        /// <summary>
        /// Moves the kite.
        /// </summary>
        /// <param name="number">Number.</param>
        /// <param name="position">Position.</param>
        public void MoveKite(int number, Position position)
        {
            var kite = _team.Pilots.Single(p => p.PlaceInLine == number).Kite;
            kite.Position = position;
        }

        /// <summary>
        /// Rotates the kite.
        /// </summary>
        /// <param name="number">Number.</param>
        public void RotateKite(int number)
        {
            var kite = _team.Pilots.Single(p => p.PlaceInLine == number).Kite;

            float newRotationValue;
            if (_isTurningClockwise)
            {
                newRotationValue = kite.Rotation + 45.0f;
            }
            else
            {
                newRotationValue = kite.Rotation - 45.0f;
            }

            if (newRotationValue < 0 || newRotationValue > 315)
            {
                newRotationValue = 0.0f;
            }

            kite.Rotation = newRotationValue;
        }
    }
}
