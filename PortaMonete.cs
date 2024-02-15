using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PortaMonete : MonoBehaviour
{
    private int monete = 0;
    public TextMeshProUGUI contaMoneteText;


    //quando il giocatore entra in collisione con la moneta la raccoglie
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.name.Contains("Coin")){
            monete++;
            collision.gameObject.SetActive(false);
            AggiornaConteggio();
        }
    }


    //calcolo spesa sostenuta per upgrades sulle skills
    public void Spesa(int coins){
        monete -= coins;
        if(monete<=0){
            monete = 0;
        }
        
        AggiornaConteggio();
    }

    public int GetCoins(){
        return monete;
    }

    void AggiornaConteggio(){
        contaMoneteText.SetText("Coins: "+monete);
    }
}
