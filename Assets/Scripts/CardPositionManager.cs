using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPositionManager : MonoBehaviour
{
    Vector3 VoidPosition = new Vector3(-1000, -1000, -1000);
    public GameObject[] cards;
    public GameObject[] card_positions_3;
    public GameObject[] card_positions_2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void MoveCardsToThreePositionLayout()
    {
        for (int i = 0; i < card_positions_3.Length; i++)
        {
            cards[i].transform.position = card_positions_3[i].transform.position;
        }
    }

    void MoveCardsToTwoPositionLayout()
    {
        for (int i = 0; i < card_positions_2.Length; i++)
        {
            cards[i].transform.position = card_positions_2[i].transform.position;
        }
    }

    public void UpdateCardPosition(Choice choice)
    {
        if (choice.CardChoices.Length == 2)
        {
            MoveCardsToTwoPositionLayout();
        }
        else if (choice.CardChoices.Length == 3)
        {
            MoveCardsToThreePositionLayout();
        }
    }

    public void MoveAllCardsAwayFromScene()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].transform.position = VoidPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
