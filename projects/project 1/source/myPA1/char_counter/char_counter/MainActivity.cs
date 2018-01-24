using Android.App;
using Android.Widget;
using Android.OS;

namespace char_counter
{
    [Activity(Label = "Character Counter", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            
        }
    }
}

