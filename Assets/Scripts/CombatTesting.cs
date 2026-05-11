using UnityEngine;

public class CombatTest : MonoBehaviour
{
    public Player player;
    public Goblin goblin;

    void Update()
    {
        // Press Space to deal 8 damage to goblin
        if (Input.GetKeyDown(KeyCode.Space))
        {
            goblin.TakeDamage(8);
            Debug.Log("Goblin HP: " + goblin.enemyHealth);
        }

        // Press G to make goblin attack player
        if (Input.GetKeyDown(KeyCode.G))
        {
            goblin.Attack(player);
            Debug.Log("Player HP: " + player.Playerhealth);
        }
    }
}
