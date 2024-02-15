using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining;
    private bool timeIsRunning = true;
    public TMP_Text timeText;

    
    void Start()
    {
        timeIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeIsRunning){
            if(timeRemaining >= 0){
                timeRemaining += Time.deltaTime;
                DisplayTime(timeRemaining);
            }
        }
    }
    

    void DisplayTime(float timeToDisplay){
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay/60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        this.timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void DisplayTime(float timeToDisplay, TMP_Text timeText){
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay/60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
    

    public float GetTimeRemaining(){
        return timeRemaining;
    }
}
