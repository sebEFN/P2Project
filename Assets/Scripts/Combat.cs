using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using JetBrains.Annotations;
using System.Collections;
using TMPro;

public class Combat : MonoBehaviour
{
    public GameObject spawnSign;
    [Header("Fighter")]
    public Player player;
    public Enemy currentEnemy;
    public enum TurnState { PlayerTurn, EnemyTurn }

    [Header("Text")]
    public TurnState currentTurn = TurnState.PlayerTurn;
    public TextMeshProUGUI TurnOrder;
    private string Turn;
    public TextMeshProUGUI EnemyHealthText;
    public TextMeshProUGUI PlayerHealthText;


      

    // An instance of the ScriptableObject defined above.
   [SerializeField] Compendium compendium;

    // This will be appended to the name of the created entities and increment when each is created.
    int instanceNumber = 1;

    void Start()
    {
        SpawnEntities();

        Turn = "Player's";


    }

    void Update()
    {
        SetTurnOrder();
        UpdateEntityHealth();
    }

    void SpawnEntities()
    {

        foreach(var item in compendium.signs)
        {
            // Creates an instance of the prefab at the current spawn point.
            GameObject currenSign = Instantiate(spawnSign, new Vector2(0, 0), Quaternion.identity) as GameObject;
            currenSign.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, false);

            // Sets the name of the instantiated entity to be the string defined in the ScriptableObject and then appends it with a unique number. 
            currenSign.name = item.signName + instanceNumber;
            Image img = currenSign.GetComponent<Image>();
            img.sprite = item.signImage;
            Button signButton = currenSign.GetComponent<Button>();
            signButton.onClick.AddListener(() => ButtonEffects(item));

            instanceNumber++;
        }
    }

    void SetTurnOrder()
    {
        TurnOrder.text = "it's the " + Turn + " turn!";
    }

    void UpdateEntityHealth()
    {
        PlayerHealthText.text = "Player's health: " + player.Playerhealth.ToString();
        EnemyHealthText.text = "Enemy's health: " + currentEnemy.enemyHealth.ToString();
    }

    void ButtonEffects(Signs item)
    {
        if (currentTurn != TurnState.PlayerTurn) return;

        if (currentTurn == TurnState.PlayerTurn)
        {
        currentEnemy.enemyHealth -= item.damage;
        currentEnemy.isSleeping = item.sleep;
        player.Playerhealth += item.healing;
        player.Playershield += item.block;
        }

        if (currentEnemy.IsDead()) return; //enemy died, stop here

        EndPlayerTurn();

    }

    private void EndPlayerTurn()
    {
        currentTurn = TurnState.EnemyTurn;
        Turn = "Goblin's";
        Debug.Log("Enemy Turn");
        StartCoroutine(EnemyTurn());
    }

    private IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1f); // small delay feels natural
        
        if (currentEnemy.isSleeping == true)
        {
            currentTurn = TurnState.PlayerTurn;   
        }

        else
            {
                currentEnemy.Attack(player);
            }
        
        if (player.IsDead()) yield break;
        Turn = "Player's";

        currentTurn = TurnState.PlayerTurn;
    }
}
