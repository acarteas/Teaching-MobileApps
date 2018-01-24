using Android.App;
using Android.Widget;
using Android.OS;

namespace Calculator
{
    [Activity(Label = "Calculator", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            LinearLayout layout = FindViewById<LinearLayout>(Resource.Id.MainPageLayout);
            var rows = layout.FindViewWithTag(Resource.String.calculator_row);
            //FindViewById<Button>(Resource.Id.myButton);
        }
    }
}

