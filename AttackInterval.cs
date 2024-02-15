using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInterval : MonoBehaviour 
{
    public DragFingerOffset attackInterval;

    public void ModifyAttack(){
        attackInterval.ModifyAttackInterval();
        Invoke("BackToNormal", 5f);
    }

    public void BackToNormal(){
        attackInterval.ReturnToNormalAttack();
    }
}
