﻿using System.Collections;
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
        if (CheckStatsForDefeat())
        {
            return;
        }

        Choice choice = _deckManager.GetRandomUnseenChoice();
        if (choice == null)
        {
            _deckManager._textManager.UpdateSituationText("Out of articles . . .");
            return;
        }

        _deckManager.ActivateChoice(choice);
    }

    bool CheckStatsForDefeat()
    {
        if (Finances.value >= 1.0f)
        {
            _deckManager._textManager.ClearSituationText();
            _deckManager._textManager.UpdateSituationText("You have become drunk with money and became too lazy to write more articles. After a month you find yourself homeless with a bottle of pure alcohol in your hand... completely blind.");
            return true;
        }
        else if (Finances.value <= 0.0f)
        {
            _deckManager._textManager.ClearSituationText();
            _deckManager._textManager.UpdateSituationText("Poverty struck you hard and you eventually die. Maybe you wanted to be too fair without any greed?");
            return true;
        }
        else if (Popularity.value >= 1.0f)
        {
            _deckManager._textManager.ClearSituationText();
            _deckManager._textManager.UpdateSituationText("Your boss comes to you with a scary smile on his face: \"You have made our company successful! We are number one!\". But... that also means they don't need you anymore. You have lost your job.");
            return true;
        }
        else if (Popularity.value <= 0.0f)
        {
            _deckManager._textManager.ClearSituationText();
            _deckManager._textManager.UpdateSituationText("You were trying to be fair and share the truth with the world. Unfortunately, truth is usually not interesting and nobody cares about your articles anymore.");
            return true;
        }
        else if (Chaos.value >= 1.0f)
        {
            _deckManager._textManager.ClearSituationText();
            _deckManager._textManager.UpdateSituationText("The world is in shambles as people are panicking and protesting all over the world. A bunch of burglars break into your house at night and you catch them in the act. You were killed.");
            return true;
        }
        else if (Chaos.value <= 0.0f)
        {
            _deckManager._textManager.ClearSituationText();
            _deckManager._textManager.UpdateSituationText("The world has become a peaceful place. A new paradise, people call it! Nobody is spreading chaos and disinformation anymore. There is no more violence. There is nothing to write articles about . . .");
            return true;
        }
        else if (Doubt.value >= 1.0f)
        {
            _deckManager._textManager.ClearSituationText();
            _deckManager._textManager.UpdateSituationText("People all around the world have realized that all you spread is just hatred and lies. You drink your tea during another beautiful morning, just to find out it tastes wrong. You die one day later - poisoned.");
            return true;
        }
        else if (Doubt.value <= 0.0f)
        {
            _deckManager._textManager.ClearSituationText();
            _deckManager._textManager.UpdateSituationText("Your articles are pure gold! Your work is globally recognized as the universal truth. There are people who dislike that... You get kidnapped in your sleep and brainwashed to spread misinformation while people still believe everything you publish. You have become someone's puppet.");
            return true;
        }

        return false;
    }
}
