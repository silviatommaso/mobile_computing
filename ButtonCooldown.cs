using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCooldown : MonoBehaviour
{
    public Button button; 
    public static float cooldownDuration; 

    
    void Start()
    {
        // Mi assicuro che il riferimento al bottone non sia nullo
        if (button == null)
        {
            Debug.LogError("Button reference not set!");
            return;
        }

        // Mi assicuro che il bottone non sia già disattivato
        button.interactable = true;
    }


    //skill 1
    public void StartButtonCooldownAbility1()
    {
        // Disattivo l'interazione con il bottone
        button.interactable = false;

        StartCoroutine(ButtonCooldownCoroutine(0));
    }


    //skill 2
    public void StartButtonCooldownAbility2()
    {
        // Disattivo l'interazione con il bottone
        button.interactable = false;

        StartCoroutine(ButtonCooldownCoroutine(5));
    }


    //skill 3
    public void StartButtonCooldownAbility3()
    {
        // Disattivo l'interazione con il bottone
        button.interactable = false;

        StartCoroutine(ButtonCooldownCoroutine(5));
    }



    // Coroutine per gestire il cooldown del bottone
    private IEnumerator ButtonCooldownCoroutine(float addedWaitTime)
    {
        yield return new WaitForSeconds(cooldownDuration+addedWaitTime);

        // Riattivo l'interazione con il bottone
        button.interactable = true;
    }
}
