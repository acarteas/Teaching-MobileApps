using Android.App;
using Android.Widget;
using Android.OS;

namespace QuestionareApp
{
    [Activity(Label = "QuestionareApp", MainLauncher = true)]
    public class MainActivity : Activity
    {
        //variables that are used to keep track of seprate values
        int count = 0;
        int count1 = 0;
        int points = 0;

        //obtains the id's for all buttons and text boxes
        Button AnswerA = FindViewById<Button>(Resource.Id.PossibleAnswerA);
        Button AnswerB = FindViewById<Button>(Resource.Id.PossibleAnswerB);
        Button AnswerC = FindViewById<Button>(Resource.Id.PossibleAnswerC);
        Button AnswerD = FindViewById<Button>(Resource.Id.PossibleAnswerD);
        TextView Question = FindViewById<TextView>(Resource.Id.QuestionText);
        TextView Score = FindViewById<TextView>(Resource.Id.ScoreBoard);

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //start the questions when the a button is clicked
            AnswerA.Click += start;

            //just changes the pointless button's text once and keeps it to this like a bad joke
            AnswerB.Click += delegate { AnswerB.Text = string.Format("Told you."); };

            //these at first should add 1-2 points to the score box below them each time the buttons are clicked
            AnswerC.Click += delegate { AnswerC.Text = string.Format("You have clicked {0} times", count += 1); };
            AnswerD.Click += delegate { AnswerD.Text = string.Format("{0} Points have been added", count1 += 2); };

        }

        //first question to be answerd
        void start(object sender, System.EventArgs e)
        {
            
            count = 0;

            Button clicked = sender as Button;

            if (clicked != null)
            {
                //sets up the text for buttons and text box's
                Question.Text = string.Format("Who Lives In A Pineapple Under The Sea?");
                AnswerA.Text = string.Format("Gary");
                AnswerB.Text = string.Format("Patrick");
                AnswerC.Text = string.Format("Gingy");
                AnswerD.Text = string.Format("Non of the Above");
                Score.Text = string.Format("{0}", points);

                //unsubscribes buttons from their old use
                AnswerA.Click -= start;
                AnswerB.Click -= delegate { AnswerB.Text = string.Format("Told you."); };
                AnswerC.Click -= delegate { AnswerC.Text = string.Format("You have clicked {0} times", count += 1); };
                AnswerD.Click -= delegate { AnswerD.Text = string.Format("{0} Points have been added", count1 += 2); };

                //subscribes new affects to the buttons 
                AnswerA.Click += delegate { Score.Text = string.Format("{0} Points", points += 1); };
                AnswerA.Click += questionSet2;
                AnswerB.Click += questionSet2;
                AnswerC.Click += questionSet2;
                AnswerD.Click += questionSet2;

            }

        }



        //second question to be answerd
        void questionSet2(object sender, System.EventArgs e)
        {
            

            //sets up the text for buttons and text box's
            Question.Text = string.Format("How many calories do you burn an hour banging your head against a wall?");
            AnswerA.Text = string.Format("200");
            AnswerB.Text = string.Format("75");
            AnswerC.Text = string.Format("150");
            AnswerD.Text = string.Format("30");
            Score.Text = string.Format("{0}", points);

            //unsubscribes buttons from their old use
            AnswerA.Click -= delegate { Score.Text = string.Format("{0} Points", points += 1); };
            AnswerA.Click -= questionSet2;
            AnswerB.Click -= questionSet2;
            AnswerC.Click -= questionSet2;
            AnswerD.Click -= questionSet2;

            //subscribes new affects to the buttons
            AnswerA.Click += questionSet3;
            AnswerB.Click += questionSet3;
            AnswerC.Click += delegate { Score.Text = string.Format("{0} Points", points += 1); };
            AnswerC.Click += questionSet3;
            AnswerD.Click += questionSet3;

        }

        //Third question to be answerd
        void questionSet3(object sender, System.EventArgs e)
        {
            
            //sets up the text for buttons and text box's
            Question.Text = string.Format("What is a flock of crows called?");
            AnswerA.Text = string.Format("flock");
            AnswerB.Text = string.Format("murder");
            AnswerC.Text = string.Format("wisp");
            AnswerD.Text = string.Format("regatta");
            Score.Text = string.Format("{0}", points);

            //unsubscribes buttons from their old use
            AnswerA.Click -= questionSet3;
            AnswerB.Click -= questionSet3;
            AnswerC.Click -= delegate { Score.Text = string.Format("{0} Points", points += 1); };
            AnswerC.Click -= questionSet3;
            AnswerD.Click -= questionSet3;

            //subscribes new affects to the buttons
            AnswerA.Click += questionSet4;
            AnswerB.Click += delegate { Score.Text = string.Format("{0} Points", points += 1); };
            AnswerB.Click += questionSet4;
            AnswerC.Click += questionSet4;
            AnswerD.Click += questionSet4;

        }

        //fourth question to be answerd
        void questionSet4(object sender, System.EventArgs e)
        {
            

            //sets up the text for buttons and text box's
            Question.Text = string.Format("which of these are an island in Canada?");
            AnswerA.Text = string.Format("La Isla de las Muñecas");
            AnswerB.Text = string.Format("Ramree Island");
            AnswerC.Text = string.Format("Howland Island");
            AnswerD.Text = string.Format("Dildo Island");
            Score.Text = string.Format("{0}", points);

            //unsubscribes buttons from their old use
            AnswerA.Click -= questionSet4;
            AnswerB.Click -= delegate { Score.Text = string.Format("{0} Points", points += 1); };
            AnswerB.Click -= questionSet4;
            AnswerC.Click -= questionSet4;
            AnswerD.Click -= questionSet4;

            //subscribes new affects to the buttons
            AnswerA.Click += ending;
            AnswerB.Click += ending;
            AnswerC.Click += ending;
            AnswerD.Click += delegate { Score.Text = string.Format("{0} Points", points += 1); };
            AnswerD.Click += ending;

        }

        //points earned and random button affects
        void ending(object sender, System.EventArgs e)
        {
            

            //sets up the text for buttons and text box's
            Question.Text = string.Format("You got {0} Points", points);
            AnswerA.Text = string.Format("Click me I'm also pointless");
            AnswerB.Text = string.Format("Click me for a random string of letters");
            AnswerC.Text = string.Format("Click me i'm even more pointless than the Last one");
            AnswerD.Text = string.Format("I ran out of ideas but you can still click me");
            Score.Text = string.Format("{0}", points);

            //unsubscribes buttons from their old use
            AnswerA.Click -= ending;
            AnswerB.Click -= ending;
            AnswerC.Click -= ending;
            AnswerD.Click -= delegate { Score.Text = string.Format("{0} Points", points += 1); };
            AnswerD.Click -= ending;

            //subscribes new affects to the buttons
            AnswerA.Click += delegate { AnswerA.Text = string.Format("Gotcha you thouhgt i was gonna do the same thing as before"); };
            AnswerB.Click += delegate { AnswerB.Text = string.Format("a;lvnrblkbnxigslkbg"); };
            AnswerC.Click += delegate { AnswerC.Text = string.Format("¯\\_(ツ)_/¯"); };
            AnswerD.Click += delegate { AnswerD.Text = string.Format("(ﾉ◕ヮ◕)ﾉ*:･ﾟ✧"); };
        }

    }
}


