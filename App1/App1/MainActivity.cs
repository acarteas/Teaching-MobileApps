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

            
            AnswerA.Click += delegate { AnswerA.Text = string.Format("{0} clicks!", count++); };

            //testing another click event that involves altering the text of the question
            AnswerB.Click += delegate
            {
                //code for psuedo random number generator for c# from:
                //https://stackoverflow.com/questions/2706500/how-do-i-generate-a-random-int-number-in-c
                Random rand = new Random();

                //should give number a somewhat random number to help choose a random 
                int number = rand.Next(10);

                //has 5 random questions depending on what teh number was
                if(number >= 0 && number < 5)
                {
                    Question.Text = string.Format("Who Lives In A Pinapple Under The Sea?");
                }

            };


            //these at first should add 1-2 points to the score box below them each time the buttons are clicked
            AnswerC.Click += delegate { Score.Text = string.Format("{0} Points", count++); };
            AnswerD.Click += delegate { Score.Text = string.Format("{0} Points", count++); };
        }
    }
}

