using Android.App;
using Android.Widget;
using Android.OS;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            //named and retrieved the 4 buttons and both text boxes id #'s and gave them a variable name
            Button AnswerA = FindViewById<Button>(Resource.Id.PossibleAnswerA);
            Button AnswerB = FindViewById<Button>(Resource.Id.PossibleAnswerB);
            Button AnswerC = FindViewById<Button>(Resource.Id.PossibleAnswerC);
            Button AnswerD = FindViewById<Button>(Resource.Id.PossibleAnswerD);
            TextView Question = FindViewById<TextView>(Resource.Id.QuestionText);
            TextView Score = FindViewById<TextView>(Resource.Id.ScoreBoard);

            //these both are keeping the basic code given to test the bottom 2 buttons
            AnswerA.Click += delegate { AnswerA.Text = string.Format("{0} clicks!", count++); };
            AnswerB.Click += delegate { AnswerA.Text = string.Format("{0} clicks!", count++); };

            //these at first should add 1-2 points to the score box below them each time the buttons are clicked
            AnswerC.Click += delegate { Score.Text = string.Format("{0} Points", count++); };
            AnswerD.Click += delegate { Score.Text = string.Format("{0} Points", count++); };
        }
    }
}

