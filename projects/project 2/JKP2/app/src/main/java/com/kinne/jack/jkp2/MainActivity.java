package com.kinne.jack.jkp2;
//Jack Daniel Kinne.  Project 2.  Mobile Apps CS 480.
import android.content.Intent;
import android.graphics.Bitmap;
import android.net.Uri;
import android.os.Environment;
import android.provider.MediaStore;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;

import java.io.File;
import java.text.SimpleDateFormat;
import java.util.Date;

public class MainActivity extends AppCompatActivity {

    //button for taking pictures
    Button btnpic;
    //button for transfering activities
    Button actChange;
    //image we will be messing with
    ImageView imgTakenPic;
    Bitmap bitmap;
    private static final int CAM_REQUEST=1313;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        //taking a picture buton and event
        btnpic = (Button) findViewById(R.id.takePhotoButton);
        imgTakenPic = (ImageView)findViewById(R.id.imageView);
        btnpic.setOnClickListener(new btnTakePhotoClicker());

        //changing activity button and event
        actChange = (Button) findViewById(R.id.editPhotoButton);
        actChange.setOnClickListener(new changeActivity());
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        try {
            if (requestCode == CAM_REQUEST) {
                bitmap = (Bitmap) data.getExtras().get("data");
                imgTakenPic.setImageBitmap(bitmap);

            }
        }
        catch  (Exception e){}
    }

    //take a photo
    class btnTakePhotoClicker implements  Button.OnClickListener{

        @Override
        public void onClick(View view) {
            Intent intent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
            startActivityForResult(intent, CAM_REQUEST);
        }
    }

    //change activity
    class changeActivity implements  Button.OnClickListener{

        @Override
        public void onClick(View view) {
            Intent intent = new Intent(getApplicationContext(),Activity2.class);
            // to pass bitmap across!
            intent.putExtra("bitmap", bitmap );
            startActivity(intent);
        }
    }


}