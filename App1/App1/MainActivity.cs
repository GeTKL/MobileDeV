using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using System.Collections;
using System.Data.SqlClient;
using System;
using System.Data;

namespace App1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ArrayList notes = new ArrayList();
        EditText lstNotes;
        EditText txtNote;
        SqlCommand cmd;
        DataTable dt = new DataTable();
        SqlDataAdapter sdr;
        SqlConnection conn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            lstNotes = FindViewById<EditText>(Resource.Id.editText1);
            txtNote = FindViewById<EditText>(Resource.Id.editText2);
            Button btnSubmit = FindViewById<Button>(Resource.Id.button1);
            btnSubmit.Click += BtnSubmit_Click;
        }

        private void Conn()
        {
            SqlConnection conn = new SqlConnection("Server=tcp:DESKTOP-GT0DBLK; DataBase = WS; Trusted_Connection = true;");
            conn.Open();    
        }

        private void DB()
        {
            Conn();
            SqlCommand cmd = new SqlCommand("Select * FROM ENTER WHERE Столица = @log and Округ = @pas", conn);
            cmd.Parameters.AddWithValue("@log", lstNotes.Text);
            cmd.Parameters.AddWithValue("@pas", txtNote.Text);
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            sdr.Fill(dt);
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            //DB();
            //if (dt.Rows.Count > 0)
            if (lstNotes.Text == "Admin" && txtNote.Text == "Admin")
            {
                Toast.MakeText(this, string.Format("Успешный вход"), ToastLength.Short).Show();
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