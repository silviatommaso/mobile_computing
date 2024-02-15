using System.Collections;
using UnityEngine;

public class bulletSpawner : MonoBehaviour
{
    public GameObject bomb;  // Il prefab del proiettile
    public int numberOfBullets;  // Numero totale di proiettili da generare
    public float spawnInterval;  // Intervallo di tempo tra le generazioni dei proiettili
    public Transform playerTransform;
    public float spawnRadius;  // Raggio intorno al giocatore in cui generare proiettili
    public GameObject bullets;



    private IEnumerator SpawnBullets()
    {
        // Spawn delle bombe
        for (int i = 0; i < numberOfBullets; i++)
        {
            // Attivo il gameObject del proiettile
            bomb.SetActive(true);
        
            // Attendo qualche secondo prima di generare un nuovo proiettile
            yield return new WaitForSeconds(spawnInterval);

            // Calcolo una posizione casuale e verifica che non corrisponda all'area sicura attorno al giocatore
            // e che sia nell'area di gioco
            Vector3 spawnPosition;
            do
            {
                Vector2 randomCirclePosition = Random.insideUnitCircle * spawnRadius;
                spawnPosition = playerTransform.position + new Vector3(randomCirclePosition.x, randomCirclePosition.y, 0f);
            }
            while (IsPositionInSafeArea(spawnPosition) || !IsInGameArea(spawnPosition) || (spawnPosition.y < -253));

            // Instanzio il nuovo proiettile nel gioco
            GameObject newBomb = Instantiate(bomb, spawnPosition, Quaternion.identity);
        }

        // Attivo gli oggetti di proiettili
        bullets.SetActive(true);

        // Attendo per un certo periodo di tempo prima di distruggere tutti i proiettili
        yield return new WaitForSeconds(5f);

        // Distruggo tutti i proiettili presenti nel gioco
        GameObject[] bombs = GameObject.FindGameObjectsWithTag("Bomb");
        foreach (GameObject b in bombs)
        {
            b.SetActive(false);
        }

        // Disattivo il bulletSpawner
        bullets.SetActive(false);
    }


    private bool IsPositionInSafeArea(Vector3 position)
    {
        // Definisco le coordinate dell'area sicura attorno al personaggio
        float safeAreaXMin = playerTransform.position.x - 1f;
        float safeAreaXMax = playerTransform.position.x + 1f;
        float safeAreaYMin = playerTransform.position.y - 1f;
        float safeAreaYMax = playerTransform.position.y + 1f;

        // Verifico se la posizione è nell'area sicura
        return position.x >= safeAreaXMin && position.x <= safeAreaXMax &&
               position.y >= safeAreaYMin && position.y <= safeAreaYMax;
    }

    private bool IsInGameArea(Vector3 position)
    {
        // Verifico se la posizione è nell'area di gioco
        return position.x >= -3.44f && position.x <= 0.3f;
    }

    public void Active()
    {
        bullets.SetActive(true);
        StartCoroutine(SpawnBullets());
    }
}
