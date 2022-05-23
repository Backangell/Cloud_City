using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_AudioScript : MonoBehaviour
{

    public AudioSource AudioEffect;
    public AudioSource AudioMusic;
    public List<AudioClip> Lst_Audio;

    // Start is called before the first frame update
    void Start()
    {
        AudioEffect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySoundFunction(int x)
    {
        AudioEffect.clip = Lst_Audio[x];
        AudioEffect.Play();
        
    }

    public void Playmusic()
    {
        AudioMusic.Play();
        AudioMusic.loop = true;
    }
}
