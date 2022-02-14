using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ile_voisinsAdd : MonoBehaviour 
{
    public ile_multiplicateur sc_multiplicateur;
    
    // Start is called before the first frame update
    void Start()
    {

        sc_multiplicateur = GetComponentInParent<ile_multiplicateur>();
        print(this.gameObject);

        sc_multiplicateur.lst_voisins.Add(this.gameObject);
    }
}
