using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Buttons")]
    public Button dealBtn;
    public Button hitBtn;
    public Button standBtn;
    public Button betdBtn;

    [Header("References")]
    [SerializeField] Players playerScript;
    [SerializeField] Players dealerScript;

    private void Start()
    {
        dealBtn.onClick.AddListener(() => DealClicked());
        hitBtn.onClick.AddListener(() => HitClicked());
        standBtn.onClick.AddListener(() => StandClicked());
    }

    private void DealClicked()
    {
        GameObject.Find("Deck").GetComponent<Deck>().Shuffle();
        playerScript.StartHand();
        dealerScript.StartHand();
    }

    private void HitClicked()
    {
        throw new NotImplementedException();
    }

    private void StandClicked()
    {
        throw new NotImplementedException();
    }
}