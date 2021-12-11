using UnityEngine.Audio;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    private static Dictionary<string, float> soundTimerDictionary;
    private static AudioManager _instance;

    public static AudioManager instance
    {
        get
        {
            return _instance;
        }
    }


    void Awake()
    {
        if (_instance!= null && _instance!=this)
            
        {
            Destroy(this.gameObject);
        }

        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(gameObject);

        soundTimerDictionary = new Dictionary<string, float>();

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            if(s.hasCooldown)
            {
                Debug.Log(s.name);
                soundTimerDictionary[s.name] = 0f;
            }
        }
    }

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Theme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
    }

        if (!CanPlaySound(s)) return;
         
        s.source.Play();
    }

    public void Stop(String name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound" + name + "not found!");
            return;
        }

        s.source.Stop();
    }

    private static bool CanPlaySound (Sound s)
    {
        if (soundTimerDictionary.ContainsKey(s.name))
        {
            float lastTimePlayed = soundTimerDictionary[s.name];
           
        if (lastTimePlayed + s.clip.length < Time.time)
            {
                soundTimerDictionary[s.name] = Time.time;
                    return true;
            }

            return false;

        }

        return true;
    }
   }
