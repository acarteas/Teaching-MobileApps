using Android.App;
using Android.Widget;
using Android.OS;

namespace App6
{
    [Activity(Label = "App6", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Button a = FindViewById<Button>(Resource.Id.one);
            Button b = FindViewById<Button>(Resource.Id.two);
            Button c = FindViewById<Button>(Resource.Id.three);
            Button d = FindViewById<Button>(Resource.Id.four);
            Button e = FindViewById<Button>(Resource.Id.five);
            Button f = FindViewById<Button>(Resource.Id.six);
            Button g = FindViewById<Button>(Resource.Id.seven);
            Button h = FindViewById<Button>(Resource.Id.eight);
            Button i = FindViewById<Button>(Resource.Id.nine);
            Button j = FindViewById<Button>(Resource.Id.zero);
            Button _dot = FindViewById<Button>(Resource.Id.dot);
            Button _space = FindViewById<Button>(Resource.Id.space);
            Button _minus = FindViewById<Button>(Resource.Id.minus);
            Button _addition = FindViewById<Button>(Resource.Id.addition);
            Button _div = FindViewById<Button>(Resource.Id.div);
            Button _mult = FindViewById<Button>(Resource.Id.mult);
            Button _clear = FindViewById<Button>(Resource.Id.clear);

            string _display = "0.00";
            string _num1, _num2 = "";
            //string _num2 = "";


        }
    }
}

