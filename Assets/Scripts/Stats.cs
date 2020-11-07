using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public Slider Finances;
    public Slider Popularity;
    public Slider Chaos;
    public Slider Doubt;
    // Start is called before the first frame update
    void Start()
    {
        Finances.value = 0.5f;
        Popularity.value = 0.5f;
        Chaos.value = 0.5f;
        Doubt.value = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
