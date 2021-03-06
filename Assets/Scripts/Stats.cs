﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Stats : MonoBehaviour
{
    public AudioSource crumpleSound;

    private bool isIntro;
    private float timeSpentExpectingInput;
    private bool expectingInput;
    private bool theEnd;
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
        isIntro = true;
        theEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(expectingInput);
        Debug.Log(theEnd);
        if (!expectingInput && !theEnd)
        {
            return;
        }

        timeSpentExpectingInput += Time.deltaTime;

        if (Input.anyKey)
        {
            if (theEnd)
            {
                Application.Quit();
            }
            expectingInput = false;
            float delay = Mathf.Max(2.0f - timeSpentExpectingInput, 1.0f);
            _deckManager._textManager.ClearSituationText();
            StartCoroutine(PrepareNewChoice(delay));
        }
    }

    public void MakeChoice(int cardId)
    {
        if (_activeChoice == null)
        {
            return;
        }
        
        Effect effect = _activeChoice.CardChoices[cardId].Effect;

        // Play Sound
        crumpleSound.pitch = Random.Range(0.5f, 3.0f);
        crumpleSound.Play();

        DOTween.To(() => Finances.value, x => Finances.value = x, Finances.value + effect.Finances, 2.0f);
        DOTween.To(() => Popularity.value, x => Popularity.value = x, Popularity.value + effect.Popularity, 2.0f);
        DOTween.To(() => Chaos.value, x => Chaos.value = x, Chaos.value + effect.Chaos, 2.0f);
        DOTween.To(() => Doubt.value, x => Doubt.value = x, Doubt.value + effect.Doubt, 2.0f);

        string response = _activeChoice.CardChoices[cardId].Response;
        _activeChoice = null;

        _deckManager._positionManager.MoveAllCardsAwayFromScene();

        if (isIntro && response == "Welcome to the job.")
        {
            GameObject.Find("Jukebox").GetComponent<AutomaticSoundPlayer>().StartBackgroundSounds();
            isIntro = false;
        }

        if (response != "")
        {
            _deckManager._textManager.UpdateSituationText(response, false);
            expectingInput = true;
            timeSpentExpectingInput = 0.0f;
        }
        else
        {
            _deckManager._textManager.ClearSituationText();
            StartCoroutine(PrepareNewChoice(2.0f));
        }
    }

    public IEnumerator PrepareNewChoice(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for animations to finish
        if (CheckStatsForDefeat())
        {
            // Bad ending
            GameObject.Find("Jukebox").GetComponent<AutomaticSoundPlayer>().SilenceAllSounds();
            Image bg = GameObject.Find("Black_bg").GetComponent<Image>();
            DOTween.To(() => bg.color, x => bg.color = x, new Color(0, 0, 0, 1.0f), 1.0f);
            expectingInput = false;
            theEnd = true;
            yield break;
        }

        Choice choice = _deckManager.GetRandomUnseenChoice();
        if (choice == null)
        {
            // Good ending
            Image bg = GameObject.Find("Black_bg").GetComponent<Image>();
            DOTween.To(() => bg.color, x => bg.color = x, new Color(255, 255, 255, 1.0f), 1.0f);
            _deckManager._textManager.UpdateSituationText_black("You have proven to be capable of balancing between greed and humility, popularity and infrequency, chaos and peace, doubts and certainty. You have managed to do that while also facing unexpected outcomes. Who knows what could come up next year.\nThank you for playing our game.");
            expectingInput = false;
            theEnd = true;
            yield break;
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
            _deckManager._textManager.UpdateSituationText("Poverty struck you hard and you eventually die. Maybe this was not the best decision...");
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
