using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_End : MonoBehaviour
{
    public Sc_GameManager_808 GM;
    public GameObject Warning;
    public bool Bool;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter (Collision other)
    {
        if (Bool)
        {
            ContactPoint impact = other.contacts[0];
            Warning.transform.position = (new Vector3(impact.point.x, 0, impact.point.z));

            Warning.SetActive(true);
        }
        else
        {
            Warning.SetActive(true);
        }
    }



    private void OnCollisionExit(Collision other)
    {
            Warning.SetActive(false);
         
    }
}
