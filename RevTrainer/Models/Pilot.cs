using System;

namespace RevTrainer.Models
{
    /// <summary>
    /// Pilot.
    /// </summary>
    public class Pilot
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the place in line.
        /// </summary>
        /// <value>The place in line.</value>
        public int PlaceInLine { get; set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        public Position Position { get; set; }

        /// <summary>
        /// Gets or sets the kite.
        /// </summary>
        /// <value>The kite.</value>
        public Kite Kite { get; set; }
    }
}
