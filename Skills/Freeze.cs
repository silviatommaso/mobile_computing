using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    public GameObject freezingPanel;
    public GameObject enemySpawner;
    public float howLong;

    private List<Rigidbody2D> activeEnemies = new List<Rigidbody2D>();
    

    public void Show(){
        freezingPanel.SetActive(true);
        Invoke("Hide", howLong);
    }

    public void Hide(){
        freezingPanel.SetActive(false);
    }


    //Metodo per bloccare il movimento di tutti i nemici attivi
    public void FreezeAllEnemies()
    {
        foreach (Rigidbody2D enemyRB in activeEnemies)
        {
            if (enemyRB != null)
            {
                //blocco la posizione del nemico
                enemyRB.constraints = RigidbodyConstraints2D.FreezeAll;
                //blocco il generatore di nemici
                enemySpawner.SetActive(false);
                Invoke("UnfreezeAllEnemies", 5f);
            }
        }
    }

    //Metodo per sbloccare il movimento di tutti i nemici attivi
    public void UnfreezeAllEnemies()
    {
        foreach (Rigidbody2D enemyRB in activeEnemies)
        {
            {
                // Rimuovi le restrizioni del nemico
                enemyRB.constraints = RigidbodyConstraints2D.None;
                enemyRB.constraints = RigidbodyConstraints2D.FreezeRotation;
                //Sblocco il generatore di nemici
                enemySpawner.SetActive(true);
            }
        }
    }


    //Metodo chiamato quando un nemico viene generato
    public void AddEnemy(Rigidbody2D enemyRB)
    {
        //Aggiungo il Rigidbody2D del nemico alla lista dei nemici attivi
        activeEnemies.Add(enemyRB);
    }

    //Metodo chiamato quando un nemico viene distrutto o disattivato
    public void RemoveEnemy(Rigidbody2D enemyRB)
    {
        // Rimuovi il Rigidbody2D del nemico dalla lista dei nemici attivi
        activeEnemies.Remove(enemyRB);
    }
}
