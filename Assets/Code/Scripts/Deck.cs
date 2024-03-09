using System.Collections;
using System.Collections.Generic;
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
}