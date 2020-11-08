using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class CardScript : MonoBehaviour
{
    public AudioSource sound;
    GameObject finances;
    GameObject popularity;
    GameObject chaos;
    GameObject doubt;

    public Card Card;
    public int Id;
    // Start is called before the first frame update
    void Start()
    {
        finances = GameObject.Find("Finances");
        popularity = GameObject.Find("Popularity");
        chaos = GameObject.Find("Chaos");
        doubt = GameObject.Find("Doubt");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onMouseEnter()
    {
        // Play Sound
        sound.pitch = Random.Range(0.5f, 3.0f);
        sound.Play();

        // Scale and rotate the card
        transform.DOScale(new Vector3(1.1f, 1.1f, 1.0f), 0.75f);
        float rotateZ = Id == 0 ? 3.0f : -3.0f;// Id == 2 ? -2.5f : Random.Range(0, 1) > 0 ? 2.5f : -2.5f;
        if (Id == 1 && GameObject.Find("Game").GetComponent<Stats>()._activeChoice != null && GameObject.Find("Game").GetComponent<Stats>()._activeChoice.CardChoices.Length == 3)
        {
            rotateZ = 0.0f;
        }
        transform.DORotate(new Vector3(0.0f, 0.0f, rotateZ), 0.75f);

        // Scale the affected resources
        if (Mathf.Abs(Card.Effect.Popularity) > 0.0f)
        {
            if (Mathf.Abs(Card.Effect.Popularity) > 0.1f)
            {
                popularity.transform.DOScale(new Vector3(1.12f, 1.12f, 1.0f), 0.75f);
            }
            else
            {
                popularity.transform.DOScale(new Vector3(1.05f, 1.05f, 1.0f), 0.75f);
            }
        }
        if (Mathf.Abs(Card.Effect.Finances) > 0.0f)
        {
            if (Mathf.Abs(Card.Effect.Finances) > 0.1f)
            {
                finances.transform.DOScale(new Vector3(1.12f, 1.12f, 1.0f), 0.75f);
            }
            else
            {
                finances.transform.DOScale(new Vector3(1.05f, 1.05f, 1.0f), 0.75f);
            }
        }
        if (Mathf.Abs(Card.Effect.Chaos) > 0.0f)
        {
            if (Mathf.Abs(Card.Effect.Chaos) > 0.1f)
            {
                chaos.transform.DOScale(new Vector3(1.12f, 1.12f, 1.0f), 0.75f);
            }
            else
            {
                chaos.transform.DOScale(new Vector3(1.05f, 1.05f, 1.0f), 0.75f);
            }
        }
        if (Mathf.Abs(Card.Effect.Doubt) > 0.0f)
        {
            if (Mathf.Abs(Card.Effect.Doubt) > 0.1f)
            {
                doubt.transform.DOScale(new Vector3(1.12f, 1.12f, 1.0f), 0.75f);
            }
            else
            {
                doubt.transform.DOScale(new Vector3(1.05f, 1.05f, 1.0f), 0.75f);
            }
        }
    }

    public void onMouseLeave()
    {
        transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.75f);
        transform.DORotate(new Vector3(0.0f, 0.0f, 0.0f), 0.75f);
        
        popularity.transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.75f);
        finances.transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.75f);
        chaos.transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.75f);
        doubt.transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.75f);
    }
}
