using Android.App;
using Android.Widget;
using Android.OS;

namespace App1
{
    [Activity(Label = "App1-Postfix Calculator", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button1  = FindViewById<Button>(Resource.Id.button1);
            Button button2 = FindViewById<Button>(Resource.Id.button2);
            Button button3 = FindViewById<Button>(Resource.Id.button3);
            Button button4 = FindViewById<Button>(Resource.Id.button4);
            Button button5 = FindViewById<Button>(Resource.Id.button5);
            Button button6 = FindViewById<Button>(Resource.Id.button6);
            Button button7 = FindViewById<Button>(Resource.Id.button7);
            Button button8 = FindViewById<Button>(Resource.Id.button8);
            Button button9 = FindViewById<Button>(Resource.Id.button9);
            Button button10 = FindViewById<Button>(Resource.Id.button10);
            Button button11 = FindViewById<Button>(Resource.Id.button11);
            Button button12 = FindViewById<Button>(Resource.Id.button12);
            Button button13 = FindViewById<Button>(Resource.Id.button13);
            Button button14 = FindViewById<Button>(Resource.Id.button14);
            Button button15 = FindViewById<Button>(Resource.Id.button15);
            Button button16 = FindViewById<Button>(Resource.Id.button16);


            button1.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
        }
    }
}

