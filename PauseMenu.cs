using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;

    public void Pause(){
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue(){
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit(){
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
