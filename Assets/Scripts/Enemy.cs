using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int enemyHealth;
    public int enemyDamage; 
    public bool isSnoozing = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public abstract void Attack(Player Playerhealth);
   public abstract void Snooze();

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    public bool IsDead()
    {
        return enemyHealth <= 0;
    }

    public virtual void TakeDamage (int amount)
    {
        enemyHealth -= amount;
        if (enemyHealth <= 0 ) Die();
    }
}
