using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillStatusBar : MonoBehaviour
{
    public PlayerHealth playerHealth;
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
            // Imposto la posizione della barra della salute rispetto alla posizione del giocatore
            transform.position = playerTransform.position + new Vector3(0f, -0.4f, 0f);
        }



        float fillValue = playerHealth.Health;
        slider.maxValue = playerHealth.MaxHealth();

        if(slider.value <= slider.minValue){
            fillImage.enabled = false;
        }

        if(slider.value > slider.minValue && !fillImage.enabled){
            fillImage.enabled = true;
        }

       
        fillImage.color = Color.red;
        slider.value = fillValue;
    
    }
}
