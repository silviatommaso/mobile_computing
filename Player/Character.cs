using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
   [SerializeField] public float currentHealth, maxHealth, currentExperience, maxExperience, currentLevel;
   public PlayerHealth playerHealth;


   public void FixedUpdate(){

    currentHealth = playerHealth.Health;
    maxHealth = playerHealth.MaxHealth();

   }


   private void OnEnable(){
    ExperienceManager.Instance.OnExperienceChange += HandleExperienceChange;
   }

   private void OnDisable(){
    ExperienceManager.Instance.OnExperienceChange -= HandleExperienceChange;
   }



   private void HandleExperienceChange(int newExperience){
    currentExperience += newExperience;

    if(currentExperience >= maxExperience){
        LevelUp();
    }
   }


   private void LevelUp(){

    playerHealth.Heal(10);

    currentLevel++;

    currentExperience = 0;
    maxExperience += 100;

   }

   public float CurrentExperience(){
    return currentExperience;
   }

   public float MaxExperience(){
    return maxExperience;
   }

   public float Level(){
    return currentLevel;
   }
}
