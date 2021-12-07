using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ile_Poids : MonoBehaviour
{
    public GameManager sc_manager;

    public int i_poids = 1;



    // Start is called before the first frame update
    void Start()
    {
        sc_manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
       if(sc_manager.b_DoOnce)
       {

       }
    }
}
