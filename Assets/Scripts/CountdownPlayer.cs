using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownPlayer : MonoBehaviour
{
    public float time, timeStart, timeCurrent;
    public TextMeshProUGUI timeText;
    public bool shouldTimerBeOn, finished;
    public ChangePlayer cp;
    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldTimerBeOn)
        {
            time += Time.deltaTime;
            DisplayTime(time);
        }

        if(timeCurrent <= 0 && !finished)
        {
            shouldTimerBeOn = false;
            TimerEnd();
            Debug.Log("TimerEneded");
        }

    }

    public void TimerEnd()
    {
        cp.ChangeToSmall();
        finished = true;
        timeText.text = 0.ToString();
    }

    public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay -= 1;

        /*
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);

        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        float milliSeconds = (timeToDisplay % 1) * 1000;
        */
        // timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        // timeText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliSeconds);
        timeText.text = (timeStart - timeToDisplay).ToString("f0");
        timeCurrent = timeStart - timeToDisplay;
    }
    // make the timer start at a current num

    public void ResetTimer()
    {
        time = 0;
        timeCurrent = 0;
        timeText.text = (timeStart).ToString();
        shouldTimerBeOn = true;
        finished = false;
    }


}
