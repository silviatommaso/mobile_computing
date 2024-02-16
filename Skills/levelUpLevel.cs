using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelUpLevel : MonoBehaviour
{

    public GameObject level1;
    public GameObject level2;
    public GameObject level3;

    public PortaMonete monete;

    public int price1;
    public int price2;
    public int price3;

    public SkillsUp skills;


    public void LevelUp(){
        if(level1.activeSelf){
            Level1();
        }else if(level2.activeSelf){
            Level2();
        }else if(level3.activeSelf){
            Level3();
        }
    }
    
    private void Level1(){
        Debug.Log("sono dentro");
        if(monete.GetCoins() >= price1){
            skills.LessWaitingTimeAbilityFirst();
            level1.SetActive(false);
            level2.SetActive(true);
            monete.Spesa(price1);
            
        }
    
    }

    private void Level2(){
      
        if(monete.GetCoins() >= price2){
            skills.LessWaitingTimeAbilitySecond();
            level2.SetActive(false);
            level3.SetActive(true);
            monete.Spesa(price2);
        }
    
    }

    private void Level3(){

        if(monete.GetCoins() >= price3){
            monete.Spesa(price3);
            skills.LessWaitingTimeAbilityThird();
        }
    } 

}
