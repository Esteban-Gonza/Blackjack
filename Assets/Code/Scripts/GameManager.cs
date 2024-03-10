using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Buttons")]
    public Button dealBtn;
    public Button hitBtn;
    public Button standBtn;
    public Button betdBtn;

    [Header("Text")]
    public TextMeshProUGUI standText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI dealerScoreText;
    public TextMeshProUGUI betsText;
    // Main text
    public TextMeshProUGUI cashText;

    [Header("References")]
    [SerializeField] GameObject hideCard;
    [SerializeField] Players playerScript;
    [SerializeField] Players dealerScript;

    private int standClicks = 0;
    private int pot = 0;

    private void Start()
    {
        dealBtn.onClick.AddListener(() => DealClicked());
        hitBtn.onClick.AddListener(() => HitClicked());
        standBtn.onClick.AddListener(() => StandClicked());
    }

    private void DealClicked()
    {
        dealerScoreText.gameObject.SetActive(false);
        GameObject.Find("Deck").GetComponent<Deck>().Shuffle();
        playerScript.StartHand();
        dealerScript.StartHand();

        // Update displayed score
        scoreText.text = "Hand: " + playerScript.handValue.ToString();
        dealerScoreText.text = "Hand: " + dealerScript.handValue.ToString();

        // Set button visibility
        dealBtn.gameObject.SetActive(false);
        hitBtn.gameObject.SetActive(true);
        standBtn.gameObject.SetActive(true);
        standText.text = "Stand";
        // Set pot size
        pot = 40;
        betsText.text = pot.ToString();
        //playerScript.AdjustMoney(-20);
        //cashText.text = playerScript.GetMoney().ToSting();
    }

    private void HitClicked()
    {

        if(playerScript.GetCard() <= 10)
        {
            playerScript.GetCard();
        }
    }

    private void StandClicked()
    {
        standClicks++;
        if (standClicks > 1) Debug.Log("End Function");
        HitDealer();
        standText.text = "Call";
    }

    private void HitDealer()
    {
        while(dealerScript.handValue < 10 && dealerScript.cardIndex < 10)
        {
            dealerScript.GetCard();
        }
    }
}