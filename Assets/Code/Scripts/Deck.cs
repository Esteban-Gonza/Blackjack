using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] Sprite[] cardSprites;
    int[] cardValues = new int[53];
    int currentIndex = 0;

    private void Start()
    {
        GetCardValues();
    }

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
    }

    public void Shuffle()
    {
        for(int i = cardSprites.Length - 1; i > 0 ; --i)
        {
            int j = Mathf.FloorToInt(Random.Range(0.0f, 1.0f) * cardSprites.Length - 1) + 1;
            Sprite face = cardSprites[i];
            cardSprites[i]= cardSprites[j];
            cardSprites[j] = face;

            int value = cardValues[i];
            cardValues[i] = cardValues[j];
            cardValues[j] = value;
        }
        currentIndex = 1;
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