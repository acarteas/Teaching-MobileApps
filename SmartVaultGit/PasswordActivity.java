package com.example.jww193.smartvaultapp2;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Toast;
import android.widget.Button;
import android.content.Intent;

public class PasswordActivity extends AppCompatActivity {
    Button openVaultButton;
    Button closeVaultButton;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.password_main);

        openVaultButton = (Button)findViewById(R.id.openVault);
        closeVaultButton = (Button)findViewById(R.id.closeVault);
    }

    public void openVaultClick(View v)
    {
        Toast.makeText(this, "The Vault has been unlocked!", Toast.LENGTH_SHORT).show();
    }

    public void closeVaultClick(View v)
    {
        Toast.makeText(this , "The Vault has been locked!", Toast.LENGTH_SHORT).show();
    }

}
