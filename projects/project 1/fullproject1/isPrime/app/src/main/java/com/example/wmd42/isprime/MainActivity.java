package com.example.wmd42.isprime;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;

import com.example.wmd42.isprime.R;

import java.lang.Math;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void checkPrime( View view )
    {
        EditText etext = (EditText) findViewById(R.id.editText);
        double ournum = Double.parseDouble(etext.getText().toString());
        TextView ourtext = (TextView) findViewById(R.id.textView);
        boolean isprime = true;
        for(int i = 2; i < 10; i++){
            if(Math.floor(ournum/i) == (ournum/i) && (ournum != i) ){
                isprime = false;
                Log.i(Integer.toString(i),"1");
            }
        }

        if(isprime){
            ourtext.setText((int)ournum + " is a prime number");
        }
        else{
            ourtext.setText((int)ournum + " is a composite number");
        }


    }
}
