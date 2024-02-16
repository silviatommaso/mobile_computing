using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
   public float damage;
   Animator animator; 


   void Start()
   {
      animator = GetComponent<Animator>();
   }

   // Il proiettile infligge un danno se un nemico collide con esso
   void OnCollisionEnter2D(Collision2D col){
      IDamageable damageable = col.collider.GetComponent<IDamageable>();

      if(damageable != null && col.collider.gameObject.tag == "enemy"){
         damageable.OnHit(damage);

        animator.SetTrigger("explosed");
        Invoke("Die", 0.5f);
      }
   }

   public void Die(){
      gameObject.SetActive(false);
   }
}
