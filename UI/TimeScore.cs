using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeScore : MonoBehaviour
{
    public Timer time;
    public TMP_Text timeText;

    
    void Update(){
        time.DisplayTime(time.GetTimeRemaining(), timeText);
    }
}
