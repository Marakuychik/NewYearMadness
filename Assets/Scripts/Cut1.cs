using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut1 : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;

    void Deact()
    {
        source.clip = clip;
        source.Play();
        this.gameObject.SetActive(false);
    }
}
