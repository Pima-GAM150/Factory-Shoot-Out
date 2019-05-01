using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public void Sound(string soundName)
    {
        Audiomanager.instance.Play(soundName);
    }
}
