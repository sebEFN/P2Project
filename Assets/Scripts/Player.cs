using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int Playerhealth; 
    public int Playershield;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Playerhealth = 50;
    }

    private void PlayerDie()
    {
        SceneManager.LoadScene("Game Over");
    }

    public bool IsDead()
    {
        return Playerhealth <= 0;
    }

    public void PlayerTakeDamage (int amount)
    {
        Playerhealth -= amount;
        if (Playerhealth <= 0 ) PlayerDie();
    }

    
}
