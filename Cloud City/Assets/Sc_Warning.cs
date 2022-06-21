using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sc_Warning : MonoBehaviour
{
    public float Timer;
    bool IsActive;
    public Sc_GameManager_808 GM;
    public TextMeshPro Txt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (IsActive & !GM.lost)
        {
            Timer -= Time.deltaTime;

            int Seconds = (int)Mathf.Floor(Timer);
            int millième = (int)(Mathf.Floor(Timer * 100f)) - Seconds*100;

            string St_Seconds = Seconds.ToString();
            string St_Millieme = millième.ToString();

            Txt.text = "0"+ St_Seconds + ":" + St_Millieme;
        }
        if (Timer <= 0 & !GM.lost)
        {
            Txt.text = "00:00" ;
            GM.EndRoutine();
        }
        
    }

    private void OnEnable()
    {
        if (GM.score < 200000)
        {

            Timer = 1;
        }
        if (GM.score < 150000)
        {

            Timer = 1.5f;
        }
        if (GM.score < 100000)
        {

            Timer = 2;
        }
        if (GM.score < 50000)
        {

            Timer = 2.5f;
        }
        else if (GM.score<0)
        {

            Timer = 3;
        }
        IsActive = true;
    }

    private void OnDisable()
    {
        Timer = 3;
        IsActive = false;
    }

}
