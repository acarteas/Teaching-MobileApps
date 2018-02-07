package com.wmd42.hangman;

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

    public void clicked(View view){

        //if this is the first click, initialize the word guess and strguess arrays
        if(!isclicked){
            TextView numgues = (TextView) findViewById(R.id.chancesLeft);
            TextView letgues = (TextView) findViewById(R.id.guessedLetter);
            EditText inbox = (EditText) findViewById(R.id.Input);
            ourword = inbox.getText().toString();
            wordchars = new char[ourword.length()];
            wordchars = ourword.toCharArray();
            strguess = new char[ourword.length()];
            Log.i("test",ourword);
            //fill guess array with underscores
            for(int i = 0; i < ourword.length(); i++){
                strguess[i] = '_';
                Log.i("guessarray", Character.toString(strguess[i]));
            }

            //display guesses

            CharSequence guessdisplay = Arrays.toString(strguess);
            Log.i("underscores", (String)guessdisplay);
            letgues.setText(guessdisplay);

            //displays chances left
            numgues.setText((CharSequence)String.format("You have %d chances left", chances));

            isclicked = true;

        }
    }

}
