using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextManager : MonoBehaviour
{
    public Text Information_text;
    
    public void UpdateSituationText(Choice choice)
    {
        StartCoroutine(_updateSituationText(choice.SituationText));
    }

    public void UpdateSituationText(string text, bool fade_in = true)
    {
        StartCoroutine(_updateSituationText(text, fade_in));
    }

    private IEnumerator _updateSituationText(string text, bool fade_in = true)
    {
        Information_text.text = text;
        if (fade_in)
        {
            DOTween.To(() => Information_text.color, x => Information_text.color = x, new Color(255, 255, 255, 1.0f), 1.0f);
        }
        yield return new WaitForSeconds(1.0f);
    }

    public void ClearSituationText(bool fade_out = true)
    {
        StartCoroutine(_clearSituationText(fade_out));
    }

    private IEnumerator _clearSituationText(bool fade_out = true)
    {
        if (fade_out)
        {
            DOTween.To(() => Information_text.color, x => Information_text.color = x, new Color(255, 255, 255, 0.0f), 1.0f);
            yield return new WaitForSeconds(1.0f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
