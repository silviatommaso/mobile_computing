using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameObject noMusic;

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sounds;

    public AudioClip background;
    public AudioClip death;

    private bool enable;



    void Awake()
    {
        Invoke("PlayBackgroundMusic", 1f);
    }


    public void PlaySounds(AudioClip clip)
    {
        sounds.PlayOneShot(clip);
    }


    private void PlayBackgroundMusic()
    {
        enable = true;
        musicSource.clip = background;
        musicSource.Play();
    }

    // Metodo per fermare la riproduzione del background music
    public void StopBackgroundMusic()
    {
        musicSource.Stop();
    }
    

    public void enableMusic(){
        if(enable){
            enable = false;
            noMusic.SetActive(true);
            
            StopBackgroundMusic();
        }else{
            noMusic.SetActive(false);
            PlayBackgroundMusic();
        }
    }
}
