using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Camembert : MonoBehaviour
{
    public Sc_GameManager_808 GM;
    
    Animator Anim;

    bool IsTimer;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    public void LaunchTimer()
    {
        Anim.Play("Idle");
        Anim.SetTrigger("Trigger");
        
    }

    void EndCombo()
    {
        Anim.ResetTrigger("Trigger");
        GM.ComboRest();
    }
}
