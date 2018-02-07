﻿using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSProject1
{
	[Activity(Label = "JackKinne.P1.CeasarCipher", MainLauncher = true, Icon = "@drawable/icon")]

	public class MainActivity : Activity
	{
        //not implemented for a history of previous codes.
        //static readonly List<string> historyList = new List<string>();

        private Vibrator myVib;

        protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			//start system service for the vibrator function.
			myVib = (Vibrator)GetSystemService(VibratorService);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

            //button for translation into a cipher
			Button translateButton = FindViewById<Button>(Resource.Id.translateButton);
            translateButton.Click += translateMe;

            //button to return a cipher to english
            Button DecryptButton = FindViewById<Button>(Resource.Id.decryptButton);
            DecryptButton.Click += backtoEnglish;

		}


    private void backtoEnglish(object sender, EventArgs e)
        {
            //capture text from the box.
            EditText editText = (EditText)FindViewById<EditText>(Resource.Id.editText1);
            var editTextString = editText.Text;
            editTextString = editTextString.ToLower();

            //offset stuff
            int offset = harvestOffset();
            offset = offset * -1; //flipping to reverse chiper.

            //chiper call.
            string encodedString = chiper(editTextString, offset);
            // vibrate the phone
            myVib.Vibrate(30);
            Toast.MakeText(this.ApplicationContext, "Translation Complete, User.", ToastLength.Short).Show();

            //return and replace EncodedString into text box.
            editText.Text = encodedString;
        }

        private void translateMe(object sender, System.EventArgs e)
		{
            //capture text from the box.
            EditText editText = (EditText)FindViewById<EditText>(Resource.Id.editText1);

			var editTextString = editText.Text;
            editTextString = editTextString.ToLower();

            //offset stuff
            int offset = harvestOffset();

            string encodedString = chiper(editTextString, offset);

            myVib.Vibrate(30);
			Toast.MakeText(this.ApplicationContext, "Cipher Complete, User.", ToastLength.Short).Show();

            //TODO: return and replace encordedString into a text box.
            editText.Text = encodedString;


        }

        private string chiper(string input, int offset)
        {
            //why is my buffer 93 freaking characters LONG!!!?
            char[] buffer = input.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                // Letter.
                char letter = buffer[i];
                // Add shift to all.
                letter = (char)(letter + offset);
                // Subtract 26 on overflow.
                // Add 26 on underflow.
                if (letter == '.' || letter == ' ')
                {
                    continue;
                }
                else if (letter > 'z')
                {
                    letter = (char)(letter - 26);
                }
                else if (letter < 'a')
                {
                    letter = (char)(letter + 26);
                }
                // store for return
                buffer[i] = letter;
            }


            //output 
            return new string(buffer);

        } //end cipher

        private int harvestOffset()
        {
            //capture text from the box.
            EditText editText = (EditText)FindViewById<EditText>(Resource.Id.editText2);

            var editTextString2 = editText.Text;
            int value;
            bool isSuccess = int.TryParse(editTextString2, out value);
            if(isSuccess)
            {
                return value;
            }
            return 0;
        } //end harvestOffset

		

	}//end activity
}//end project

