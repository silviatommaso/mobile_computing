using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorial;
    
    void OnEnable(){
        tutorial.SetActive(true);
        Invoke("Disable", 4f);
    }

    void Disable(){
        tutorial.SetActive(false);
    }


}
