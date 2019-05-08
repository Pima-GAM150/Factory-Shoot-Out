using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;

public class Audiomanager : MonoBehaviour
{
    public Sound[] sounds;
    public static Audiomanager instance;

    public Animator animator;
    public bool dirty;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    //FindObjectOfType<Audiomanager>().Play("Name of Sound");
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            print("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    void Start()
    {
        OpenGame();
    }


    

    public void OpenGame()
    { 
        animator.SetBool("runAnimator", true);
        StartCoroutine("WaitAndPlay");


    }

    IEnumerator WaitAndPlay()
    {
        yield return new WaitForSeconds(1.25f);
        Play("Theme");
        dirty = true;
    }
}
