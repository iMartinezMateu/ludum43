using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    [SerializeField]
    AudioClip s_seaAmbient, s_harbourAmbient, s_event, s_answer1, s_answer2, s_song;
    [SerializeField]
    AudioSource ambientSource, fxSource, musicSource;

    public static AudioManager instance;

    private void Start()
    {
        if (!instance) instance = this;
    }

    private void Update()
    {
        ambientSource.volume = GameManager.instance.effectVolume;
        fxSource.volume = GameManager.instance.effectVolume;
        musicSource.volume = GameManager.instance.musicVolume;
    }


    /// <summary>
    /// Inicia nuevo sonido ambiente
    /// </summary>
    /// <param name="index">0: Sea, 1: harbour</param>
    public void SetAmbient(int index)
    {
        switch (index)
        {
            case 0:
                ambientSource.clip = s_seaAmbient;
                ambientSource.Play();
                break;
            case 1:
                ambientSource.clip = s_harbourAmbient;
                ambientSource.Play();
                break;
        }
    }

    public void PlaySong()
    {
        musicSource.clip = s_song;
        musicSource.Play();
    }
    
    public void PlaySea()
    {
        ambientSource.clip = s_seaAmbient;
        ambientSource.loop = true;
        ambientSource.Play();
    }

    public void PlayEvent()
    {
        fxSource.clip = s_event;
        fxSource.Play();
    }
    public void PlayAnswer1()
    {
        fxSource.clip = s_answer1;
        fxSource.Play();
    }
    public void PlayAnswer2()
    {
        fxSource.clip = s_answer2;
        fxSource.Play();
    }
    
    void Awake() {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);    
		
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(ambientSource);
        DontDestroyOnLoad(fxSource);
        DontDestroyOnLoad(musicSource);
    }
}
