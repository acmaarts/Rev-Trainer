using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using RevTrainer.Models;

namespace RevTrainer.ViewModels
{
    /// <summary>
    /// Levels view model.
    /// </summary>
    public interface ILevelsViewModel
    {
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        IList<Level> Items { get; set; }
    }
}
