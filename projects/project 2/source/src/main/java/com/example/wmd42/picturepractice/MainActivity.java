package com.example.wmd42.picturepractice;

import android.content.Intent;
import android.graphics.Bitmap;
import android.provider.MediaStore;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    Button btnpic;
    ImageView imgPicTaken;
    private static final int CAN_REQUEST = 1313;
    Bitmap bitmap;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        btnpic = (Button) findViewById(R.id.button);
        imgPicTaken = (ImageView)findViewById(R.id.image);
        btnpic.setOnClickListener(new btnTakePhotoClicker());


    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        if(requestCode == CAN_REQUEST){
            bitmap = (Bitmap) data.getExtras().get("data");
            if(bitmap != null) {
                imgPicTaken.setImageBitmap(bitmap);
            }
            else{
                Toast.makeText(this, "bitmap fetch error", Toast.LENGTH_SHORT);
            }
        }
    }

    class btnTakePhotoClicker implements Button.OnClickListener{

        public void onClick(View view) {

            Intent intent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
            if (intent.resolveActivity(getPackageManager()) != null) {
                startActivityForResult(intent, CAN_REQUEST);

            }
        }
    }
}
