package hsu.imageanalysis;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Matrix;
import android.support.media.ExifInterface;
import android.net.Uri;
import android.os.AsyncTask;
import android.os.Environment;
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
import java.util.ArrayList;
import java.util.HashMap;
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
    String api_key = "AIzaSyBY0l127k8XkHsAK8AbIn_eOu6fnVDqjqo";
    ImageView view_image;
    TextView text_output;
    File image_file;
    Button button_yes;
    Button button_no;
    Button button_new_photo;
    private static final int REQUEST_CODE_CAMERA = 1;
    String message = "";
    HashMap<String, Float> response_map;
    Intent to_send;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_view);

        view_image = (ImageView) findViewById(R.id.imageView);
        text_output = (TextView) findViewById(R.id.txt_output);
        button_yes = (Button) findViewById(R.id.btn_yes);
        button_no = (Button) findViewById(R.id.btn_no);
        button_new_photo = (Button) findViewById(R.id.btn_new_photo);

        button_yes.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {
                correct();
            }
        });

        button_no.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {
                wrong();
            }
        });

        button_new_photo.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {
                start_over();
            }
        });
        start_camera_intent();
    }

    private void correct()
    {
        Toast.makeText(this, "Success!", Toast.LENGTH_SHORT).show();
    }
    
    private void wrong()
    {
        startActivity(to_send);
    }
    
    private void start_over()
    {
        Intent intent = new Intent(this, MainActivity.class);
        startActivity(intent);
    }

    private void create_image_file() throws IOException
    {
        String file_name = "image" + System.currentTimeMillis() + "_";
        File storage_directory = getExternalFilesDir(Environment.DIRECTORY_PICTURES);
        image_file = File.createTempFile(file_name, ".jpg", storage_directory);
    }

    public void start_camera_intent()
    {
        Intent intent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);

        // check if camera intent is good
        if (intent.resolveActivity(getPackageManager()) != null)
        {
            try
            {
                create_image_file();
            }
            catch (IOException e)
            {
                e.printStackTrace();
            }

            if (image_file != null)
            {
                Uri imageUri = FileProvider.getUriForFile(ViewActivity.this,BuildConfig.APPLICATION_ID + ".fileprovider", image_file);
                intent.putExtra(MediaStore.EXTRA_OUTPUT, imageUri);
                intent.addFlags(Intent.FLAG_GRANT_WRITE_URI_PERMISSION);
            }

            startActivityForResult(intent, REQUEST_CODE_CAMERA);
        }
        else
        {
            // no camera
        }
    }

    //Lots of the code below was borrowed from or modified from the official Google Cloud Vision Android Sample
    @SuppressLint("StaticFieldLeak")
    private void callCloudVision(final Bitmap bitmap) throws IOException
    {

        // Do the real work in an async task, because we need to use the network anyway
        new AsyncTask<Object, Void, String>()
        {
            @Override
            protected String doInBackground(Object... params)
            {
                HttpTransport httpTransport = AndroidHttp.newCompatibleTransport();
                JsonFactory jsonFactory = GsonFactory.getDefaultInstance();

                VisionRequestInitializer requestInitializer =
                        new VisionRequestInitializer(api_key);

                Vision.Builder builder = new Vision.Builder(httpTransport, jsonFactory, null);
                builder.setVisionRequestInitializer(requestInitializer);

                Vision vision = builder.build();

                BatchAnnotateImagesRequest batchAnnotateImagesRequest =
                        new BatchAnnotateImagesRequest();
                batchAnnotateImagesRequest.setRequests(new ArrayList<AnnotateImageRequest>()
                {
                    {
                    AnnotateImageRequest annotateImageRequest = new AnnotateImageRequest();

                    // Add the image
                    Image base64EncodedImage = new Image();

                    // Convert the bitmap to a JPEG
                    // Just in case it's a format that Android understands but Cloud Vision does not
                    ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
                    bitmap.compress(Bitmap.CompressFormat.JPEG, 90, byteArrayOutputStream);
                    byte[] imageBytes = byteArrayOutputStream.toByteArray();

                    // Base64 encode the JPEG
                    base64EncodedImage.encodeContent(imageBytes);
                    annotateImageRequest.setImage(base64EncodedImage);

                    // add the features we want
                    annotateImageRequest.setFeatures(new ArrayList<Feature>()
                    {
                        {
                        Feature labelDetection = new Feature();
                        labelDetection.setType("LABEL_DETECTION");
                            labelDetection.setMaxResults(10);
                            add(labelDetection);
                        }
                    }
                    );

                    // Add the list of one thing to the request
                    add(annotateImageRequest);
                    }
                }
                );

                Vision.Images.Annotate annotateRequest = null;
                try
                {
                    annotateRequest = vision.images().annotate(batchAnnotateImagesRequest);
                }
                catch (IOException e)
                {
                    e.printStackTrace();
                }

                assert annotateRequest != null;
                annotateRequest.setDisableGZipContent(true);
                BatchAnnotateImagesResponse response = null;
                try
                {
                    response = annotateRequest.execute();
                }
                catch (IOException e)
                {
                    e.printStackTrace();
                }

                float highest_score = 0;
                String highest_label = "nothing";
                response_map = convertResponseToMap(response);

                for (String key : response_map.keySet())
                {
                    if (response_map.get(key) > highest_score)
                    {
                        highest_score = response_map.get(key);
                        highest_label = key;
                    }
                }
                message = "Is this a picture of: \n" + highest_label;
                return message;
            }
            protected void onPostExecute(String messages)
            {
                to_send = new Intent(ViewActivity.this, ResultsActivity.class);
                to_send.putExtra("map", response_map);
                text_output.setText(message);
                button_yes.setVisibility(View.VISIBLE);
                button_no.setVisibility(View.VISIBLE);
            }
        }
                .execute();
    }

    private HashMap<String, Float> convertResponseToMap(BatchAnnotateImagesResponse response)
    {
        HashMap<String, Float> annotations = new HashMap<>();

        // Convert response into a readable collection of annotations
        List<EntityAnnotation> labels = response.getResponses().get(0).getLabelAnnotations();
        if (labels != null)
        {
            for (EntityAnnotation label : labels)
            {
                annotations.put(label.getDescription(), label.getScore());
            }
        }
        return annotations;
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data)
    {
        if (resultCode == Activity.RESULT_OK)
        {
            if (requestCode == REQUEST_CODE_CAMERA)
            {

                // image_file now holds the photo. create bitmap from it
                Bitmap bitmap = BitmapFactory.decodeFile(image_file.getAbsolutePath());

                //get exif information to write file in correct orientation
                ExifInterface exif = null;
                try
                {
                    exif = new ExifInterface(image_file.getPath());
                }
                catch (IOException e)
                {
                    e.printStackTrace();
                }

                assert exif != null;
                int rotation = exif.getAttributeInt(ExifInterface.TAG_ORIENTATION, ExifInterface.ORIENTATION_NORMAL);
                int rotation_degrees = 0;
                if (rotation == ExifInterface.ORIENTATION_ROTATE_90)
                {
                    rotation_degrees = 90;
                }
                else if (rotation == ExifInterface.ORIENTATION_ROTATE_180)
                {
                    rotation_degrees = 180;
                }
                else if (rotation == ExifInterface.ORIENTATION_ROTATE_270)
                {
                    rotation_degrees = 270;
                }

                Matrix matrix = new Matrix();
                if (rotation != 0f) {matrix.preRotate(rotation_degrees);}
                Bitmap adjusted_bitmap = Bitmap.createBitmap(bitmap, 0, 0, bitmap.getWidth(), bitmap.getHeight(), matrix, true);

                view_image.setImageBitmap(adjusted_bitmap);
                try
                {
                    callCloudVision(adjusted_bitmap);
                }
                catch (IOException e)
                {
                    e.printStackTrace();
                }
            }
        }
    }
}