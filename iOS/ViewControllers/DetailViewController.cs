using System;
using CoreGraphics;
using UIKit;

namespace RevTrainer.iOS.ViewControllers
{
    /// <summary>
    /// Detail view controller.
    /// </summary>
    public class DetailViewController : UIViewController
    {
        /// <summary>
        /// Gets or sets the popover.
        /// </summary>
        /// <value>The popover.</value>
        public UIPopoverController Popover { get; set; }

        private UILabel label;
        private UIToolbar toolbar;
        private const string _CONTENT = "This is the detail view for row {0}";

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RevTrainer.iOS.ViewControllers.DetailViewController"/> class.
        /// </summary>
        public DetailViewController() : base()
        {
            View.BackgroundColor = UIColor.White;

            label = new UILabel(new CGRect(100, 100, 450, 60));
            label.Font = UIFont.SystemFontOfSize(24f);
            Update(1); // defaults to "1"
            View.AddSubview(label);
            // add a toolbar to host the master view popover (when it is required, in portrait)
            toolbar = new UIToolbar(new CGRect(0, 0, View.Frame.Width, 30));
            toolbar.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
            View.AddSubview(toolbar);
        }

        /// <summary>
        /// Update the view's contents depending on what was selected in the master list
        /// </summary>
        public void Update(int row)
        {
            label.Text = String.Format(_CONTENT, row.ToString());
            // dismiss the popover if currently visible
            if (Popover != null)
                Popover.Dismiss(true);
        }

        /// <summary>
        /// Shows the button that allows access to the master view popover
        /// </summary>
        public void AddContentsButton(UIBarButtonItem button)
        {
            button.Title = "Contents";
            toolbar.SetItems(new UIBarButtonItem[] { button }, false);
        }

        /// <summary>
        /// Hides the button that allows access to the master view popover
        /// </summary>
        public void RemoveContentsButton()
        {
            toolbar.SetItems(new UIBarButtonItem[0], false);
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
    }
}