package com.example.jww193.vaultapp;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.content.Intent;
import android.widget.Button;

public class MainActivity extends AppCompatActivity {
    Button loginButtonActivity;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        loginButtonActivity = (Button) findViewById(R.id.loginButton);
    }

    public void loginButtonClick(View v) {
        Intent intent = new Intent(this, PasswordActivity.class);
        startActivity(intent);
    }
}

