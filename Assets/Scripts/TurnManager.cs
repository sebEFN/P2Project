using System.Collections;
using UnityEngine;


// TurnManager.cs — controls whose turn it is
public class TurnManager : MonoBehaviour
{
    public Player player;
    public Enemy currentEnemy;
    public enum TurnState { PlayerTurn, EnemyTurn }
    public TurnState currentTurn = TurnState.PlayerTurn;

    public void PlayCard(int cardDamage)
    {
        if (currentTurn != TurnState.PlayerTurn) return;

        currentEnemy.TakeDamage(cardDamage);

        if (currentEnemy.IsDead()) return; //enemy died, stop here

        EndPlayerTurn();
    }

    private void EndPlayerTurn()
    {
        currentTurn = TurnState.EnemyTurn;
        StartCoroutine(EnemyTurn());
    }

    private IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1f); // small delay feels natural
        
        currentEnemy.Attack(player);
        
        if (player.IsDead()) yield break;

        currentTurn = TurnState.PlayerTurn;
    }
}
