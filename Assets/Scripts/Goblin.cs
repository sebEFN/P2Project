using UnityEngine;
using UnityEngine.SceneManagement;

public class Goblin : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyHealth = 15;
        enemyDamage = 3;
    }

    public override void Attack(Player Playerhealth)
    {
        Playerhealth.PlayerTakeDamage(enemyDamage);
    }

    public override void Snooze()
    {
        
    }

    public override void Die()
    {
        SceneManager.LoadScene("8 room");
    }
}
