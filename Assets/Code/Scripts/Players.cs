using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    [SerializeField] Card cardScript;
    [SerializeField] Deck deckScript;

    // Player's/Dealer's hand value
    public int handValue = 0;
    // Betting money
    private int money = 1000;
    // Card objects on the table
    public GameObject[] hand;
    // Next card index
    public int cardIndex = 0;
    // Track ace 1 or 11 value
    List<Card> aceList = new List<Card>();

    public void StartHand()
    {
        GetCard();
        GetCard();
    }

    public int GetCard()
    {
        int cardValue = deckScript.DealCard(hand[cardIndex].GetComponent<Card>());

        //Show card on game screen
        hand[cardIndex].GetComponent<Renderer>().enabled = true;
        // Add card value to run total of the hand
        handValue += cardValue;

        // Filter ace cards
        if(cardValue == 1)
        {
            aceList.Add(hand[cardIndex].GetComponent<Card>());
        }

        // Check if ace value is = to 1 or 11
        //AceCheck();
        cardIndex++;
        return handValue;
    }
}