using System;
using UIKit;
using CoreFoundation;

namespace RevTrainer.iOS.ViewControllers
{
    /// <summary>
    /// Split view controller.
    /// </summary>
    public class SplitViewController : UISplitViewController
    {
        private MasterViewController masterView;
        private DetailViewController detailView;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RevTrainer.iOS.ViewControllers.SplitViewController"/> class.
        /// </summary>
        public SplitViewController() : base()
        {
            // create our master and detail views
            masterView = new MasterViewController();
            detailView = new DetailViewController();
            // create an array of controllers from them and then
            // assign it to the controllers property
            ViewControllers = new UIViewController[] { masterView, detailView }; // order is important

            // in this example, i expose an event on the master view called RowClicked, and i listen 
            // for it in here, and then call a method on the detail view to update. this class thereby 
            // becomes the defacto controller for the screen (both views).
            masterView.RowClicked += (object sender, MasterViewController.RowClickedEventArgs e) => {
                detailView.Update(e.Item);
            };

            // when the master view controller is hidden (portrait mode), we add a button to 
            // the detail view that will show the master view in a popover
            WillHideViewController += (object sender, UISplitViewHideEventArgs e) => {
                detailView.Popover = e.Pc;
                detailView.AddContentsButton(e.BarButtonItem);
            };

            // when the master view controller is shown (landscape mode), remove the button
            WillShowViewController += (object sender, UISplitViewShowEventArgs e) => {
                detailView.Popover = null;
                detailView.RemoveContentsButton();
            };

            // hide the master view controller 
            ShouldHideViewController = (svc, viewController, inOrientation) => {
                return inOrientation == UIInterfaceOrientation.Portrait ||
                       inOrientation == UIInterfaceOrientation.PortraitUpsideDown;
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
    }
}
