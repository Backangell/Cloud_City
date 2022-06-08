using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sc_Mult : MonoBehaviour
{
    public Sc_GameManager_808 GM;
    public Animation anim;
    public TextMeshProUGUI Txt;

    // Start is called before the first frame update
    void Start()
    {
        Txt = GetComponent<TextMeshProUGUI>();
        Mult_Txt(1);
        GM = Camera.main.GetComponent<Sc_GameManager_808>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mult_Txt(int x)
    {  
            Txt.text = "x" + x.ToString();
            anim.Play();
    }
}
