using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1;
    public AudioClip sfx2;

    public void Winsound()
    {
        src.clip = sfx1;
        src.Play();
    }
}
