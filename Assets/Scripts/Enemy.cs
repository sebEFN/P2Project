using UnityEngine;

abstract class Enemy : MonoBehaviour
{
    public int enemyHealth;
    public int enemyDamage; 
    public bool isSnoozing = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public abstract void attack();
   public abstract void snooze();

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    public virtual void TakeDamage (int amount)
    {
        enemyHealth -= amount;
        if (enemyHealth <= 0 ) Die();
    }
}
