using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voisin : MonoBehaviour
{
    public bool disponible; //disponibe, vérifie si le voisin est une case libre ou occ

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter (Collider other) // quand le voisin touche une île la case devient indisponible
    {
        if (other != null)
        {
            //Debug.Log("OBJECT:" + gameObject.name +" Collide:" + other.name);
            disponible = false;
        }
        else
        {
            disponible = true;
        }
    }
}
