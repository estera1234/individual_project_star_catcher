using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempText : MonoBehaviour
{
    public AudioClip announceClip;
    public AudioSource clipPlayer;
    // Start is called before the first frame update
    void Start()
    {
        clipPlayer.clip = announceClip;
        clipPlayer.Play();
        Destroy(gameObject, 2); 
    }
}
