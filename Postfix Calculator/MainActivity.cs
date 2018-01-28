using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections;
using System;
using System.Collections.Generic;

namespace Postfix_Calculator
{
    [Activity(Label = "Postfix_Calculator", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        //int count = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.btnEquals);
            EditText editInput = FindViewById<EditText>(Resource.Id.edtTextInput);
            TextView textResult = FindViewById<TextView>(Resource.Id.txtResult);

            textResult.Text = "0";

            //button.AfterTextChanged += doSomethingWithButton;

            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            button.Click += delegate
            {
                calculate();
            };

            void calculate()
            {
                Queue<char> operator_queue = new Queue<char>();
                Queue<int> number_queue = new Queue<int>();
                char operator_char = '$';
                int total = 0;
                string current_number = "";

                for (int i = 0; i < editInput.Text.Length; i++)
                {
                    switch (editInput.Text[i])
                    {
                        case '+':
                    
                            //need to check for anything in current_number in case they didnt add a space between last number and +
                            if (current_number != "")
                            {
                                number_queue.Enqueue(Int32.Parse(current_number));
                                current_number = "";
                            }

                            operator_queue.Enqueue('+');
                            break;

                        case '-':
                            if (current_number != "")
                            {
                                number_queue.Enqueue(Int32.Parse(current_number));
                                current_number = "";
                            }

                            operator_queue.Enqueue('-');
                            break;

                        case '*':
                            if (current_number != "")
                            {
                                number_queue.Enqueue(Int32.Parse(current_number));
                                current_number = "";
                            }

                            operator_queue.Enqueue('*');
                            break;

                        case '/':
                            if (current_number != "")
                            {
                                number_queue.Enqueue(Int32.Parse(current_number));
                                current_number = "";
                            }

                            operator_queue.Enqueue('/');
                            break;
                        case ' ':
                            if (current_number != "")
                            {
                                number_queue.Enqueue(Int32.Parse(current_number));
                                current_number = "";
                            }
                            
                            break;
                        default:
                            current_number = current_number + editInput.Text[i];
                            break;
                    }
                }

                //have opeartors and numbers, now calculate
                total = number_queue.Dequeue();

                while(number_queue.Count != 0)
                {
                    if (operator_queue.Count != 0)
                    {
                        operator_char = operator_queue.Dequeue();
                    }

                    switch (operator_char)
                    {
                        case '+':
                            total = total + number_queue.Dequeue();
                            break;

                        case '-':
                            total = total - number_queue.Dequeue();
                            break;

                        case '*':
                            total = total * number_queue.Dequeue();
                            break;

                        case '/':
                            total = total / number_queue.Dequeue();
                            break;
                    }

                }

                textResult.Text = total.ToString();
                editInput.Text = "";
            }
        }
    }
}

