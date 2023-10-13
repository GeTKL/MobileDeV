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
    [Activity(Label = "SeecondActivity")]
    public class SeecondActivity : AppCompatActivity
    {
        ArrayList notes = new ArrayList();
        ListView ListNotes;
        EditText txtNote;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.second_page);
            Button sbmButton = FindViewById<Button>(Resource.Id.button1);
            sbmButton.Click += SbmButton_Click;
            ListNotes = FindViewById<ListView>(Resource.Id.listView1);
            txtNote = FindViewById<EditText>(Resource.Id.editText1);
            Button Write = FindViewById<Button>(Resource.Id.button2);
            Write.Click += Write_Click;
        }

        private void Write_Click(object sender, EventArgs e)
        {
            
        }

        private void SbmButton_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}