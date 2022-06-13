using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Camembert : MonoBehaviour
{
    public Sc_GameManager_808 GM;
    
    Animation Anim;

    bool IsTimer;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    public void LaunchTimer()
    {
        Anim.Stop(); 
        Anim.Play();
        
    }

    void EndCombo()
    {
        GM.ComboRest();
    }
}
