using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Collections;

namespace CalculatorApp
{
    [Activity(Label = "CalculatorApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        Stack calc_stack = new Stack();
        int count = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Button button = FindViewById<Button>(Resource.Id.myButton);

            // TextView resultsView = FindViewById<TextView>(Resource.Id.textView1);

            //declares button to use
            //TODO: declare the rest of the buttons
            Button bttn1 = FindViewById<Button>(Resource.Id.button_one);

            //declare the view to edit
            EditText results = FindViewById<TextView>(Resource.Id.results);

            bttn1.click += count++;




        }

      
    }
}

