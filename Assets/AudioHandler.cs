using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioData
{
    [SerializeField] private string id;
    [SerializeField] private List<AudioClip> clips = new List<AudioClip>();

    public string Id => id;
    public AudioClip Clip => clips[Random.Range(0, clips.Count)];
}

public class AudioHandler : MonoBehaviour
{
    [SerializeField] private List<AudioData> audio = new List<AudioData>();
    [SerializeField] private AudioSource aSource;
    public void PlayAudio(string id)
    {
        AudioData ad = audio.Find(obj => obj.Id == id);

        if (ad == null) return;

        aSource.clip = ad.Clip;
        aSource.Play();
    }
}
