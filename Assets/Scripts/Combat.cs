using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using JetBrains.Annotations;
using System.Collections;
using TMPro;
using Unity.VisualScripting;

public class Combat : MonoBehaviour
{
    public GameObject spawnSign;
    public GameObject spawnCard;
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
    private SpriteRenderer enemyColor;


      

    // An instance of the ScriptableObject defined above.
   [SerializeField] Compendium compendium;

    // This will be appended to the name of the created entities and increment when each is created.

    void Start()
    {
       compendium = GameObject.FindGameObjectWithTag("CompendiumTag").GetComponent<Compendium>();
        SpawnEntities();

        Turn = "Player's";

       enemyColor = currentEnemy.GetComponent<SpriteRenderer>();



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
            GameObject currentCard = Instantiate(spawnCard, new Vector2(0, 0), Quaternion.identity) as GameObject;
            // Creates an instance of the prefab at the current spawn point.
            GameObject currentSign = Instantiate(spawnSign, new Vector2(200, 1700), Quaternion.identity) as GameObject;
            currentCard.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, false);
            currentSign.transform.SetParent (currentCard.transform, false);

            // Sets the name of the instantiated entity to be the string defined in the ScriptableObject and then appends it with a unique number. 
            currentSign.name = item.signName;
            currentCard.name = "meow";
            RawImage img = currentSign.GetComponent<RawImage>();
            img.texture = item.signImage;
            Button signButton = currentSign.GetComponent<Button>();
            signButton.onClick.AddListener(() => ButtonEffects(item));
            Button cardButton = currentCard.GetComponent<Button>();
            cardButton.onClick.AddListener(() => CardEffect(currentCard));
            TextMeshProUGUI buttonText = currentCard.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = item.signName;
            TextMeshProUGUI damageText = currentSign.transform.Find("DamageText").GetComponent<TextMeshProUGUI>();
            if (item.damage !=0)
            damageText.text = "Damage " + item.damage;
            TextMeshProUGUI healText = currentSign.transform.Find("HealText").GetComponent<TextMeshProUGUI>();
            if (item.healing !=0)
            healText.text = "Heal " + item.healing;

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
    void CardEffect(GameObject card)
    {
        Debug.Log("grrr");
        if (currentTurn != TurnState.PlayerTurn) return;

        if (currentTurn == TurnState.PlayerTurn)
        {
            if (card.transform.GetChild(1).gameObject.activeInHierarchy == false)
                card.transform.GetChild(1).gameObject.SetActive(true);
            else
            {
                card.transform.GetChild(1).gameObject.SetActive(false);
            }
        }

        if (currentEnemy.IsDead()) return; //enemy died, stop here


    }

    private void EndPlayerTurn()
    {
        currentTurn = TurnState.EnemyTurn;
        Turn = "Enemy's";
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
                StartCoroutine(PlayerHurt());
            }
        
        if (player.IsDead()) yield break;
        Turn = "Player's";

        currentTurn = TurnState.PlayerTurn;
    }

    private IEnumerator PlayerHurt()
    {
        enemyColor.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        enemyColor.color = Color.white;
    }
}
