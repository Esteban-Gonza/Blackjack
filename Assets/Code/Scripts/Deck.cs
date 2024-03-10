using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] Sprite[] cardSprites;
    int[] cardValues = new int[53];
    int currentIndex = 0;

    void GetCardValues()
    {
        int num = 0;

        // Loop to assign value to the card sprites
        for(int i = 0; i < cardSprites.Length; i++)
        {
            num = i;
            // Count up to the ammount of cards = 52
            num %= 13;
            if(num > 10 || num == 0)
            {
                num = 10;
            }
            cardValues[i] = num++;
        }
        currentIndex = 1;
    }

    public void Shuddle()
    {
        for(int i = cardSprites.Length - 1; i > 0 ; --i)
        {
            int j = Mathf.FloorToInt(Random.Range(0f, 1f) * cardSprites.Length - 1) + 1;
            Sprite face = cardSprites[i];
            cardSprites[i]= cardSprites[j];
            cardSprites[j] = face;

            int value = cardValues[i];
            cardValues[i] = cardValues[j];
            cardValues[j] = value;
        }
    }

    public int DealCard(Card card)
    {
        card.SetSprite(cardSprites[currentIndex]);
        card.SetValue(cardValues[currentIndex]);
        currentIndex++;
        return card.GetValueOfCard();
    }

    public Sprite GetCardBack()
    {
        return cardSprites[0];
    }
}