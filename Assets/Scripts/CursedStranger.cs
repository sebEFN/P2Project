using UnityEngine;
using UnityEngine.SceneManagement;

public class CursedStranger : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyHealth = 30;
        enemyDamage = 2;
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
        SceneManager.LoadScene("7.2 cursed traveller part 2");
    }
}
