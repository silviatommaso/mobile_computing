using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    
    public Slider slider;

    public void UpdateHealthBar(float currentValue){
        slider.value = currentValue;
    }

}
