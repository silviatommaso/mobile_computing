using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableCharacter : MonoBehaviour, IDamageable
{
   Animator animator;
   bool isAlive = true;

   Rigidbody2D rb;
   public Freeze freeze;

   public GameObject moneta;
   int expAmount = 10;


   public float Health{
      set{

         if(value < _health){
            //imposta il trigger solo se la salute diminuisce
            animator.SetTrigger("Hit");
         }

         _health = value;

         if(_health <= 0){
            animator.SetBool("isAlive", false);

            //se il nemico muore genero una moneta al suo posto
            Invoke("MoneyGenerator", 0.5f);
            //disattivo il gameObject nemico
            Invoke("Die", 1);
         }
      }

      get{
         return _health;
      }
   }


   public float _health = 3;

   public void Start(){
      animator = GetComponent<Animator>();
      animator.SetBool("isAlive", isAlive);

      
      rb = GetComponent<Rigidbody2D>();
   }


   public void OnHit(float damage){
      Health-=damage;
      Debug.Log("Colpito");
   }

   public void OnHit(float damage, Vector2 knockback){
      Health-=damage;
      
      rb.AddForce(knockback);
      Debug.Log("Force: " + knockback);
   }


   //Generatore di monete alla morte del nemico
   public void MoneyGenerator(){

      moneta.SetActive(true);
      Instantiate(moneta, transform.position, Quaternion.identity);

   }

   public void Die(){

      //aggiungo esperienza al player ogni volta che un nemico muore
      ExperienceManager.Instance.AddExperience(expAmount);

      //rimuovo il nemico dalla lista dei nemici
      freeze.RemoveEnemy(gameObject.GetComponent<Rigidbody2D>());
      Destroy(gameObject);

   }
}