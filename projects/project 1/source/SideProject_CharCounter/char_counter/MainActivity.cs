using Android.App;
using Android.Widget;
using Android.OS;

namespace char_counter
{
    [Activity(Label = "Character Counter", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);



            string len, myresult;
            Button clear = FindViewById<Button>(Resource.Id.ClearButton);

            EditText localtext = FindViewById<EditText>(Resource.Id.toBeCounted);



            localtext.TextChanged += delegate
            {
                len = FindViewById<EditText>(Resource.Id.toBeCounted).Text.ToString();
                myresult = FindViewById<TextView>(Resource.Id.printnum).ToString();
                len = len.Length.ToString();

                myresult = len + " characters long";

                FindViewById<TextView>(Resource.Id.printnum).Text = myresult;
            };

            clear.Click += delegate
            {
                FindViewById<EditText>(Resource.Id.toBeCounted).Text = "";
                FindViewById<TextView>(Resource.Id.printnum).Text = "0 characters long";
            };
        }
    }
}

