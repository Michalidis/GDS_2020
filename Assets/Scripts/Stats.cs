using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public Choice _activeChoice;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeChoice(int cardId)
    {
        Effect effect = _activeChoice.CardChoices[cardId].Effect;

        Finances.value += effect.Finances;
        Popularity.value += effect.Popularity;
        Chaos.value += effect.Chaos;
        Doubt.value += effect.Doubt;
    }
}
