using System;
using System.Collections.Generic;

namespace RevTrainer.Models
{
    /// <summary>
    /// Team.
    /// </summary>
    public class Team
    {
        private List<Pilot> _pilots;

        /// <summary>
        /// Gets the pilots.
        /// </summary>
        /// <value>The pilots.</value>
        public IList<Pilot> Pilots
        {
            get
            {
                if (_pilots == null)
                {
                    _pilots = new List<Pilot>();
                }
                return _pilots;
            }
        }
    }
}
