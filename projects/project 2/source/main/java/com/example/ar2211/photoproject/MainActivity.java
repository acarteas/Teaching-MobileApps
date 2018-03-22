package com.example.ar2211.photoproject;

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
import android.widget.ViewSwitcher;


import java.io.FileNotFoundException;

public class MainActivity extends AppCompatActivity
{
    int REQUEST_CODE = 1;
    TextView textTargetUri;
    ImageView targetImage;
    Button camera;
    Button grey;
    /**
     * Called when the activity is first created.
     */
    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Button buttonLoadImage = (Button) findViewById(R.id.galleryButton);
        textTargetUri = (TextView) findViewById(R.id.targeturi);
        targetImage = (ImageView) findViewById(R.id.targetimage);
        camera = (Button)findViewById(R.id.cameraButton);
        grey = (Button)findViewById(R.id.greyButton);



        buttonLoadImage.setOnClickListener(new Button.OnClickListener()
        {

            @Override
            public void onClick(View arg0)
            {
                // TODO Auto-generated method stub
                Intent intent = new Intent(Intent.ACTION_PICK,
                        android.provider.MediaStore.Images.Media.EXTERNAL_CONTENT_URI);
                startActivityForResult(intent, 0);
            }
        });


        //take a new photo
        camera.setOnClickListener(new Button.OnClickListener() {
            public void onClick(View arg0) {
                Intent cameraIntent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
                if (cameraIntent.resolveActivity(getPackageManager()) != null) //check if camera application is available on device
                {
                    startActivityForResult(cameraIntent, 1);
                }
            }
        });

        grey.setOnClickListener(new Button.OnClickListener()
        {
            public void onClick(View arg0)
            {
                Bitmap operation;
                Bitmap bmp = null;
                operation = Bitmap.createBitmap(bmp.getWidth(),bmp.getHeight(), bmp.getConfig());
                double red = 0.33;
                double green = 0.59;
                double blue = 0.11;

                for (int i = 0; i < bmp.getWidth(); i++) {
                    for (int j = 0; j < bmp.getHeight(); j++) {
                        int p = bmp.getPixel(i, j);
                        int r = Color.red(p);
                        int g = Color.green(p);
                        int b = Color.blue(p);

                        r = (int) red * r;
                        g = (int) green * g;
                        b = (int) blue * b;
                        operation.setPixel(i, j, Color.argb(Color.alpha(p), r, g, b));
                    }
                }
                targetImage.setImageBitmap(operation);

            }
        });


    }



    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        // TODO Auto-generated method stub
        super.onActivityResult(requestCode, resultCode, data);

        if (resultCode == RESULT_OK)
        {
            if (requestCode == 0)
            {
                Uri targetUri = data.getData();
                Bitmap bitmap;
                try
                {
                    bitmap = BitmapFactory.decodeStream(getContentResolver().openInputStream(targetUri));
                    targetImage.setImageBitmap(bitmap);
                }
                catch (FileNotFoundException e)
                {
                    // TODO Auto-generated catch block
                    e.printStackTrace();
                }
                if (requestCode == 3)
                {
                    Bundle bundle = new Bundle();
                    bundle = data.getExtras();
                    Bitmap BMP;
                    BMP = (Bitmap)bundle.get("data");
                    targetImage.setImageBitmap(BMP);
                }

            }
        }
    }
}
