using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
   public float damage;
   Rigidbody2D rb;
   public DetectionZone detectionZone;
   public float moveSpeed;


   void Start(){
      rb = GetComponent<Rigidbody2D>();
   }

   
   void FixedUpdate(){
      if(detectionZone.detectedObjects.Count > 0){
         
         // Calcolo la direzione di movimento
         Vector2 direction = (detectionZone.detectedObjects[0].transform.position - transform.position).normalized;

         // Mi muovo verso l'obbiettivo
         rb.AddForce(direction * moveSpeed * Time.deltaTime);
      }
   }

   // Lo Slime infligge un danno se entra in collisione
   void OnCollisionEnter2D(Collision2D col){
      IDamageable damageable = col.collider.GetComponent<IDamageable>();

      if(damageable != null && col.collider.gameObject.tag == "Player"){
         damageable.OnHit(damage);
      }
   }
}
