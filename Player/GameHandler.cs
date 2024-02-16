using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public HealthBar healthBar;
 

    void Start()
    {
        
        HealthSystem healthSystem = new HealthSystem(100);

        Debug.Log("Health: "+ healthSystem.GetHealth());

        healthBar.Setup(healthSystem);
    }

}
