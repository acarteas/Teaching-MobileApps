package hsu.imageanalysis;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import com.google.api.services.vision.v1.model.EntityAnnotation;

import java.util.List;

public class ResultsActivity extends AppCompatActivity {

    EditText text_input;
    TextView text_response;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_results);

        Button button_submit = (Button) findViewById(R.id.btn_submit_button);
        Button button_start_over = (Button) findViewById(R.id.btn_start_over_2);
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
    }

    private void start_over() {
        Intent intent = new Intent(this, MainActivity.class);
        startActivity(intent);
    }

    private void submit() {
        //List<EntityAnnotation> labels;// = (List<EntityAnnotation>) getIntent().getSerializableExtra("labels");

        Intent intent = getIntent();
        Bundle args = intent.getBundleExtra("BUNDLE");
        List<EntityAnnotation> labels = (List<EntityAnnotation>) args.getSerializable("LIST");

        int found_flag = 0;
        if (labels != null) {
            for (EntityAnnotation label : labels) {
                if (label.getDescription().contains((text_input.getText().toString().toLowerCase()))) /// not working
                {
                    text_response.setText("There was a " + label.getScore() + "% chance it was a " + label.getDescription() + "\n");
                    found_flag = 1;
                }
            }
        } else {
            text_response.setText("nothing");
        }
        if (found_flag == 0)
        {
            text_response.setText(text_input.getText() + " was not in our list of guesses");
        }
    }

}
