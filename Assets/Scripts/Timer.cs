using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private const float GAME_DURATION = 120f;

    // Start is called before the first frame update
    void Start()
    {

    }

    public float time = GAME_DURATION;
    public Text timeText;
    public string scene;

    void Update()
    {

        RemoveTime(Time.deltaTime);

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        timeText.text = string.Format("{0:0}:{1:00}", minutes, seconds);

        // Turns red when 5 or less seconds are left 
        if (minutes == 0 && seconds <= 5)
        {
            timeText.color = new Color(1, 0, 0, 1);
        }
    }

    public void RemoveTime(float seconds)
    {
        time = Mathf.Max(0, time - seconds);
    }
}
