using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    private bool expectingInput;
    public Choice _activeChoice;

    public DeckManager _deckManager;

    public Slider Finances;
    public Slider Popularity;
    public Slider Chaos;
    public Slider Doubt;
    // Start is called before the first frame update
    void Start()
    {
        Finances.value = 0.5f;
        Popularity.value = 0.0f;
        Chaos.value = 0.0f;
        Doubt.value = 0.0f;

        expectingInput = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!expectingInput)
        {
            return;
        }

        if (Input.anyKey)
        {
            expectingInput = false;
            PrepareNewChoice();
        }
    }

    public void MakeChoice(int cardId)
    {
        if (_activeChoice == null)
        {
            return;
        }
        
        Effect effect = _activeChoice.CardChoices[cardId].Effect;

        Finances.value += effect.Finances;
        Popularity.value += effect.Popularity;
        Chaos.value += effect.Chaos;
        Doubt.value += effect.Doubt;

        string response = _activeChoice.CardChoices[cardId].Response;
        _activeChoice = null;

        _deckManager._positionManager.MoveAllCardsAwayFromScene();
        _deckManager._textManager.ClearSituationText();

        if (response != null)
        {
            _deckManager._textManager.UpdateSituationText(response);
            expectingInput = true;
        }
        else
        {
            PrepareNewChoice();
        }
    }

    public void PrepareNewChoice()
    {
        Choice choice = _deckManager.GetRandomUnseenChoice();
        if (choice == null)
        {
            _deckManager._textManager.UpdateSituationText("Out of articles . . .");
            return;
        }

        _deckManager.ActivateChoice(choice);
    }
}
