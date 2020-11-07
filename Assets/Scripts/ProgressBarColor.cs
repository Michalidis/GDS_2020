using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarColor : MonoBehaviour
{
    private Color minColor = Color.red;
    private Color maxColor = Color.green;
    public Image Fill;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Fill.color = Color.Lerp(minColor, maxColor, gameObject.GetComponent<Slider>().value);
    }
}
