package com.willemthewalrus.hangman;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;

import java.util.Arrays;

public class MainActivity extends AppCompatActivity {

    private boolean isclicked = false; //to see if the button has been clicked yet
    private int chances = 6;
    private String ourword;   //the word inputted buy the user to be guessed
    private char[] wordchars; //contains the word to be guessed
    private char[] strguess; //contains current guesses and blank spots
    private String guessdisplay; //to be passed to TextView to display current guesses

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }


    public void clicked(View view) {

        //if this is the first click, initialize the word guess and strguess arrays
        if (!isclicked) {
            TextView numgues = (TextView) findViewById(R.id.chancesLeft);  //chances left textview
            TextView letgues = (TextView) findViewById(R.id.guessedLetter); //guess letters textview
            EditText inbox = (EditText) findViewById(R.id.Input); //input box editText
            ourword = inbox.getText().toString(); //
            wordchars = new char[ourword.length()];
            wordchars = ourword.toCharArray();
            strguess = new char[ourword.length()];
            Log.i("test", ourword);

            //fill guess array with underscores
            for (int i = 0; i < ourword.length(); i++) {
                strguess[i] = '_';
                Log.i("guessarray", Character.toString(strguess[i]));
            }

            //display guesses

            CharSequence guessdisplay = Arrays.toString(strguess);
            Log.i("underscores", (String) guessdisplay);
            letgues.setText(guessdisplay);

            //displays chances left
            numgues.setText((CharSequence) String.format("You have %d chances left", chances));

            //clear the text entry box
            inbox.setText("    ");

            //the button has now been clicked so set isclicked to true
            isclicked = true;

        }

        //this will run when it is not the first button usage
        else {
            

            EditText inbox = findViewById(R.id.Input);
            TextView topbox = findViewById(R.id.instructionsText);
            TextView letgues = findViewById(R.id.guessedLetter);
            char userentry = (inbox.getText().toString()).charAt(0);
            Log.i("user guess",Character.toString(userentry) );
             // will branch here if the entered character is not in the string
            if(ourword.indexOf(userentry) == -1  && chances > 0){
                chances--;
                topbox.setText("Woops! that letter wasn't in the word, please try again");

            }

            //will branch here if the entered character is within the word
            else if(ourword.indexOf(userentry) != -1  && chances > 0){
                boolean loopstopper = true;
                int i = 0;
                while(loopstopper){

                    //will update current guesses in ui with new matched letter
                    if(wordchars[i] == userentry){
                        strguess[i] = userentry;
                        wordchars[i] = '_';
                        i = 0;

                        CharSequence guessdisplay = Arrays.toString(strguess);
                        Log.i("correct guess", (String) guessdisplay);
                        letgues.setText(guessdisplay);

                    }

                    //breaks out of loop once the end of the word is reached with no matched chars
                    else if(wordchars[i] != userentry && i == wordchars.length-1){
                        loopstopper = false;
                        topbox.setText("Nice guess!");
                    }

                    //increments loop counter
                    else{
                        i++;
                    }
                }
                //check to see if there are any letters left to be guessed
                for(int j = 0; j < wordchars.length; j++){
                    if(wordchars[j] != '_'){
                        break;
                    }
                    else if(j == wordchars.length-1){
                        topbox.setText("congrats on guessing the word!! Enter in another word to start again");
                        isclicked = false;
                    }
                }
            }
            //will branch here when the user enters in a correct letter

        }

    }
}