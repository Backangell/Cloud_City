using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Camembert : MonoBehaviour
{
    public Sc_GameManager_808 GM;
    Material Mat;
    bool IsTimer;

    // Start is called before the first frame update
    void Start()
    {
        Mat = GetComponent<SpriteRenderer>().material;
        Mat.SetFloat("Combo_Timer_Visu",6);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mat.GetFloat("Combo_Timer_Visu") <= 6)
        {
            Mat.SetFloat("Combo_Timer_Visu", (Mat.GetFloat("Combo_Timer_Visu") + Time.deltaTime/6));
            
        }
        else if (IsTimer)
        {
            GM.ComboRest();
        }
        
    }
    public void LaunchTimer()
    {
        Mat.SetFloat("Combo_Timer_Visu", 0);
        IsTimer = true;
    }
}
