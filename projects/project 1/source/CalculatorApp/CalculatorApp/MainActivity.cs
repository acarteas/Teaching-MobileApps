using Android.App;
using Android.Widget;
using Android.OS;

namespace CalculatorApp
{
    [Activity(Label = "CalculatorApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);

            var label = FindViewById<TextView>(Resource.Id.textView1);
            button.Click += delegate 
            {
                count++;
                label.Text = $"You clicked {count} times";

            };
        }
      
    }
}

