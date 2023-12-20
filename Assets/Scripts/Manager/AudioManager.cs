using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] Sound[] sounds;

    private void Awake()
    {
        if (Instance == null) Instance = this;

        DontDestroyOnLoad(this);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.volume = s.volume;
        }
    }

    public void PlaySound(string soundName)
    {
        Sound sound = Array.Find(sounds, s => s.name == soundName);

        if (sound != null) return;

        sound.source.Play();
    }
}
