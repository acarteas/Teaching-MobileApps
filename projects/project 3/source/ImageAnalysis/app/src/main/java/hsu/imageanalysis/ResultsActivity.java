package hsu.imageanalysis;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import com.google.api.services.vision.v1.model.EntityAnnotation;

import java.text.DecimalFormat;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import static java.lang.Math.round;

public class ResultsActivity extends AppCompatActivity {

    EditText text_input;
    TextView text_response;
    HashMap<String, Float> response_map;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_results);

        Intent intent = getIntent();
        response_map = (HashMap<String, Float>)intent.getSerializableExtra("map");

        Button button_submit = (Button) findViewById(R.id.btn_submit_button);
        Button button_start_over = (Button) findViewById(R.id.btn_start_over_2);
        Button button_all = (Button) findViewById(R.id.btn_all);
        text_input = (EditText) findViewById(R.id.input_label);
        text_response = (TextView) findViewById(R.id.text_response);

        button_submit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                submit();
            }
        });

        button_start_over.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                start_over();
            }
        });

        button_all.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                text_response.setText("");
                for (String key : response_map.keySet()) {
                    text_response.setText(text_response.getText() + "The chances of it being " + key + " were " + String.format("%.0f%%", response_map.get(key) * 100) + "\n");
                }
            }
        });
    }

    private void start_over() {
        Intent intent = new Intent(this, MainActivity.class);
        startActivity(intent);
    }

    private void submit() {
        //List<EntityAnnotation> labels;// = (List<EntityAnnotation>) getIntent().getSerializableExtra("labels");


        //List<EntityAnnotation> labels = (List<EntityAnnotation>) args.getSerializable("LIST");
        //Map<String, Float> response_map = (Map<String, Float>) args.getSerializable("MAP");

        int found_flag = 0;
        text_response.setText("");
        for (String key : response_map.keySet()) {
            if (key.contains(text_input.getText().toString().toLowerCase()))
            {
                text_response.setText(text_response.getText() + "The chances of it being " + key + " were " + String.format("%.0f%%", response_map.get(key) * 100) + "\n");
                found_flag = 1;
            }
        }
        if (found_flag == 0)
        {
            text_response.setText(text_input.getText() + " was not in our list of guesses");
        }
    }

}
