using System;
using System.Linq;
using MonoTouch.Dialog;
using UIKit;
using CoreFoundation;

namespace RevTrainer.iOS.ViewControllers
{
    /// <summary>
    /// Master view controller.
    /// </summary>
    public class MasterViewController : DialogViewController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:RevTrainer.iOS.ViewControllers.MasterViewController"/> class.
        /// </summary>
        public MasterViewController() : base(UITableViewStyle.Plain, null)
        {
            Root = new RootElement("Items")
            {
                new Section
                {
                    from num in Enumerable.Range (1, 10)
                    select (Element) new MonoTouch.Dialog.StringElement("Item " + num, delegate {
                        if (RowClicked != null)
                        {
                            RowClicked (this, new RowClickedEventArgs(num));
                        }
                    })
                }
            };
        }

        /// <summary>
        /// Shoulds the autorotate to interface orientation.
        /// </summary>
        /// <returns><c>true</c>, if autorotate to interface orientation was shoulded, <c>false</c> otherwise.</returns>
        /// <param name="toInterfaceOrientation">To interface orientation.</param>
        public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
        {
            return true;
        }

        /// <summary>
        /// Occurs when row clicked.
        /// </summary>
        public event EventHandler<RowClickedEventArgs> RowClicked;

        /// <summary>
        /// Row clicked event arguments.
        /// </summary>
        public class RowClickedEventArgs : EventArgs
        {
            /// <summary>
            /// Gets or sets the item.
            /// </summary>
            /// <value>The item.</value>
            public int Item { get; set; }

            /// <summary>
            /// Initializes a new instance of the
            /// <see cref="T:RevTrainer.iOS.ViewControllers.MasterViewController.RowClickedEventArgs"/> class.
            /// </summary>
            /// <param name="item">Item.</param>
            public RowClickedEventArgs(int item) : base()
            {
                Item = item;
            }
        }
    }
}