package hsu.imageanalysis;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.AsyncTask;
import android.os.Environment;
import android.os.Parcelable;
import android.provider.MediaStore;
import android.support.v4.content.FileProvider;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;
import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.IOException;
import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;
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


public class ViewActivity extends AppCompatActivity
{
    ImageView view_image;
    TextView text_output;
    File image_file;
    Button button_yes;
    Button button_no;
    Button button_new_photo;
    private static final int REQUEST_CODE_CAMERA = 1;
    String message = "";
    List<EntityAnnotation> labels;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_view);
        view_image = (ImageView) findViewById(R.id.imageView);
        text_output = (TextView) findViewById(R.id.txt_output);
        button_yes = (Button) findViewById(R.id.btn_yes);
        button_no = (Button) findViewById(R.id.btn_no);
        button_new_photo = (Button) findViewById(R.id.btn_new_photo);

        button_yes.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                correct();
            }
        });

        button_no.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                wrong();
            }
        });

        button_new_photo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                start_over();
            }
        });
        startCameraIntent();
    }

    private void correct() {
        Toast.makeText(this, "Success!", Toast.LENGTH_SHORT).show();
    }
    
    private void wrong() {
        //send over labels
        //Intent send_intent = new Intent();
        //send_intent.putExtra("labels", (Parcelable) labels);
        //startActivity(send_intent);

        Intent intent = new Intent(this, ResultsActivity.class);
        Bundle args = new Bundle();
        args.putSerializable("LIST",(Serializable)labels);
        intent.putExtra("BUNDLE",args);
        startActivity(intent);

        //go to ResultsActivity
        Intent go_intent = new Intent(this, ResultsActivity.class);
        startActivity(go_intent);
    }
    
    private void start_over() {
        Intent intent = new Intent(this, MainActivity.class);
        startActivity(intent);
    }

    private void create_image_file() throws IOException {
        String file_name = "image" + System.currentTimeMillis() + "_";
        File storage_directory = getExternalFilesDir(Environment.DIRECTORY_PICTURES);
        image_file = File.createTempFile(file_name, ".jpg", storage_directory);
    }

    public void startCameraIntent() {
        Intent intent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);

        // check if camera intent is good
        if (intent.resolveActivity(getPackageManager()) != null) {
            try {
                create_image_file();
            } catch (IOException e) {
            }

            if (image_file != null) {
                Uri imageUri = FileProvider.getUriForFile(
                        ViewActivity.this,
                        BuildConfig.APPLICATION_ID + ".fileprovider",
                        image_file);
                intent.putExtra(MediaStore.EXTRA_OUTPUT, imageUri);
                intent.addFlags(Intent.FLAG_GRANT_WRITE_URI_PERMISSION);
            }

            startActivityForResult(intent, REQUEST_CODE_CAMERA);
        } else {
            // no camera
        }
    }

    //Lots of the code below was borrowed from or modified from the official Google Cloud Vision Android Sample
    @SuppressLint("StaticFieldLeak")
    private void callCloudVision(final Bitmap bitmap) throws IOException {
        // Do the real work in an async task, because we need to use the network anyway
        new AsyncTask<Object, Void, String>() {
            @Override
            protected String doInBackground(Object... params) {
                HttpTransport httpTransport = AndroidHttp.newCompatibleTransport();
                JsonFactory jsonFactory = GsonFactory.getDefaultInstance();

                VisionRequestInitializer requestInitializer =
                        new VisionRequestInitializer("AIzaSyAHh9mpEizjniRnB2V9-pd4ZG93Gn1znCM");

                Vision.Builder builder = new Vision.Builder(httpTransport, jsonFactory, null);
                builder.setVisionRequestInitializer(requestInitializer);

                Vision vision = builder.build();

                BatchAnnotateImagesRequest batchAnnotateImagesRequest =
                        new BatchAnnotateImagesRequest();
                batchAnnotateImagesRequest.setRequests(new ArrayList<AnnotateImageRequest>() {{
                    AnnotateImageRequest annotateImageRequest = new AnnotateImageRequest();

                    // Add the image
                    Image base64EncodedImage = new Image();
                    // Convert the bitmap to a JPEG
                    // Just in case it's a format that Android understands but Cloud Vision
                    ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
                    bitmap.compress(Bitmap.CompressFormat.JPEG, 90, byteArrayOutputStream);
                    byte[] imageBytes = byteArrayOutputStream.toByteArray();

                    // Base64 encode the JPEG
                    base64EncodedImage.encodeContent(imageBytes);
                    annotateImageRequest.setImage(base64EncodedImage);

                    // add the features we want
                    annotateImageRequest.setFeatures(new ArrayList<Feature>() {{
                        Feature labelDetection = new Feature();
                        labelDetection.setType("LABEL_DETECTION");
                        labelDetection.setMaxResults(10);
                        add(labelDetection);
                    }});

                    // Add the list of one thing to the request
                    add(annotateImageRequest);
                }});

                Vision.Images.Annotate annotateRequest = null;
                try {
                    annotateRequest = vision.images().annotate(batchAnnotateImagesRequest);
                } catch (IOException e) {
                    e.printStackTrace();
                }

                //assert annotateRequest != null;
                annotateRequest.setDisableGZipContent(true);
                BatchAnnotateImagesResponse response = null;
                try {
                    response = annotateRequest.execute();
                } catch (IOException e) {
                    e.printStackTrace();
                }

                float highest_score = 0;
                String highest_label = "";
                labels = response.getResponses().get(0).getLabelAnnotations();
                if (labels != null) {
                    for (EntityAnnotation label : labels) {
                        if (label.getScore() > highest_score)
                        {
                            highest_score = label.getScore();
                            highest_label = label.getDescription();
                        }
                    }
                    message = "Is This A Picture Of: \n" + highest_label;
                } else {
                    message += "nothing";
                }

                //can't update the ui in an alternate thread
                runOnUiThread(new Runnable() {
                    @Override
                    public void run() {
                        text_output.setText(message);
                        button_yes.setVisibility(View.VISIBLE);
                        button_no.setVisibility(View.VISIBLE);

                    }
                });
                return message;
            }
        }
                .execute();
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {  // note that data will be null
        if (resultCode == Activity.RESULT_OK) {
            if (requestCode == REQUEST_CODE_CAMERA) {

                // image_file now holds the photo
                Bitmap bitmap = BitmapFactory.decodeFile(image_file.getAbsolutePath());
                view_image.setImageBitmap(bitmap);
                try {
                    callCloudVision(bitmap);
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    }
}