using System;
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
	[Activity(Label = "VSProject1", MainLauncher = true, Icon = "@drawable/icon")]

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
            var editText = FindViewById<EditText>(Resource.Id.editText1);
            string editTextString = editText.ToString();
            editTextString = editTextString.ToLower();

            int offset = 1;
            offset = offset * -1;

            string encodedString = chiper(editTextString, offset);

            myVib.Vibrate(30);
            Toast.MakeText(this.ApplicationContext, encodedString, ToastLength.Short).Show();

            //throw new NotImplementedException();
        }

        private void translateMe(object sender, System.EventArgs e)
		{
            //capture text from the box.
            EditText editText = (EditText)FindViewById<EditText>(Resource.Id.editText1);

			var editTextString = editText.Text;
            editTextString = editTextString.ToLower();

            int offset = 1;

            string encodedString = chiper(editTextString, offset);

            myVib.Vibrate(30);
			Toast.MakeText(this.ApplicationContext, encodedString, ToastLength.Short).Show();
			
			//TODO: return and replace encordedString into a text box.

			
			//throw new System.NotImplementedException();
		}

        private string chiper(string input, int shift)
        {
            //why is my buffer 93 freaking characters LONG!!!?
            char[] buffer = input.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                // Letter.
                char letter = buffer[i];
                // Add shift to all.
                letter = (char)(letter + shift);
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
                // storage
                buffer[i] = letter;
            }


            //output 
            return new string(buffer);

        } //end cipher



		

	}//end activity
}//end project

