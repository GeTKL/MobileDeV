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
using Android.Content;

namespace App1
{
    [Activity(Label = "SeecondActivity")]
    public class SeecondActivity : AppCompatActivity
    {
        ArrayList notes = new ArrayList();
        ListView ListNotes;
        EditText txtNote;
        int i;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.second_page);

            int defaultValue = -1;
            i = Intent.GetIntExtra("res", defaultValue);
            
            Button sbmButton = FindViewById<Button>(Resource.Id.button1);
            sbmButton.Click += SbmButton_Click;
            ListNotes = FindViewById<ListView>(Resource.Id.listView1);
            txtNote = FindViewById<EditText>(Resource.Id.editText1);
            Button Write = FindViewById<Button>(Resource.Id.button2);
            Write.Click += Write_Click;

            LoadNotes();
        }

        private void LoadNotes()
        {
            SqlConnection conn = new SqlConnection("workstation id=WorldSkills.mssql.somee.com;packet size=4096;user id=GeT_SQLLogin_1;pwd=fgzhl41chb;data source=WorldSkills.mssql.somee.com;persist security info=False;initial catalog=WorldSkills");
            conn.Open();
            SqlCommand com = new SqlCommand("Select Note from Notes, Auth where Notes.id_us = Auth.id and Notes.id_us = @id", conn);
            com.Parameters.AddWithValue("@id", i);
            SqlDataReader rdr = com.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    notes.Add(rdr[0]);
                }
                rdr.Close();
                ListNotes.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleExpandableListItem1, notes);
            }
            conn.Close();
        }
        private void Write_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("workstation id=WorldSkills.mssql.somee.com;packet size=4096;user id=GeT_SQLLogin_1;pwd=fgzhl41chb;data source=WorldSkills.mssql.somee.com;persist security info=False;initial catalog=WorldSkills");
            conn.Open();

            SqlCommand com = new SqlCommand("Insert into Notes Values (@note, @id_us)", conn);
            com.Parameters.AddWithValue("@note", txtNote.Text);
            com.Parameters.AddWithValue("@id_us", i);
            com.ExecuteNonQuery();

            conn.Close();

            notes.Clear();
            txtNote.Text = string.Empty;
            LoadNotes();
        }

        private void SbmButton_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}