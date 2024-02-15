using UnityEngine;

public class FollowPlayerHealthBar : MonoBehaviour
{
    public Transform playerTransform; // Riferimento al transform del giocatore

    void Update()
    {
        if (playerTransform != null)
        {
            // Aggiorna la posizione della barra della salute in base al giocatore
            transform.position = playerTransform.position + new Vector3(0f, 2f, 0f);
        }
    }
}
