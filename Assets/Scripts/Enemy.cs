using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int enemyHealth;
    public int enemyDamage; 
    public bool isSleeping = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public abstract void Attack(Player Playerhealth);
   public abstract void Snooze();

    public abstract void Die();

    public bool IsDead()
    {
        return enemyHealth <= 0;
    }

    public virtual void EnemyTakeDamage ()
    {
        if (enemyHealth <= 0 ) Die();
    }

    void Update()
    {
        EnemyTakeDamage();
    }
}
