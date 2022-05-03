using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Game_object : MonoBehaviour
{
    public Sc_GameManager_808 GM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoundFX(int x)
    {
        GM.PlaySoundFunction(x);
    }
}
