public class HealthSystem 
{
    private int health;
    private int healthMax;

    public HealthSystem(int healthMax){
        this.healthMax = healthMax;
        this.health = healthMax;
    }


    public int GetHealth(){
        return health;
    }

    public float GetHealthPercent(){
        return health/healthMax;
    }


    public void Damage(int damageAmount){
        health -= damageAmount;
        if(health<0){
            health = 0;
        }
    }

    public void Heal(int healAmount){
        health += healAmount;
        if(health> healthMax){
            health = healthMax;
        }
    }
}