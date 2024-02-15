using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    public Character character;
    public Transform playerTransform;
    private Slider slider;
    public Image fillImage;


    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {

        //Mi assicuro che la barra della salute si muova col giocatore
        if (playerTransform != null)
        {
            // Imposto la posizione della barra della salute sulla posizione del giocatore
            transform.position = playerTransform.position + new Vector3(0f, -0.5f, 0f);
        }



        float fillValue = character.currentExperience;
        slider.maxValue = character.MaxExperience();

        if(slider.value <= slider.minValue){
            fillImage.enabled = false;
        }

        if(slider.value > slider.minValue && !fillImage.enabled){
            fillImage.enabled = true;
        }

        fillImage.color = Color.green;
        slider.value = fillValue;
    
    }
    
}
