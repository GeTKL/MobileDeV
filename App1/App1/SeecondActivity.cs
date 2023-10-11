using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App1
{
    [Activity(Label = "SeecondActivity")]
    public class SeecondActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.second_page);
            Button sbmButton = FindViewById<Button>(Resource.Id.button1);
            sbmButton.Click += delegate { StartActivity(typeof(MainActivity)); };
        }
    }
}