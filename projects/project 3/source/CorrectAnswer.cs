using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Provider;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Google.Apis.Vision.v1;
using Google.Apis.Vision.v1.Data;
using Google.Apis.Services;

namespace ImageGuess
{
    [Activity(Label = "CorrectAnswer")]
    public class CorrectAnswer : Activity
    { 
        Button btnCorrectAnswer;
        TextView txtView2;
        //String inputAnswer;
    
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // setting view from the "main" layout resource
            SetContentView(Resource.Layout.CorrectAns);

           Button btnCorrectAnswer = FindViewById<Button>(Resource.Id.goBackButton);
           btnCorrectAnswer.Click += returnToMainActivity;

           txtView2 = (TextView)FindViewById(Resource.Id.correctValue);
           string text = Intent.GetStringExtra("MyData") ?? "Data not available"; 
        }

        public void returnToMainActivity(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
} 