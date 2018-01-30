using Android.App;
using Android.Widget;
using Android.OS;
using Android.Text;
using System;
using System.Collections.Generic;

namespace Postfix_Calculator
{
    [Activity(Label = "Postfix Calculator", MainLauncher = true, Icon = "@mipmap/icon")]
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
            
            EditText editInput = FindViewById<EditText>(Resource.Id.edtTextInput);
            TextView textResult = FindViewById<TextView>(Resource.Id.txtResult);

            //handle buttons
            Button btnClear = FindViewById<Button>(Resource.Id.btnClear);
            Button btnCopy = FindViewById<Button>(Resource.Id.btnCopy);
            Button btnNegative = FindViewById<Button>(Resource.Id.btnNegative);
            Button btnDivide = FindViewById<Button>(Resource.Id.btnDivide);
            Button btnSeven = FindViewById<Button>(Resource.Id.btnSeven);
            Button btnEight = FindViewById<Button>(Resource.Id.btnEight);
            Button btnNine = FindViewById<Button>(Resource.Id.btnNine);
            Button btnMultiply = FindViewById<Button>(Resource.Id.btnMultiply);
            Button btnFour = FindViewById<Button>(Resource.Id.btnFour);
            Button btnFive = FindViewById<Button>(Resource.Id.btnFive);
            Button btnSix = FindViewById<Button>(Resource.Id.btnSix);
            Button btnMinus = FindViewById<Button>(Resource.Id.btnMinus);
            Button btnOne = FindViewById<Button>(Resource.Id.btnOne);
            Button btnTwo = FindViewById<Button>(Resource.Id.btnTwo);
            Button btnThree = FindViewById<Button>(Resource.Id.btnThree);
            Button btnPlus = FindViewById<Button>(Resource.Id.btnPlus);
            Button btnSpace = FindViewById<Button>(Resource.Id.btnSpace);
            Button btnZero= FindViewById<Button>(Resource.Id.btnZero);
            Button btnDecimal = FindViewById<Button>(Resource.Id.btnDecimal);
            Button btnEquals = FindViewById<Button>(Resource.Id.btnEquals);

            btnClear.Click += delegate
            {
                editInput.Text = "";
                textResult.Text = "0";
            };

            btnCopy.Click += delegate
            {
                //i may not use this button, placeholder for something else
            };

            btnNegative.Click += delegate
            {
                //todo
            };

            btnDivide.Click += delegate
            {
                if (TextUtils.IsEmpty(editInput.Text))
                    {
                    editInput.Append("\\ ");
                }
                else
                {
                    editInput.Append(" \\ ");
                }
            };
            
            btnSeven.Click += delegate
            {
                editInput.Append("7");
            };

            btnEight.Click += delegate
            {
                editInput.Append("8");
            };

            btnNine.Click += delegate
            {
                editInput.Append("9");
            };

            btnMultiply.Click += delegate
            {
                if (TextUtils.IsEmpty(editInput.Text))
                {
                    editInput.Append("* ");
                }
                else
                {
                    editInput.Append(" * ");
                }
            };

            btnFour.Click += delegate
            {
                editInput.Append("4");
            };

            btnFive.Click += delegate
            {
                editInput.Append("5");
            };

            btnSix.Click += delegate
            {
                editInput.Append("6");
            };

            btnMinus.Click += delegate
            {
                if (TextUtils.IsEmpty(editInput.Text))
                {
                    editInput.Append("- ");
                }
                else
                {
                    editInput.Append(" - ");
                }
            };

            btnOne.Click += delegate
            {
                editInput.Append("1");
            };

            btnTwo.Click += delegate
            {
                editInput.Append("2");
            };

            btnThree.Click += delegate
            {
                editInput.Append("3");
            };

            btnPlus.Click += delegate
            {
                if (TextUtils.IsEmpty(editInput.Text))
                {
                    editInput.Append("+ ");
                }
                else
                {
                    editInput.Append(" + ");
                }
            };

            btnSpace.Click += delegate
            {
                editInput.Append(" ");
            };

            btnEquals.Click += delegate
            {
                if (!TextUtils.IsEmpty(editInput.Text))
                {
                    calculate();
                }
            };


            textResult.Text = "0";

            //button.AfterTextChanged += doSomethingWithButton;

            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

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

