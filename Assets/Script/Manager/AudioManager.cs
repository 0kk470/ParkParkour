using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource music;
    public static AudioManager instance;
    private void Start()
    {
        AudioListener.volume = DataManager.LoadData<int>(KeyConfig.Audio);
        music = GetComponent<AudioSource>();
        music.volume = DataManager.LoadData<int>(KeyConfig.Music);
        instance = this;
    }

    public static void SetVolume(bool check)
    {
        if (!check)
        {
            DataManager.SaveData(KeyConfig.Audio, 0);
            AudioListener.volume = 0;
        }
        else
        {
            DataManager.SaveData(KeyConfig.Audio, 1);
            AudioListener.volume = 1;
        }
    }

    public void SetMusic(bool check)
    {
        if (!check)
        {
            DataManager.SaveData(KeyConfig.Music, 0);
            music.volume = 0;
        }
        else
        {
            DataManager.SaveData(KeyConfig.Music, 1);
            music.volume = 1;
        }
    }

    public static void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }
}

