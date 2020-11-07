using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Card
{
    public string Title;
}
[System.Serializable]
public class Choice
{
    public string SituationText;
    public Card[] CardChoices;
}

public class DeckManager : MonoBehaviour
{
    public Choice[] Choices;
    public CardPositionManager _positionManager;
    public CardChoiceManager _choiceManager;
    Choice _activeChoice;
    public Choice ActiveChoice { 
        get {
            return this._activeChoice;
        }
        set {
            _activeChoice = value;
            _positionManager.UpdateCardPosition(value);
            _choiceManager.UpdateCardText(value);
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
