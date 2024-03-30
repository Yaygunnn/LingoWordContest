using UnityEngine;

[CreateAssetMenu(menuName = "Audio Events/Randomized")]
public class RandomizedAudio : AudioEvent
{
    public AudioClip[] clips;

    [Range(0f, 2f)]
    public float minVolume = 1;

    [Range(0f, 2f)]
    public float maxVolume = 1;

    [Range(0f, 2f)]
    public float minPitch = 1;

    [Range(0f, 2f)]
    public float maxPitch = 1;

    public override void Play(AudioSource source)
    {
        if (clips.Length == 0) return;

        source.clip = clips[Random.Range(0, clips.Length)];
        source.volume = Random.Range(minVolume, maxVolume);
        source.pitch = Random.Range(minPitch, maxPitch);
        source.Play();
    }
}
