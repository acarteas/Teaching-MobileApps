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
        Stack postfix_stack = new Stack();
        int enter_count = 0;
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
            Button bttn_subtract = FindViewById<Button>(Resource.Id.button_one);
            Button bttn_add = FindViewById<Button>(Resource.Id.button_one);
            Button bttn_enter = FindViewById<Button>(Resource.Id.button_enter);
            Button bttn_clear = FindViewById<Button>(Resource.Id.button_clear);
            Button bttn_clear_entry = FindViewById<Button>(Resource.Id.button_clear_entry);

            //numbers
            bttn0.Click += add_button_click;
          
            bttn2.Click += add_button_click;
            bttn3.Click += add_button_click;
            bttn4.Click += add_button_click;
            bttn5.Click += add_button_click;
            bttn6.Click += add_button_click;
            bttn7.Click += add_button_click;
            bttn8.Click += add_button_click;
            bttn9.Click += add_button_click;
            bttn1.Click += add_button_click;

            //operations
            bttn_multiply.Click += add_button_click;
            bttn_divide.Click += add_button_click;
            bttn_add.Click += add_button_click;
            bttn_subtract.Click += add_button_click;

            //clear, delete, clear entry
            bttn_clear.Click += all_clear_button;
            bttn_clear_entry.Click += text_clear_button;

            //enter click
            bttn_enter.Click += enter_button;
        }

        //Adds the button clicked onto the TextView and the Stack
        private void add_button_click(object sender, System.EventArgs e)
        {

            Button a_button = sender as Button;
            TextView results = FindViewById<TextView>(Resource.Id.calc_results);

            if (a_button.Text == "+")
            {
                results.Text += "+";
            }
            else if (a_button.Text == "-")
            {
                results.Text += "-";

            }
            else if (a_button.Text == "*")
            {
                results.Text += "*";

            }
            else if (a_button.Text == "/")
            {
                results.Text += "/";

            }
            else
            {
                results.Text += a_button.Text;
            }

            //sets enter presses back to 0
            enter_count = 0;
        }


        //Clears the TextView
        private void text_clear_button(object sender, System.EventArgs e)
        {
            TextView results = FindViewById<TextView>(Resource.Id.calc_results);
            results.Text = " ";
        }

        //Clears the TextView and the Stack
        private void all_clear_button(object sender, System.EventArgs e)
        {
            TextView results = FindViewById<TextView>(Resource.Id.calc_results);
            TextView final = FindViewById<TextView>(Resource.Id.final_results);

            results.Text = " ";
            final.Text = " ";
            enter_count = 0;
            calc_stack.Clear();
            postfix_stack.Clear();
        }

        //Enter button 
        private void enter_button(object sender, System.EventArgs e)
        {
            TextView results = FindViewById<TextView>(Resource.Id.calc_results);
            TextView final = FindViewById<TextView>(Resource.Id.final_results);
           // double output;

           

            enter_count += 1;

            if (enter_count > 1)
            {
                //translates the infix stack into a postfix stack
                ITP(calc_stack);
                //double.TryParse(final.Text, out output);
             {
                    double num1 = System.Convert.ToDouble(postfix_stack.Pop());
                    double num2 = System.Convert.ToDouble(postfix_stack.Pop());
                    string oper = System.Convert.ToString(postfix_stack.Pop());

                    //does calculations and sends to the top TextView
                    if (final.Text == "+")
                    {
                        final.Text = System.Convert.ToString(num1 + num2);
                    }
                    else if (final.Text == "-")
                    {
                        final.Text = System.Convert.ToString(num1 - num2);
                    }
                    else if (final.Text == "*")
                    {
                        final.Text = System.Convert.ToString(num1 * num2);
                    }
                    else if (final.Text == "/")
                    {
                        final.Text = System.Convert.ToString(num1 / num2);
                    }
                    else
                    {
                      
                        calc_stack.Push(System.Convert.ToDouble(final.Text));
                        
                    }
                }
            }
            else
            {
               //pushes text from the first textView into the top TextView
                final.Text += results.Text;
                results.Text = " ";
                calc_stack.Push((System.Convert.ToDouble(final.Text)));
                
        
            }

        }
        
        //Infix to Postfix parser
        private void ITP(Stack post_stack)
        {        
            string oper_holder = " ";
                  
            double num1 = -1.0;
            double num2 = -1.0;

            while (post_stack.Count != 0)
            {
                string some_string = System.Convert.ToString(post_stack.Pop());

                if (some_string == "+")
                {
                    oper_holder = "+";
                }
                else if (some_string == "-")
                {
                    oper_holder = "-";
                }
                else if (some_string == "*")
                {
                    oper_holder = "*";
                }
                else if (some_string == "/")
                {
                    oper_holder = "/";
                }
                else if(num1 == 1.0)
                {
                    if(num1 == -1.0)
                    {
                        //change to int
                        num1 = System.Convert.ToDouble(some_string);
                    }
                    else
                    {
                        num2 = System.Convert.ToDouble(some_string);
                    }
                }             
            }

            if (oper_holder != " " && num2 != -1.0)
            {
                postfix_stack.Push(oper_holder);
                postfix_stack.Push(num1);
                postfix_stack.Push(num2);
            }

        }
        





    }

}

