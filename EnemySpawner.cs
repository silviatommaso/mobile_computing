using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;  // Il prefab del nemico
    public Freeze freeze;

    public float spawnInterval;  // Intervallo di tempo tra le generazioni di nemici
    public Transform playerTransform;

    public GameObject enemySpawner;

    public float spawnRadius;  // Raggio intorno al giocatore in cui generare proiettili


    public void OnEnable()
    {
        // Avvia la generazione automatica dei nemici
        StartCoroutine(SpawnEnemies());   
    }


    //generatore di nemici in posizione randomica
    public IEnumerator SpawnEnemies()
    {
        
        while(true)
        {
        
            //attendo qualche secondo prima di generare un nuovo nemico
            yield return new WaitForSeconds(spawnInterval);

            //calcolo una posizione casuale e verifico che non corrisponda all'area dove si trova correntemente il player
            Vector3 spawnPosition;
            do{
                Vector2 randomCirclePosition = Random.insideUnitCircle * spawnRadius;
                spawnPosition = playerTransform.position + new Vector3(randomCirclePosition.x, randomCirclePosition.y, 0f);
            }while(IsPositionSafeArea(spawnPosition) || !IsInGameArea(spawnPosition) || spawnPosition.y<-253f);
            //instanzio il nuovo nemico nel gioco
            GameObject newSlime = Instantiate(enemy, spawnPosition, Quaternion.identity);

            //attivo il gameObject del nemico
            freeze.AddEnemy(newSlime.GetComponent<Rigidbody2D>());
            newSlime.SetActive(true);
        }
    }


    private bool IsPositionSafeArea(Vector3 position)
    {
        //Definisco le coordinate dell'area sicura attorno al personaggio
        float safeAreaXMin = playerTransform.position.x - 2f;
        float safeAreaXMax = playerTransform.position.x + 2f;
        float safeAreaYMin = playerTransform.position.y - 2f;
        float safeAreaYMax = playerTransform.position.y + 2f;

        //Verifico se la posizione è nell'area sicura
        return position.x >= safeAreaXMin && position.x <= safeAreaXMax &&
               position.y >= safeAreaYMin && position.y <= safeAreaYMax;
    }


    private bool IsInGameArea(Vector3 position)
    {
        // Verifico se la posizione è nell'area di gioco
        return position.x >= -3.83f && position.x <= 0.53f;
    }
}
