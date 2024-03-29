using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Audio Events/Simple")]
public class SimpleAudioEvent : AudioEvent
{
    public AudioClip[] clips;

    [Range(0f,2f)]
    public float volume = 1;


    [Range(0f, 2f)]
    public float pitch = 1;

    public override void Play(AudioSource source)
    {
        if (clips.Length == 0) return;

        source.clip = clips[Random.Range(0, clips.Length)];
        source.volume = volume;
        source.pitch = pitch;
        source.Play();
    }
    
}
