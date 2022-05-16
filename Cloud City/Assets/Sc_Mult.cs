using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sc_Mult : MonoBehaviour
{
    public Sc_GameManager_808 GM;
    public Animation anim;
    TextMeshPro Txt;

    // Start is called before the first frame update
    void Start()
    {
        Txt = GetComponent<TextMeshPro>();
        Txt.text = null;
        GM = Camera.main.GetComponent<Sc_GameManager_808>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mult_Txt(int x)
    {
        if (x == 1)
        {
            Txt.text = null;
        }
        else
        {
            Txt.text = "x" + x.ToString();
            anim.Play();
        }
    }
}
