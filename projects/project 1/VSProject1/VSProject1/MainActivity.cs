using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections;

namespace VSProject1
{
	[Activity(Label = "VSProject1", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{

		private Vibrator myVib;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			//start system service for the vibrator function.
			myVib = (Vibrator)GetSystemService(VibratorService);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			Button button = FindViewById<Button>(Resource.Id.button1);

			button.Click += ButtonClick1;

		}


		private void MenuSetup()
		{
			//delete the old stuff, setup a new menu..

		}


		private void ButtonClick1(object sender, System.EventArgs e)
		{
			myVib.Vibrate(30);
			Toast.MakeText(this.ApplicationContext, "you clicked a button", ToastLength.Short).Show();
			//throw new System.NotImplementedException();
		}
	}
}

