using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPositionManager : MonoBehaviour
{
    Vector3 VoidPosition = new Vector3(-1000, -1000, -1000);
    GameObject[] cards;
    GameObject[] card_positions_3;
    GameObject[] card_positions_2;
    // Start is called before the first frame update
    void Start()
    {
        // Load card positions
        card_positions_3 = new GameObject[3];
        card_positions_3[0] = GameObject.Find("3_articles_pos_1");
        card_positions_3[1] = GameObject.Find("3_articles_pos_2");
        card_positions_3[2] = GameObject.Find("3_articles_pos_3");
        
        card_positions_2 = new GameObject[2];
        card_positions_2[0] = GameObject.Find("2_articles_pos_1");
        card_positions_2[1] = GameObject.Find("2_articles_pos_2");

        // Load cards
        cards = new GameObject[3];
        cards[0] = GameObject.Find("ArticleCard_1");
        cards[1] = GameObject.Find("ArticleCard_2");
        cards[2] = GameObject.Find("ArticleCard_3");

        MoveCardsToTwoPositionLayout();
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

    void MoveAllCardsAwayFromScene()
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
