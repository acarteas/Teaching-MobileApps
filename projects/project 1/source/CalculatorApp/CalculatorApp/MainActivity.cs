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

        //create the buttons?
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //declare the view to edit
            TextView results = FindViewById<TextView>(Resource.Id.calc_results);

            //declares button to use
            //TODO: declare the rest of the buttons
            Button bttn0 = FindViewById<Button>(Resource.Id.button_zero);
            Button bttn1 = FindViewById<Button>(Resource.Id.button_one);
            Button bttn2 = FindViewById<Button>(Resource.Id.button_two);
            Button bttn3 = FindViewById<Button>(Resource.Id.button_three);
            Button bttn4 = FindViewById<Button>(Resource.Id.button_four);
            Button bttn5 = FindViewById<Button>(Resource.Id.button_five);
            Button bttn6 = FindViewById<Button>(Resource.Id.button_six);
            Button bttn7 = FindViewById<Button>(Resource.Id.button_seven);
            Button bttn8 = FindViewById<Button>(Resource.Id.button_eight);
            Button bttn9 = FindViewById<Button>(Resource.Id.button_nine);
            Button bttn_multiply = FindViewById<Button>(Resource.Id.button_one);
            Button bttn_divide = FindViewById<Button>(Resource.Id.button_one);
            Button bttn_subract = FindViewById<Button>(Resource.Id.button_one);
            Button bttn_add = FindViewById<Button>(Resource.Id.button_one);
            Button bttn_equal = FindViewById<Button>(Resource.Id.button_equal);
            Button bttn_clear = FindViewById<Button>(Resource.Id.button_clear);
            Button bttn_mod = FindViewById<Button>(Resource.Id.button_mod);
            Button bttn_delete = FindViewById<Button>(Resource.Id.button_delete);
           

            //created delagate instance and added it to click event
           // bttn1.Click += new EventHandler(this.Button_click);

        }
        //Event Handler: Adds the button clicked onto the TextView and the Stack
        private void add_button_click(object sender, System.EventArgs e)
        {
            Button a_button = sender as Button;
            TextView results = FindViewById<TextView>(Resource.Id.calc_results);
            results.Text += (a_button);
        }

        //Event Handler: Clears the TextView
        private void text_clear_button(object sender, System.EventArgs e)
        {
            Button a_button = sender as Button;
            TextView results = FindViewById<TextView>(Resource.Id.calc_results);
            results.Text += " ";
        }

        //Event Handler: Clears the TextView and the Stack
        private void all_clear_button(object sender, System.EventArgs e)
        {
            Button a_button = sender as Button;
            TextView results = FindViewById<TextView>(Resource.Id.calc_results);
            results.Text += " ";
            calc_stack.Clear();
        }
       
        //Deletes a character from the TextView
        private void delete_button(object sender, System.EventArgs e)
        {
            Button a_button = sender as Button;
            TextView results = FindViewById<TextView>(Resource.Id.calc_results);
            string text = results.Text;
            text.Remove(text.Length - 1);
            results.Text += text;
        }




    }

}

