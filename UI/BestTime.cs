using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class BestTime : MonoBehaviour
{
    public TMP_Text bestTime;
    public Timer time;

    void Start(){
        time.DisplayTime(LoadScore(), bestTime);
    }

    void Update(){

        if(PlayerPrefs.GetInt("BestTime", 0)<time.GetTimeRemaining()){
            SaveBestTime((int)time.GetTimeRemaining());
            time.DisplayTime(time.GetTimeRemaining(), bestTime);
        }
    }

    //salvo il tempo migliore
    public void SaveBestTime(int best)
    {
        PlayerPrefs.SetInt("BestTime", best);
        PlayerPrefs.Save();
    }

    //carico il punteggio migliore
    public int LoadScore()
    {
        return PlayerPrefs.GetInt("BestTime", 0);
    }

    public void DeleteScore()
    {
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.Save();
    }
}
