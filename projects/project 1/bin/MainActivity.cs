using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Collections.Generic;

namespace PA1_ConversionCalc
{
    [Activity(Label = "PA1_ConversionCalc", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        EditText firstValue;
        TextView secondValue;
        Button resultButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            // setting up layout
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            resultButton = FindViewById<Button>(Resource.Id.resultButton);
            firstValue = FindViewById<EditText>(Resource.Id.firstValue);
            secondValue = FindViewById<TextView>(Resource.Id.secondValue);


            //finds the value of the first Spinner by id
            Spinner spinnerOne = FindViewById<Spinner>(Resource.Id.spinnerOne);
            // adaptive item select for first Spinner
            spinnerOne.ItemSelected += new System.EventHandler<AdapterView.ItemSelectedEventArgs>(Spinner_FirstItemSelected);

            // finds the value of the second Spinner by id
            Spinner spinnerTwo = FindViewById<Spinner>(Resource.Id.spinnerTwo);
            // adaptive item select for second Spinner
            spinnerTwo.ItemSelected += new System.EventHandler<AdapterView.ItemSelectedEventArgs>(Spinner_SecondItemSelected);

            // creating arrays for two spinners
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.unit_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerOne.Adapter = adapter;
            spinnerTwo.Adapter = adapter;

            // creates a click event when the result button is clicked
            resultButton.Click += TheResult_Click;
        }

        // creates a toast to be displayed when an item is chosen in the first spinner
        public void Spinner_FirstItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinnerOne = (Spinner)sender;
            //string selectedItem = spinnerOne.SelectedItem.ToString();
            string selectedItem = string.Format("{0}", spinnerOne.GetItemAtPosition(e.Position));
            string toast = string.Format("You {0}", spinnerOne.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Short).Show();
        }

        // creates a toast to be displayed when an item is chosen in the second spinner
        public void Spinner_SecondItemSelected(object sender, AdapterView.ItemSelectedEventArgs f)
        {
            Spinner spinnerTwo = (Spinner)sender;
            //string selectedItem2 = spinnerTwo.SelectedItem.ToString();
            string selectedItem2 = string.Format("{0}", spinnerTwo.GetItemAtPosition(f.Position));
            string toast2 = string.Format("You have chosen: {0}", spinnerTwo.GetItemAtPosition(f.Position));
            Toast.MakeText(this, toast2, ToastLength.Short).Show();
    
        }
        // function for the result button click
        // will display the result based on the units chosen and the amount entered by the user
        // and display it into the second textview
        public void TheResult_Click(object sender, System.EventArgs g)
        {
            // inches to feet conversion equation
            float inch = float.Parse(firstValue.Text);
            float inch_to_feet_result = inch / 12f;
            // inches too centimeters conversion equation
            float inch_to_cent_result = inch * 2.54f;

            // feet to inch conversion equation
            float feet = float.Parse(firstValue.Text);
            float feet_to_inch_result = feet * 12f;
            // feet to centimeters conversion equation
            float feet_to_cent_result = feet * 30.48f;

            // centimeters to inches conversion equation
            float cent = float.Parse(firstValue.Text);
            float cent_to_inch_result = cent / 2.54f;
            // centimeters to feet conversion equation
            float cent_to_feet_result = cent / 30.48f;
          
            string firstUnitValue = "inch/es (in)";
            string secondUnitValue = "foot/feet (ft)";

            if (firstUnitValue == "inch/es (in)" && secondUnitValue == "foot/feet (ft)")
            {
                secondValue.Text = inch_to_feet_result.ToString();
            }

            else if (firstUnitValue == "inches/es (in)" && secondUnitValue == "centimeter/s (cm)")
            {
                secondValue.Text = inch_to_cent_result.ToString();
            }

            else if (firstUnitValue == "foot/feet (ft)" && secondUnitValue == "inch/es (in)")
            {
                secondValue.Text = feet_to_inch_result.ToString();
            }

            else if (firstUnitValue == "foot/feet (ft)" && secondUnitValue == "centimeter/s (cm)")
            {
                secondValue.Text = feet_to_cent_result.ToString();
            }

            else if (firstUnitValue == "centimeter/s (cm)" && secondUnitValue == "inch/es (in)")
            {
                secondValue.Text = cent_to_inch_result.ToString();
            }

            else if (firstUnitValue == "centimeter/s (cm)" && secondUnitValue == "foot/feet (ft)")
            {
                secondValue.Text = feet_to_cent_result.ToString();
            }
            else

            {
                secondValue.Text = ("Invalid").ToString();
            }
        } 
    } 
}

