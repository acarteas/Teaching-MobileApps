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

            //button.AfterTextChanged += doSomethingWithButton;

            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            button.Click += delegate
            {
                calculate();
            };

            void calculate()
            {
                Stack<int> input_stack = new Stack<int>();
                Queue<int> input_queue = new Queue<int>();

                Queue<int> temp_queue = new Queue<int>();
                string test = editInput.Text;
                int total = 0;
                string current_number = "";

                for (int i = 0; i < editInput.Text.Length; i++)
                {
                    switch (editInput.Text[i])
                    {
                        case '+':
                            /*
                            //need to check for anything in current_number in case they didnt add a space between last number and +
                            if (current_number != "")
                            {
                                input_stack.Push(Int32.Parse(current_number));
                                current_number = "";
                            }
                            
                            for (int j = 0; j <= input_stack.Count; j++)
                            {
                                total = total + input_stack.Pop();
                            }

                            input_stack.Push(total);
                            */

                            if (current_number != "")
                            {
                                input_queue.Enqueue(Int32.Parse(current_number));
                                current_number = "";
                            }

                            for (int j = 0; j <= input_queue.Count; j++)
                            {
                                total = total + input_queue.Dequeue();
                            }

                            input_queue.Enqueue(total);



                            break;

                        case '-':
                            if (current_number != "")
                            {
                                input_queue.Enqueue(Int32.Parse(current_number));
                                current_number = "";
                            }

                            //todo: if doing multiple items, maybe check if total is empty before setting it to the first item in queue
                            total = input_queue.Dequeue();

                            for (int j = 1; j <= input_queue.Count; j++)
                            {
                                total = total - input_queue.Dequeue();
                            }

                            input_queue.Enqueue(total);

                            break;

                        case '*':
                            if (current_number != "")
                            {
                                input_queue.Enqueue(Int32.Parse(current_number));
                                current_number = "";
                            }

                            total = input_queue.Dequeue();

                            for (int j = 1; j <= input_queue.Count; j++)
                            {
                                total = total * input_queue.Dequeue();
                            }

                            input_queue.Enqueue(total);
                            break;

                        case '/':
                            if (current_number != "")
                            {
                                input_queue.Enqueue(Int32.Parse(current_number));
                                current_number = "";
                            }

                            //todo: if doing multiple items, maybe check if total is empty before setting it to the first item in queue
                            total = input_queue.Dequeue();

                            for (int j = 1; j <= input_queue.Count; j++)
                            {
                                total = total / input_queue.Dequeue();
                            }

                            input_queue.Enqueue(total);

                            break;
                        case ' ':
                            input_queue.Enqueue(Int32.Parse(current_number));
                            current_number = "";
                            break;
                        default:
                            current_number = current_number + editInput.Text[i];
                            break;
                    }
                }

                textResult.Text = total.ToString();
                editInput.Text = "";
            }
        }
    }
}

