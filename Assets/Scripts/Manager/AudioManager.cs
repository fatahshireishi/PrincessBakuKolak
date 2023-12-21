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
            s.source.clip = s.sound;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }

    public void PlaySound(string soundName)
    {
        if (Instance == null) return;

        Sound sound = Array.Find(sounds, s => s.name == soundName);

        if (sound == null && sound.sound == null) return;

        sound.source.Play();
        Debug.Log(sound.name);
    }

    public void StopSound(string soundName, float Duration)
    {
        if (Instance == null) return;

        Sound sound = Array.Find(sounds, s => s.name == soundName);

        if (sound == null) return;

        sound.source.DOFade(0, Duration).OnComplete(() =>
        {
            sound.source.Stop();
            sound.source.volume = sound.volume;
        });
    }
}
