using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AutomaticSoundPlayer : MonoBehaviour
{
    public AudioSource SoundSource;
    public AudioClip CabLock;
    public AudioClip CupOnTable;
    public AudioClip DoubleClick;
    public AudioClip PageTurn;
    public AudioClip PaperCrumple;
    public AudioClip PenClick;
    public AudioClip Typing;

    private List<AudioClip> ListOfClips;
    private bool paused;
    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        ListOfClips = new List<AudioClip>();
        ListOfClips.Add(CabLock);
        ListOfClips.Add(CupOnTable);
        ListOfClips.Add(DoubleClick);
        ListOfClips.Add(PenClick);
        ListOfClips.Add(Typing);
        paused = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (paused)
        {
            return;
        }

        delay -= Time.deltaTime;
        if (delay <= 0.0f)
        {
            PlayRandomSoundWithRandomPitch();
            NewDelay();
        }
    }

    public void StartBackgroundSounds()
    {
        AudioSource source = GameObject.Find("Ambient").GetComponent<AudioSource>();
        source.volume = 0.0f;
        
        source.Play();
        DOTween.To(() => source.volume, x => source.volume = x, 0.7f, 12.0f);

        paused = false;
        NewDelay();
    }

    void PlayRandomSoundWithRandomPitch()
    {
        SoundSource.clip = ListOfClips[Random.Range(0, ListOfClips.Count)];
        SoundSource.pitch = Random.Range(0.4f, 2.0f);
        SoundSource.volume = Random.Range(0.3f, 1.0f);
        SoundSource.Play();
    }

    void NewDelay()
    {
        delay = Random.Range(10.0f, 30.0f);
    }

    public void SilenceAllSounds()
    {
        // Silence ambient sound
        AudioSource source = GameObject.Find("Ambient").GetComponent<AudioSource>();
        DOTween.To(() => source.volume, x => source.volume = x, 0.0f, 8.0f);
        // Silence random sounds
        DOTween.To(() => SoundSource.volume, x => SoundSource.volume = x, 0.0f, 8.0f);
        paused = true;
    }
}
