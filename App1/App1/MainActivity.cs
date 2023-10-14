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
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText lstNotes;
        EditText txtNote;
        DataTable dt = new DataTable();
        Button btnSubmit;
        int result;
        Intent i;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            lstNotes = FindViewById<EditText>(Resource.Id.editText1);
            txtNote = FindViewById<EditText>(Resource.Id.editText2);
            btnSubmit = FindViewById<Button>(Resource.Id.button1);
            btnSubmit.Click += BtnSubmit_Click;
        }

        private void DB()
        {
            SqlConnection conn = new SqlConnection("workstation id=WorldSkills.mssql.somee.com;packet size=4096;user id=GeT_SQLLogin_1;pwd=fgzhl41chb;data source=WorldSkills.mssql.somee.com;persist security info=False;initial catalog=WorldSkills");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * FROM Auth WHERE Us_log = @log and Pass = @pas", conn);
            cmd.Parameters.AddWithValue("@log", lstNotes.Text);
            cmd.Parameters.AddWithValue("@pas", txtNote.Text);
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            sdr.Fill(dt);
            conn.Close();
        }

        private void Roles()
        {
            SqlConnection conn = new SqlConnection("workstation id=WorldSkills.mssql.somee.com;packet size=4096;user id=GeT_SQLLogin_1;pwd=fgzhl41chb;data source=WorldSkills.mssql.somee.com;persist security info=False;initial catalog=WorldSkills");
            conn.Open();

            SqlCommand cmd = new SqlCommand("Select Id From Auth where Us_log = @log", conn);
            cmd.Parameters.AddWithValue("@log", lstNotes.Text);
            
            result = (int)cmd.ExecuteScalar();
            conn.Close();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            DB();
            if (dt.Rows.Count > 0)
            {
                Roles();

                i = new Intent(this, typeof(SeecondActivity));
                i.PutExtra("res", result);

                Toast.MakeText(this, string.Format("Успешный вход"), ToastLength.Short).Show();
                StartActivity(i);
            }
            else
            {
                Toast.MakeText(this, string.Format("Ошибка входа"), ToastLength.Short).Show();
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}