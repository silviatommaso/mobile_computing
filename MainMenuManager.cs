using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    public AudioClip mainMenu;


    void Start(){
        musicSource.clip = mainMenu;
        musicSource.Play();
    }

}
