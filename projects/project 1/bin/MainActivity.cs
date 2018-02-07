using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace PA1_AndrApp
{
    [Activity(Label = "PA1_AndrApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        EditText firstUnitValue;
        TextView secondUnitValue;
        Button resultButton;
        Spinner spinnerOne;
        Spinner spinnerTwo;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            // this is the button that returns the result of the unit conversion
            resultButton = FindViewById<Button>(PA1_AndrApp.Resource.Id.resultButton);

            // finds the value of the first unit by id in EditText
            firstUnitValue = FindViewById<EditText>(PA1_AndrApp.Resource.Id.firstUnitValue);
            // finds the value of the second unit by id in TextView
            secondUnitValue = FindViewById<TextView>(PA1_AndrApp.Resource.Id.secondUnitValue);
            //finds the value of the first Spinner by id
            Spinner spinnerOne = FindViewById<Spinner>(Resource.Id.spinnerOne);
            // finds the value of the second Spinner by id
            Spinner spinnerTwo = FindViewById<Spinner>(Resource.Id.spinnerTwo);

            // adapative item select for first Spinner
            spinnerOne.ItemSelected += new System.EventHandler<AdapterView.ItemSelectedEventArgs>(Spinner_FirstItemSelected);
            // adaptive item select for second Spinner
            spinnerTwo.ItemSelected += new System.EventHandler<AdapterView.ItemSelectedEventArgs>(Spinner_SecondItemSelected);

            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.unit_array, Android.Resource.Layout.SimpleSpinnerItem);

            resultButton.Click += TheResult_Click;

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerOne.Adapter = adapter;
            spinnerTwo.Adapter = adapter;

            firstUnitValue = FindViewById<EditText>(PA1_AndrApp.Resource.Id.firstUnitValue);
            spinnerOne = FindViewById<Spinner>(PA1_AndrApp.Resource.Id.spinnerOne);
            spinnerTwo = FindViewById<Spinner>(PA1_AndrApp.Resource.Id.spinnerTwo);

        }

        // displays the item selected within the spinner one
        private void Spinner_FirstItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinnerOne = (Spinner)sender;
            string selectedItem = spinnerOne.SelectedItem.ToString();
            string toast = string.Format("You have chosen: {0}",spinnerOne.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        // displays the item selected within the spinner two
        private void Spinner_SecondItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinnerTwo = (Spinner)sender;
            string selectedItem2 = spinnerTwo.SelectedItem.ToString();
            string toast2 = string.Format("You have chosen: {0}", spinnerTwo.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast2, ToastLength.Long).Show();
        }

        // function to convert inches to feet 
        void Inches_to_Feet (object sender, System.EventArgs e)
        {
            float inch = float.Parse(firstUnitValue.Text);
            float inch_to_feet_result = inch / 12f;
        }

        // function to convert feet to inches
         void Feet_to_Inches(object sender, System.EventArgs e)
         {
             float feet = float.Parse(firstUnitValue.Text);
             float feet_to_inch_result = feet * 12f;
         }
 
        // function for Compute Button
         void TheResult_Click(object sender, System.EventArgs e)
        {
            float inch = float.Parse(firstUnitValue.Text);
            float inch_to_feet_result = inch / 12f;

            float feet = float.Parse(firstUnitValue.Text);
            float feet_to_inch_result = feet * 12f;

            string selectedItem = spinnerTwo.SelectedItem.ToString();
            string selectedItem2 = spinnerTwo.SelectedItem.ToString();

            if (selectedItem == "inches" && selectedItem2 == "feet")
            {
                secondUnitValue.Text = inch_to_feet_result.ToString();
            }

            else if (selectedItem == "feet" && selectedItem2 == "inches")
            {
                secondUnitValue.Text = feet_to_inch_result.ToString();
            }

            else if (selectedItem == "Select One" || selectedItem2 == "Select One")
            {
                Console.WriteLine("Invalid"); 
            }
        }
    }

 
}

