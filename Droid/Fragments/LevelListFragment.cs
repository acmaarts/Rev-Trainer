using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using RevTrainer.Droid.Activities;
using RevTrainer.Droid.Adapters;
using RevTrainer.Models;
using RevTrainer.ViewModels;

namespace RevTrainer.Droid.Fragments
{
    /// <summary>
    /// Level list fragment.
    /// </summary>
    public class LevelListFragment : ListFragment
    {
        private static ILevelsViewModel _levelsViewModel;

        /// <summary>
        /// Gets the levels view model.
        /// </summary>
        /// <value>The levels view model.</value>
        public static ILevelsViewModel LevelsViewModel
        {
            get { return _levelsViewModel ?? (_levelsViewModel = new LevelsViewModel()); }
        }

        /// <summary>
        /// Ons the activity created.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            ListAdapter = new ArrayAdapter<Level>(this.Activity, Resource.Id.title, LevelsViewModel.Items);
        }

        private void NavigateToRoutine(int index)
        {
            var intent = new Intent(this.Activity, typeof(RoutineActivity));
            intent.PutExtra("Level", JsonConvert.SerializeObject(_levelsViewModel.Items[index]));
            StartActivity(intent);
        }

        /// <summary>
        /// Ons the list item click.
        /// </summary>
        /// <param name="l">L.</param>
        /// <param name="v">V.</param>
        /// <param name="position">Position.</param>
        /// <param name="id">Identifier.</param>
        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);
            NavigateToRoutine(position);
        }
    }
}
