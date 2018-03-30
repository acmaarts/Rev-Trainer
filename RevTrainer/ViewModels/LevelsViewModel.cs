using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using RevTrainer.Models;

namespace RevTrainer.ViewModels
{
    /// <summary>
    /// Levels view model.
    /// </summary>
    public class LevelsViewModel : ViewModelBase, ILevelsViewModel
    {
        private IList<Level> _items;

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        public IList<Level> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public LevelsViewModel()
        {
            _items = new List<Level>();
            _items.Add(new Level("thebasics"));
            _items.Add(new Level("divestop"));
            _items.Add(new Level("windfriend"));
            _items.Add(new Level("thehover"));
        }
    }
}