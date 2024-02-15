using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsUp : MonoBehaviour
{
    public void LessWaitingTimeAbilityFirst(){
        ButtonCooldown.cooldownDuration -= 5;
    }

    public void LessWaitingTimeAbilitySecond(){
        ButtonCooldown.cooldownDuration -= 3;
    }

    public void LessWaitingTimeAbilityThird(){
        ButtonCooldown.cooldownDuration -= 3;
    }
}
