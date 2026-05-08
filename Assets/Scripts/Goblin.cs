using UnityEngine;

class Goblin : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyHealth = 30;
        enemyDamage = 5;
    }

    public override void attack()
    {
        //PlayerHealth.instance.TakeDamage (enemyDamage);
    }

    public override void snooze()
    {
        
    }
}
