using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void LoadGame(){
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }
}
