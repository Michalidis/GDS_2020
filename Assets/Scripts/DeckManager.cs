using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Effect
{
    public float Finances;
    public float Popularity;
    public float Chaos;
    public float Doubt;
}

[System.Serializable]
public class Card
{
    public string Title;
    public Effect Effect;
}
[System.Serializable]
public class Choice
{
    public string SituationText;
    public Card[] CardChoices;
}

public class DeckManager : MonoBehaviour
{
    public Stats Stats;
    public Choice[] Choices;
    public CardPositionManager _positionManager;
    public CardChoiceManager _choiceManager;
    public TextManager _textManager;
    public Choice ActiveChoice { 
        get {
            return Stats._activeChoice;
        }
        set {
            Stats._activeChoice = value;
            _choiceManager.ClearCardInstances();
            for (int i = 0; i < value.CardChoices.Length; i++)
            {
                _choiceManager.UpdateCardInstance(i, value.CardChoices[i]);
            }
            _textManager.UpdateSituationText(value);
            _choiceManager.UpdateCardText(value);
            _positionManager.UpdateCardPosition(value);
        }
    }
    void ActivateChoice(Choice choice)
    {
        ActiveChoice = choice;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called after all Start methods are done
    void Awake()
    {
        ActivateChoice(Choices[0]);
    }

}
