using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
   Animator animator;
   Rigidbody2D rb;
   AudioManager audioManager;

   public GameObject gameOverMenu;

   bool isAlive = true;
   public float maxHealth;
   


   public float Health{
      set{

         _health = value;

         if(_health <= 0){
            animator.SetBool("isAlive", false);

            Invoke("Die", 1f);
         }
      }

      get{
         return _health;
      }
   }



   public float _health = 10f;

   public float MaxHealth(){
    return maxHealth;
   }


   public void Awake(){
    rb = GetComponent<Rigidbody2D>();
    audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
   }

   public void Start(){
      animator = GetComponent<Animator>();
      animator.SetBool("isAlive", isAlive);
   }



    //Se il player viene colpito, la sua salute diminuisce
   public void OnHit(float damage){
      Health-=damage;
      Debug.Log("Colpito");
   }

   public void OnHit(float damage, Vector2 knockback){
      Health-=damage;
      
      rb.AddForce(knockback);
      Debug.Log("Force: " + knockback);
   }


    //In alcuni casi il player può curarsi
   public void Heal(float newHealth){
    Health+=newHealth;
    maxHealth+=newHealth;
   }



   public void Die(){

    gameObject.SetActive(false);

    //Attivo schermata GameOver
    Invoke("GameOver", 1f);

    Invoke("AudioDeath", 0f);

   }

   public void GameOver(){
    gameOverMenu.SetActive(true);
    Time.timeScale = 0;
   }

   private void AudioDeath(){
      audioManager.StopBackgroundMusic();
      audioManager.PlaySounds(audioManager.death);
   }
}
