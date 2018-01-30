using Android.App;
using Android.Widget;
using Android.OS;
using Calculator.Library.ViewModels;

namespace Calculator
{
    

    [Activity(Label = "Calculator", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        private PostfixCalculatorViewModel _ViewModel { get; set; }
        private TextView _accumulatorTextView;

        /// <summary>
        /// Traverses document tree to attach listeners to view items marked with "Number" or "Operation" tags.
        /// </summary>
        /// <param name="view"></param>
        private void AttachListeners(Android.Views.View view)
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
                        AttachListeners(childGroup);
                    }
                    else
                    {
                        if(child.Tag != null)
                        {
                            string tag = child.Tag.ToString();
                            if (tag.CompareTo(Globals.CALC_NUMBER) == 0)
                            {
                                child.Click += Number_Click;
                            }
                            else if (tag.CompareTo(Globals.CALC_OPERATION) == 0)
                            {
                                child.Click += Operation_Click;
                            }
                        }
                    }
                }
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //keep reference to accumulator text
            _accumulatorTextView = FindViewById<TextView>(Resource.Id.calculatorAccumulator);

            //attach view event listeners
            LinearLayout layout = FindViewById<LinearLayout>(Resource.Id.MainPageLayout);
            AttachListeners(layout);

            //bind to view model event listeners
            _ViewModel = new PostfixCalculatorViewModel();
            _ViewModel.PropertyChanged += _ViewModel_PropertyChanged;
        }

        private void _ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName.CompareTo("AccumulatorText") == 0)
            {
                _accumulatorTextView.Text = _ViewModel.AccumulatorText;
            }
        }

        private void Number_Click(object sender, System.EventArgs e)
        {
            Button clicked = sender as Button;
            if(clicked != null)
            {
                int value = -1;
                if(System.Int32.TryParse(clicked.Text, out value) == true)
                {
                    _ViewModel.NumericAction(value);
                }
            }
        }

        private void Operation_Click(object sender, System.EventArgs e)
        {
            Button clicked = sender as Button;
            if (clicked != null)
            {
                //TODO: parse operation, pass to view model
                //do work here
            }
        }
    }
}

