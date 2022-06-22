using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScore : MonoBehaviour
{
    Lead_Getinfos sc_getinfo;
    
    // Start is called before the first frame update
    void Start()
    {
        sc_getinfo = GameObject.Find("NewProfile").GetComponent<Lead_Getinfos>();
        sc_getinfo.vd_Refresh();
    }

    
}
