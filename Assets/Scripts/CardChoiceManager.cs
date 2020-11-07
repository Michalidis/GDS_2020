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

    // Update is called once per frame
    void Update()
    {
        
    }
}
