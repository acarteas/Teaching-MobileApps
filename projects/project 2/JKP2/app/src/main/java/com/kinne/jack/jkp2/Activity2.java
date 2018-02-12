package com.kinne.jack.jkp2;
//Jack Daniel Kinne.  Project 2.  Mobile Apps CS 480.
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BlurMaskFilter;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Matrix;
import android.graphics.Paint;
import android.graphics.PorterDuff;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.Switch;

import java.util.Random;

public class Activity2 extends AppCompatActivity {

    //button for transfering activities
    Button actChange;
    //image we will be messing with
    ImageView savedPic;
    Bitmap bitmap;
    //button for applying filters
    Button applyFilterButton;

    //switches
    Switch highlightSwitch;
    Switch grayscaleSwitch;
    Switch doGammaSwitch;
    Switch sepiaSwitch;
    Switch flipVSwitch;
    Switch flipHSwitch;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_2);

        //changing activity button and event
        actChange = (Button) findViewById(R.id.backButton);
        actChange.setOnClickListener(new Activity2.changeActivity());

        //restoring bitmap image in activity!
        bitmap = getIntent().getParcelableExtra("bitmap");
        savedPic = (ImageView)findViewById(R.id.imageView2);
        savedPic.setImageBitmap(bitmap);

        //apply filters
        applyFilterButton = (Button) findViewById(R.id.applyFilterButton);
        applyFilterButton.setOnClickListener(new Activity2.applyChanges());

        //switches get stitches
        highlightSwitch = (Switch) findViewById(R.id.highlightSwitch);
        grayscaleSwitch = (Switch) findViewById(R.id.grayscaleSwitch);
        doGammaSwitch = (Switch) findViewById(R.id.doGammaSwitch);
        sepiaSwitch = (Switch) findViewById(R.id.sepiaSwitch);
        flipHSwitch = (Switch) findViewById(R.id.flipHSwitch);
        flipVSwitch = (Switch) findViewById(R.id.flipVSwitch);
    }

    //highlight yonder imagery
    public static Bitmap doHighlightImage(Bitmap src) {
        // create new bitmap, which will be painted and becomes result image
        Bitmap bmOut = Bitmap.createBitmap(src.getWidth(), src.getHeight(), Bitmap.Config.ARGB_8888);
        // setup canvas for painting
        Canvas canvas = new Canvas(bmOut);
        // setup default color
        canvas.drawColor(0, PorterDuff.Mode.CLEAR);

        // create a blur paint for capturing alpha
        Paint ptBlur = new Paint();
        ptBlur.setMaskFilter(new BlurMaskFilter(15, BlurMaskFilter.Blur.NORMAL));
        int[] offsetXY = new int[2];
        // capture alpha into a bitmap
        Bitmap bmAlpha = src.extractAlpha(ptBlur, offsetXY);
        // create a color paint
        Paint ptAlphaColor = new Paint();
        ptAlphaColor.setColor(0xFFFFFFFF);
        // paint color for captured alpha region (bitmap)
        canvas.drawBitmap(bmAlpha, offsetXY[0], offsetXY[1], ptAlphaColor);
        // free memory
        bmAlpha.recycle();
        // paint the image source
        canvas.drawBitmap(src, 0, 0, null);
        // return out final image
        return bmOut;
    }

    //grayscale
    public static Bitmap doGreyscale(Bitmap src) {
        // constant factors
        final double GS_RED = 0.299;
        final double GS_GREEN = 0.587;
        final double GS_BLUE = 0.114;

        // create output bitmap
        Bitmap bmOut = Bitmap.createBitmap(src.getWidth(), src.getHeight(), src.getConfig());
        // pixel information
        int A, R, G, B;
        int pixel;

        // get image size
        int width = src.getWidth();
        int height = src.getHeight();

        // scan through every single pixel
        for(int x = 0; x < width; ++x) {
            for(int y = 0; y < height; ++y) {
                // get one pixel color
                pixel = src.getPixel(x, y);
                // retrieve color of all channels
                A = Color.alpha(pixel);
                R = Color.red(pixel);
                G = Color.green(pixel);
                B = Color.blue(pixel);
                // take conversion up to one single value
                R = G = B = (int)(GS_RED * R + GS_GREEN * G + GS_BLUE * B);
                // set new pixel color to output bitmap
                bmOut.setPixel(x, y, Color.argb(A, R, G, B));
            }
        }

        // return final image
        return bmOut;
    }

    //doGamma highlights
    public static Bitmap doGamma(Bitmap src, double red, double green, double blue) {
        // create output image
        Bitmap bmOut = Bitmap.createBitmap(src.getWidth(), src.getHeight(), src.getConfig());
        // get image size
        int width = src.getWidth();
        int height = src.getHeight();
        // color information
        int A, R, G, B;
        int pixel;
        // constant value curve
        final int    MAX_SIZE = 256;
        final double MAX_VALUE_DBL = 255.0;
        final int    MAX_VALUE_INT = 255;
        final double REVERSE = 1.0;

        // gamma arrays
        int[] gammaR = new int[MAX_SIZE];
        int[] gammaG = new int[MAX_SIZE];
        int[] gammaB = new int[MAX_SIZE];

        // setting values for every gamma channels
        for(int i = 0; i < MAX_SIZE; ++i) {
            gammaR[i] = (int)Math.min(MAX_VALUE_INT,
                    (int)((MAX_VALUE_DBL * Math.pow(i / MAX_VALUE_DBL, REVERSE / red)) + 0.5));
            gammaG[i] = (int)Math.min(MAX_VALUE_INT,
                    (int)((MAX_VALUE_DBL * Math.pow(i / MAX_VALUE_DBL, REVERSE / green)) + 0.5));
            gammaB[i] = (int)Math.min(MAX_VALUE_INT,
                    (int)((MAX_VALUE_DBL * Math.pow(i / MAX_VALUE_DBL, REVERSE / blue)) + 0.5));
        }

        // apply gamma table
        for(int x = 0; x < width; ++x) {
            for(int y = 0; y < height; ++y) {
                // get pixel color
                pixel = src.getPixel(x, y);
                A = Color.alpha(pixel);
                // look up gamma
                R = gammaR[Color.red(pixel)];
                G = gammaG[Color.green(pixel)];
                B = gammaB[Color.blue(pixel)];
                // set new color to output bitmap
                bmOut.setPixel(x, y, Color.argb(A, R, G, B));
            }
        }

        // return final image
        return bmOut;
    }

    //sepia
    public static Bitmap createSepiaToningEffect(Bitmap src, int depth, double red, double green, double blue) {
        // image size
        int width = src.getWidth();
        int height = src.getHeight();
        // create output bitmap
        Bitmap bmOut = Bitmap.createBitmap(width, height, src.getConfig());
        // constant grayscale
        final double GS_RED = 0.3;
        final double GS_GREEN = 0.59;
        final double GS_BLUE = 0.11;
        // color information
        int A, R, G, B;
        int pixel;

        // scan through all pixels
        for(int x = 0; x < width; ++x) {
            for(int y = 0; y < height; ++y) {
                // get pixel color
                pixel = src.getPixel(x, y);
                // get color on each channel
                A = Color.alpha(pixel);
                R = Color.red(pixel);
                G = Color.green(pixel);
                B = Color.blue(pixel);
                // apply grayscale sample
                B = G = R = (int)(GS_RED * R + GS_GREEN * G + GS_BLUE * B);

                // apply intensity level for sepid-toning on each channel
                R += (depth * red);
                if(R > 255) { R = 255; }

                G += (depth * green);
                if(G > 255) { G = 255; }

                B += (depth * blue);
                if(B > 255) { B = 255; }

                // set new pixel color to output image
                bmOut.setPixel(x, y, Color.argb(A, R, G, B));
            }
        }

        // return final image
        return bmOut;
    }


    public static final int FLIP_VERTICAL = 1;
    public static final int FLIP_HORIZONTAL = 2;

    //flip effect
    public static Bitmap flip(Bitmap src, int type) {
        // create new matrix for transformation
        Matrix matrix = new Matrix();
        // if vertical
        if(type == FLIP_VERTICAL) {
            // y = y * -1
            matrix.preScale(1.0f, -1.0f);
        }
        // if horizonal
        else if(type == FLIP_HORIZONTAL) {
            // x = x * -1
            matrix.preScale(-1.0f, 1.0f);
            // unknown type
        } else {
            return null;
        }

        // return transformed image
        return Bitmap.createBitmap(src, 0, 0, src.getWidth(), src.getHeight(), matrix, true);
    }

    //apply changes
    class applyChanges implements  Button.OnClickListener{
        @Override
        public void onClick(View view) {

            //mutable bitmapping, so we can change colors.  placed here to only apply selected effects.
            Bitmap mutableBitmap = bitmap.copy(Bitmap.Config.ARGB_8888, true);
            //Canvas canvas = new Canvas(mutableBitmap);

            //TODO: implement color manipulations
            if ( highlightSwitch.isChecked() ){
                //remove red.  actually makes everything red.
                //mutableBitmap.eraseColor(Color.RED);
                //savedPic =(ImageView)  findViewById(R.id.imageView2);
                //savedPic.setImageBitmap(mutableBitmap);

                //highlight the image
                Bitmap outputMap = doHighlightImage(mutableBitmap);
                savedPic =(ImageView)  findViewById(R.id.imageView2);
                savedPic.setImageBitmap(outputMap);
            }
            if ( grayscaleSwitch.isChecked() ){
                //grayscale the image
                Bitmap outputMap = doGreyscale(mutableBitmap);
                savedPic =(ImageView)  findViewById(R.id.imageView2);
                savedPic.setImageBitmap(outputMap);
            }
            if ( doGammaSwitch.isChecked() ){
                //gamma the image
                Bitmap outputMap = doGamma(mutableBitmap, 1.8, 1.8, 1.8);
                savedPic =(ImageView)  findViewById(R.id.imageView2);
                savedPic.setImageBitmap(outputMap);
            }
            if ( sepiaSwitch.isChecked() ){
                //sepia the image
                Bitmap outputMap = createSepiaToningEffect(mutableBitmap, 4, 4, 4, 4);
                savedPic =(ImageView)  findViewById(R.id.imageView2);
                savedPic.setImageBitmap(outputMap);
            }
            if ( flipVSwitch.isChecked() ){
                //sepia the image
                Bitmap outputMap = flip(mutableBitmap, 1);
                savedPic =(ImageView)  findViewById(R.id.imageView2);
                savedPic.setImageBitmap(outputMap);
            }
            if ( flipHSwitch.isChecked() ){
                //sepia the image
                Bitmap outputMap = flip(mutableBitmap, 2);
                savedPic =(ImageView)  findViewById(R.id.imageView2);
                savedPic.setImageBitmap(outputMap);
            }

        }
    }

    //change activity
    class changeActivity implements  Button.OnClickListener{
        @Override
        public void onClick(View view) {
            startActivity(new Intent(getApplicationContext(),MainActivity.class));
        }
    }

}
