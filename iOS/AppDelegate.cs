﻿using Foundation;
using RevTrainer.iOS.ViewControllers;
using UIKit;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace RevTrainer.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations
        private UIWindow _window;
        private MainViewController _viewController;

        /// <summary>
        /// Finisheds the launching.
        /// </summary>
        /// <returns><c>true</c>, if launching was finisheded, <c>false</c> otherwise.</returns>
        /// <param name="application">Application.</param>
        /// <param name="launchOptions">Launch options.</param>
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            AppCenter.Start("91bd19c3-ec72-4228-9acc-fac2dc08b612", typeof(Analytics), typeof(Crashes));

            App.Initialize();

            // create a new window instance based on the screen size
            _window = new UIWindow(UIScreen.MainScreen.Bounds);

            // If you have defined a view, add it here:
            _viewController = new MainViewController();
            _window.RootViewController = _viewController;

            // make the window visible
            _window.MakeKeyAndVisible();

            return true;
        }

        /// <summary>
        /// Ons the resign activation.
        /// </summary>
        /// <param name="application">Application.</param>
        public override void OnResignActivation(UIApplication application)
        {
            // Invoked when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
            // or when the user quits the application and it begins the transition to the background state.
            // Games should use this method to pause the game.
        }

        /// <summary>
        /// Dids the enter background.
        /// </summary>
        /// <param name="application">Application.</param>
        public override void DidEnterBackground(UIApplication application)
        {
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background exection this method is called instead of WillTerminate when the user quits.
        }

        /// <summary>
        /// Wills the enter foreground.
        /// </summary>
        /// <param name="application">Application.</param>
        public override void WillEnterForeground(UIApplication application)
        {
            // Called as part of the transiton from background to active state.
            // Here you can undo many of the changes made on entering the background.
        }

        /// <summary>
        /// Ons the activated.
        /// </summary>
        /// <param name="application">Application.</param>
        public override void OnActivated(UIApplication application)
        {
            // Restart any tasks that were paused (or not yet started) while the application was inactive. 
            // If the application was previously in the background, optionally refresh the user interface.
        }

        /// <summary>
        /// Wills the terminate.
        /// </summary>
        /// <param name="application">Application.</param>
        public override void WillTerminate(UIApplication application)
        {
            // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
        }
    }
}
