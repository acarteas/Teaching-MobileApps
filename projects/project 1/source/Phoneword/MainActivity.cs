using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;

namespace Phoneword
{
    [Activity(Label = "Phone Word", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // New code will go here


            // Get our UI controls from the loaded layout
            EditText phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            TextView translatedPhoneWord = FindViewById<TextView>(Resource.Id.TranslatedPhoneWord);
            Button translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
            //
            Button alphaButton = FindViewById<Button>(Resource.Id.AlphaButton);
            Button exclamButton = FindViewById<Button>(Resource.Id.ExclamButton);
<<<<<<< HEAD
            Button keepButton = FindViewById<Button>(Resource.Id.keepButton);
=======
>>>>>>> a1c27dd8211fcd71a68ce5225832624d474f9104
            // Add code to translate number
            translateButton.Click += (sender, e) =>
            {
                // Translate user’s alphanumeric phone number to numeric
                string translatedNumber = Core.ExpressionScrambler.ToNumber(phoneNumberText.Text);
                if (string.IsNullOrWhiteSpace(translatedNumber))
                {
                    translatedPhoneWord.Text = string.Empty;
                }
                else
                {
                    translatedPhoneWord.Text = translatedNumber;
                }
            };

            alphaButton.Click += (sender, e) =>
            {
                // Translate user’s alphanumeric phone number to numeric
                string scrambledExpression = Core.ExpressionScrambler.ToAlpha(phoneNumberText.Text);
                if (string.IsNullOrWhiteSpace(scrambledExpression))
                {
                    translatedPhoneWord.Text = string.Empty;
                }
                else
                {
                    translatedPhoneWord.Text = scrambledExpression;
                }
            };

            exclamButton.Click += (sender, e) =>
            {
                string scrambledExpression = Core.ExpressionScrambler.GetExclam(phoneNumberText.Text);
                if (string.IsNullOrWhiteSpace(scrambledExpression))
                {
                    translatedPhoneWord.Text = string.Empty;
                }
                else
                {
                    translatedPhoneWord.Text = scrambledExpression;
                }
            };
<<<<<<< HEAD
=======

>>>>>>> a1c27dd8211fcd71a68ce5225832624d474f9104

            keepButton.Click += (sender, e) =>
            {
                phoneNumberText.Text = translatedPhoneWord.Text;
            };
            
        }
    }
}
