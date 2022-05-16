using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_End : MonoBehaviour
{
    public Sc_GameManager_808 GM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter (Collider other)
    {
        if (!GM.lost)
        {
            GM.lost = true;
            GM.EndRoutine();
        }
    }

}
