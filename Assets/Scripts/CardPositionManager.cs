using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardPositionManager : MonoBehaviour
{
    Vector3 VoidPosition = new Vector3(80, -448, 0);
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
            cards[i].transform.DOMove(card_positions_3[i].transform.position, 0.75f, true);
        }
    }

    void MoveCardsToTwoPositionLayout()
    {
        for (int i = 0; i < card_positions_2.Length; i++)
        {
            cards[i].transform.DOMove(card_positions_2[i].transform.position, 0.75f, true);
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
            cards[i].transform.DOMove(VoidPosition, 0.75f, true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
