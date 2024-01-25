using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiotManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("------------- Background Music -------------")]
    [SerializeField] public AudioSource musicSource;
    
    [Header("------------- Audio Clip -------------")]
    public AudioClip background;

    public static AudiotManager instance;
    private float _volume;
    private bool _isMuted;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    void Start()
    {
        musicSource.clip = background;
        _isMuted = false;
        musicSource.Play();
        _volume = musicSource.volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MuteSwitch() {
        if (_isMuted)
        {
            instance.musicSource.volume = _volume;
            _isMuted = false;
        }
        else
        {
            _volume = instance.musicSource.volume;
            instance.musicSource.volume = 0;
            _isMuted = true;
        }
    }

    public bool isMuted()
    {
        return _isMuted;
    }
}
