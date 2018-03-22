package org.chrissite.textdetect;

import android.Manifest;
import android.content.pm.PackageManager;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.v4.app.ActivityCompat;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.util.SparseArray;
import android.view.SurfaceHolder;
import android.view.SurfaceView;
import android.view.View;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import com.google.android.gms.vision.CameraSource;
import com.google.android.gms.vision.Detector;
import com.google.android.gms.vision.text.TextBlock;
import com.google.android.gms.vision.text.TextRecognizer;
import java.io.IOException;


public class MainActivity extends AppCompatActivity {
    EditText input_to_search;
    Button button_search;

    SurfaceView cameraView;
    TextView textView;
    CameraSource cameraSource;
    final int RequestCameraPermissionID = 1001;
    String to_search = "@#qp";

    @Override
    public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults) {
        if (requestCode == RequestCameraPermissionID) {
                if (grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                    if (ActivityCompat.checkSelfPermission(this, Manifest.permission.CAMERA) != PackageManager.PERMISSION_GRANTED) {
                        return;
                    }
                    try {
                        cameraSource.start(cameraView.getHolder());
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                }
        }
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        cameraView = findViewById(R.id.surface_view);
        textView = findViewById(R.id.text_view);
        input_to_search = findViewById(R.id.to_search);
        button_search = findViewById(R.id.btn_search);

        button_search.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v) {

                //clear focus from text box and hide the keyboard
                input_to_search.clearFocus();
                InputMethodManager manager = (InputMethodManager) getSystemService(MainActivity.INPUT_METHOD_SERVICE);
                assert manager != null;
                manager.hideSoftInputFromWindow(getWindow().getDecorView().getWindowToken(), 0);

                to_search = String.valueOf(input_to_search.getText()).toLowerCase();
            }
        });

        TextRecognizer textRecognizer = new TextRecognizer.Builder(getApplicationContext()).build();
        if (!textRecognizer.isOperational()) {
            Log.w("MainActivity", "textRecognizer.isOperational() returned false");
        } else {
            cameraSource = new CameraSource.Builder(getApplicationContext(), textRecognizer)
                    .setAutoFocusEnabled(true)
                    .setFacing(CameraSource.CAMERA_FACING_BACK)
                    .setRequestedFps(2.0f)
                    .setRequestedPreviewSize(1280, 1024)
                    .build();
            cameraView.getHolder().addCallback(new SurfaceHolder.Callback() {
                @Override
                public void surfaceCreated(SurfaceHolder holder) {
                    try {
                        if (ActivityCompat.checkSelfPermission(getApplicationContext(), Manifest.permission.CAMERA) != PackageManager.PERMISSION_GRANTED)
                        {
                            ActivityCompat.requestPermissions(MainActivity.this,
                                    new String[]{Manifest.permission.CAMERA},
                                    RequestCameraPermissionID);
                            return;
                        }
                        cameraSource.start(cameraView.getHolder());
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                }

                @Override
                public void surfaceChanged(SurfaceHolder holder, int format, int width, int height) {

                }

                @Override
                public void surfaceDestroyed(SurfaceHolder holder) {
                    cameraSource.stop();
                }
            });

            textRecognizer.setProcessor(new Detector.Processor<TextBlock>() {
                @Override
                public void release() {

                }

                @Override
                public void receiveDetections(Detector.Detections<TextBlock> detections) {
                    final SparseArray<TextBlock> items = detections.getDetectedItems();
                    if(items.size() != 0)
                    {
                        textView.post(new Runnable() {
                            @Override
                            public void run() {
                                for (int i = 0; i < items.size(); i++)
                                {
                                    TextBlock item = items.valueAt(i);
                                    if (item.getValue().toLowerCase().contains(to_search))
                                    {
                                        String temp = item.getValue();
                                        int index = temp.toLowerCase().indexOf(to_search);
                                        int left_side = 0;
                                        int right_side = temp.length();

                                        if(index >= 36)
                                        {
                                            left_side = index - 36;
                                        }
                                        if(temp.length() - (index + to_search.length()) >= 36)
                                        {
                                            right_side = index + to_search.length() + 36;
                                        }
                                        String temp2 = temp.substring(left_side, right_side);
                                        textView.setText(temp2);
                                    }
                                }
                            }
                        });
                    }
                }
            });
        }
    }
}
