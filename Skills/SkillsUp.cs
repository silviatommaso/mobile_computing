using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsUp : MonoBehaviour
{
    public ButtonCooldown button;


    public void LessWaitingTimeAbilityFirst(){
        button.SetCooldownDuration(button.GetCooldownDuration()-5);
    }

    public void LessWaitingTimeAbilitySecond(){
        button.SetCooldownDuration(button.GetCooldownDuration()-3);
    }

    public void LessWaitingTimeAbilityThird(){
        button.SetCooldownDuration(button.GetCooldownDuration()-3);
    }
}
