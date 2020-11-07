using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardChoiceManager : MonoBehaviour
{
    public GameObject[] cards;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void UpdateCardText(Choice choice)
    {
        for (int i = 0; i < choice.CardChoices.Length; i++)
        {
            cards[i].GetComponentInChildren<Text>().text = choice.CardChoices[i].Title;
        }
    }

    public void UpdateCardInstance(int cardId, Card card)
    {
        cards[cardId].GetComponent<CardScript>().Card = card;
    }

    public void ClearCardInstances()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].GetComponent<CardScript>().Card = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
