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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LaunchTimer()
    {
        GetComponent<Animation>().Play();        
    }
    public void ResetCamembert()
    {
        GM.ComboRest();
    }

}
