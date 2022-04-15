using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource[] audioSources;

    public static AudioController Instance;

    public bool muteMusic;
    public bool muteSoundFX;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameController.Instance.gameStateChanged.AddListener(GameStateChanged);

        if(muteMusic)
        {
            foreach(AudioSource a in audioSources)
            {
                a.Stop();
            }
        }
    }

    private void gameOver()
    {
        //DOTween.To(() => audioSources[2].pitch, x => audioSources[2].pitch = x, 0.5f, 4).OnComplete(StopMusic);
    }

    private void StopMusic()
    {
        //audioSources[2].Stop();
    }

    private void GameStateChanged()
    {
       
    }

    IEnumerator SwitchTracks()
    {
        float time = 0;
        audioSources[2].Play();
        audioSources[2].volume = 0;

        while (time < 1f)
        {
            time += Time.deltaTime;
            audioSources[2].volume = time;
            audioSources[1].volume = 1- time;
        }
        audioSources[1].Stop();
        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
