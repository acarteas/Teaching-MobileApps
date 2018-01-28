using Android.App;
using Android.Widget;
using Android.OS;

namespace Calculator
{
    [Activity(Label = "Calculator", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        private void Listen(Android.Views.View view)
        {
            Android.Views.ViewGroup group = view as Android.Views.ViewGroup;
            if (group != null)
            {
                for (int i = 0; i < group.ChildCount; i++)
                {
                    var child = group.GetChildAt(i);
                    var childGroup = child as Android.Views.ViewGroup;
                    if (childGroup != null)
                    {
                        Listen(childGroup);
                    }
                    else
                    {
                        //var t1 = 
                        string tag = child.Tag.ToString();
                    }
                }
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            LinearLayout layout = FindViewById<LinearLayout>(Resource.Id.MainPageLayout);
            for(int i = 0; i < layout.ChildCount; i++)
            {
                var item = layout.GetChildAt(i);
                var foundNumbers = item.FindViewWithTag("Number");
                var foundOperations = item.FindViewWithTag("Operation");

            }

            var rows = layout.FindViewWithTag(Resource.String.calculator_row);

            double result = 0.0;
            if(double.TryParse("+", out result) == false)
            {
                //must be +, -, *, /
            }
            else
            {
                //is a number
            }

            Button b = FindViewById<Button>(Resource.Id.calcButton0);
            b.Click += B_Click;
        }

        private void B_Click(object sender, System.EventArgs e)
        {
            Button clicked = sender as Button;
            if(clicked != null)
            {
                //do work here
            }
        }
    }
}

