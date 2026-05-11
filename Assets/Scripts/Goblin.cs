using UnityEngine;

public class Goblin : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyHealth = 30;
        enemyDamage = 5;
    }

    public override void Attack(Player Playerhealth)
    {
        Playerhealth.PlayerTakeDamage(enemyDamage);
    }

    public override void Snooze()
    {
        
    }
}
