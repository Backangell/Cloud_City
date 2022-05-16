using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_GameEnd : MonoBehaviour
{

    public List<GameObject> Cases;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyPlateau()
    {
        foreach(GameObject Go in Cases)
        {
            Go.AddComponent<Rigidbody>();
        }
    }

}
