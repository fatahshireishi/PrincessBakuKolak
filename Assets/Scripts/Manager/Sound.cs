using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip sound;

    public float volume;

    [HideInInspector]
    public AudioSource source;
}
