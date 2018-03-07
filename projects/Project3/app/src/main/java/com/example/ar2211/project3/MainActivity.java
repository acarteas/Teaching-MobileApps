package com.example.ar2211.project3;

import android.content.Intent;
import android.provider.MediaStore;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.Button;

import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.Bundle;
import android.provider.MediaStore;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;
import android.graphics.Color;


import java.io.FileNotFoundException;

public class MainActivity extends AppCompatActivity {

    TextView textTargetUri;
    ImageView targetImage;

    private Bitmap bmp;
    private Bitmap operation;

    /** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        textTargetUri = (TextView)findViewById(R.id.targeturi);
        targetImage = (ImageView)findViewById(R.id.targetimage);

        buttonLoadImage.setOnClickListener(new Button.OnClickListener(){

            @Override
            public void onClick(View arg0) {
                // TODO Auto-generated method stub
                Intent intent = new Intent(Intent.ACTION_PICK,
                        android.provider.MediaStore.Images.Media.EXTERNAL_CONTENT_URI);
                startActivityForResult(intent, 0);
            });
            //take a new photo
             .setOnClickListener(new Button.OnClickListener() {
                public void onClick(View arg0) {
                    Intent cameraIntent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
                    if (cameraIntent.resolveActivity(getPackageManager()) != null) //check if camera application is available on device
                    {
                        startActivityForResult(cameraIntent, 1);
                    }
                }
            }
        }

