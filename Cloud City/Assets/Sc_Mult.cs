using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sc_Mult : MonoBehaviour
{
    public Sc_GameManager_808 GM;
    
    TextMeshPro Txt;

    // Start is called before the first frame update
    void Start()
    {
        Txt = GetComponent<TextMeshPro>();
        Txt.text = "x" + GM.combo_Mult.ToString();
        GM = Camera.main.GetComponent<Sc_GameManager_808>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mult_Txt(int x)
    {
        Txt.text ="x" +  x.ToString();
    }
}
