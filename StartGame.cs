using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

   public void PlayGame(){
    SceneManager.LoadScene("SampleScene");
    Time.timeScale = 1;
   }

   public void Home(){
      SceneManager.LoadScene("MainMenu");
      Time.timeScale = 1;
   }
}
