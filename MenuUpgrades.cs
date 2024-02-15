using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUpgrades : MonoBehaviour
{
    public GameObject menuUpgrades;

    public void Open(){
        menuUpgrades.SetActive(true);
        Time.timeScale = 0;
    }

    public void Close(){
        menuUpgrades.SetActive(false);
        Time.timeScale = 1;
    } 
}
