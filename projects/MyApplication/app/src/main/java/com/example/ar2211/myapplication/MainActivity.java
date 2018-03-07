package com.example.ar2211.myapplication;

import android.content.Intent;
import android.graphics.Bitmap;
import android.provider.MediaStore;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.net.Uri;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;
import android.graphics.Color;

import com.google.api.client.extensions.android.http.AndroidHttp;
import com.google.api.client.http.HttpTransport;
import com.google.api.client.json.JsonFactory;
import com.google.api.client.json.gson.GsonFactory;
import com.google.api.services.vision.v1.Vision;
import com.google.api.services.vision.v1.VisionRequestInitializer;
import com.google.api.services.vision.v1.model.AnnotateImageRequest;
import com.google.api.services.vision.v1.model.BatchAnnotateImagesRequest;
import com.google.api.services.vision.v1.model.BatchAnnotateImagesResponse;
import com.google.api.services.vision.v1.model.EntityAnnotation;
import com.google.api.services.vision.v1.model.Feature;
import com.google.api.services.vision.v1.model.Image;

import java.io.IOException;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.Map;


public class MainActivity extends AppCompatActivity
{
    ImageView targetImage;
    private static final String CLOUD_VISION_API_KEY = "AIzaSyCwlb3OD8UZULz8BfocrWjMaEq94zyeKOs";
    private static final String TAG = "MainActivity.java";

    public Map<String, Float> annotateImage(byte[] imageBytes) throws IOException {
        // Construct the Vision API instance
        HttpTransport httpTransport = AndroidHttp.newCompatibleTransport();
        JsonFactory jsonFactory = GsonFactory.getDefaultInstance();
        VisionRequestInitializer initializer = new VisionRequestInitializer(CLOUD_VISION_API_KEY);
        Vision vision = new Vision.Builder(httpTransport, jsonFactory, null)
                .setVisionRequestInitializer(initializer)
                .build();

        // Create the image request
        AnnotateImageRequest imageRequest = new AnnotateImageRequest();
        com.google.api.services.vision.v1.model.Image image = new com.google.api.services.vision.v1.model.Image();
        image.encodeContent(imageBytes);
        imageRequest.setImage(image);

        // Add the features we want
        Feature labelDetection = new Feature();
        labelDetection.setType("LABEL_DETECTION");
        labelDetection.setMaxResults(10);
        imageRequest.setFeatures(Collections.singletonList(labelDetection));

        // Batch and execute the request
        BatchAnnotateImagesRequest requestBatch = new BatchAnnotateImagesRequest();
        requestBatch.setRequests(Collections.singletonList(imageRequest));
        BatchAnnotateImagesResponse response = vision.images()
                .annotate(requestBatch)
                .setDisableGZipContent(true)
                .execute();

        return convertResponseToMap(response);
    }

    private Map<String, Float> convertResponseToMap(BatchAnnotateImagesResponse response) {
        Map<String, Float> annotations = new HashMap<>();

        // Convert response into a readable collection of annotations
        List<EntityAnnotation> labels = response.getResponses().get(0).getLabelAnnotations();
        if (labels != null) {
            for (EntityAnnotation label : labels) {
                annotations.put(label.getDescription(), label.getScore());
            }
        }

        return annotations;
    }

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Button camera = (Button) findViewById(R.id.cameraButton);
        targetImage = (ImageView) findViewById(R.id.targetimage);

        camera.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
                startActivityForResult(intent, 0);
            }
        });
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        Bitmap bitmap = (Bitmap) data.getExtras().get("data");
        targetImage.setImageBitmap(bitmap);
    }



    private void onPictureTaken(final byte[] imageBytes) {
        if (imageBytes != null) {
            try {
                // Process the image using Cloud Vision
                Map<String, Float> annotations = annotateImage(imageBytes);
                Log.d(TAG, "cloud vision annotations:" + annotations);
            } catch (IOException e) {
                Log.e(TAG, "Cloud Vison API error: ", e);
            }
        }
    }



}

