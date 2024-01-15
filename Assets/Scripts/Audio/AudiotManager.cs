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
        musicSource.clip= background;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
