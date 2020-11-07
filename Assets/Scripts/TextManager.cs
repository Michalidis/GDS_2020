using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextManager : MonoBehaviour
{
    public Text Information_text;
    
    public void UpdateSituationText(Choice choice)
    {
        Information_text.text = choice.SituationText;    
    }

    public void UpdateSituationText(string text)
    {
        Information_text.text = text;
    }

    public void ClearSituationText()
    {
        Information_text.text = "";
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
