using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource MusicPlayer;
    public AudioSource SoundPlayer;
    void Start()
    {
        Instance = this;
    }
    public void PlaySound(string name){
        AudioClip clip = Resources.Load<AudioClip>(name);
        SoundPlayer.PlayOneShot(clip);
    }
}
