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

    private int numberOfTimesPlayedIDH;

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

        audioSources[0].Play();

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

    public void PlayKeyboardSound()
    {
        int random = UnityEngine.Random.Range(1,5);

        audioSources[random].Play();

    }

    IEnumerator StopKeyBoardSoundAutomatically()
    {
        yield return new WaitForSeconds(0.2f);

        audioSources[1].Play();

        yield break;
    }

    public void StopKeyboardSound()
    {
        audioSources[1].Stop();
    }

    public void PlayIDHKey()
    {
        if(numberOfTimesPlayedIDH>=1)
        {
            audioSources[6].Play();
        }
        else
        {
            audioSources[5].Play();
        }
        numberOfTimesPlayedIDH++;
    }
}
