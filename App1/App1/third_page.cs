using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using System.Collections;
using System.Data.SqlClient;
using System;
using System.Data;
using Android.Content.Res;

namespace App1
{
    [Activity(Label = "third_page")]
    public class third_page : AppCompatActivity
    {
        Button sbmButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.third_page);
            Button sbmButton = FindViewById<Button>(Resource.Id.button1);
            sbmButton.Click += SbmButton_Click;
        }

        private void SbmButton_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}