package hsu.imageanalysis;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

//NOTE: You will need to set an API key in ViewActivity.java

public class MainActivity extends AppCompatActivity
{
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Button button_take_picture = (Button) findViewById(R.id.btn_take_picture);

        button_take_picture.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v) {
                to_second_activity();
            }
        });
    }

    private void to_second_activity()
    {
        Intent intent = new Intent(this, ViewActivity.class);
        startActivity(intent);
    }
}
