using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_connexion : MonoBehaviour
{
    public GameObject VFX;
    public List<GameObject> lst_ComboVfx;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void function(bool x , int couleur)
    {
        if (x)
        {
            //Debug.Log(couleur);
            VFX = Instantiate(lst_ComboVfx[couleur-1], gameObject.transform);
        }
        else
        {
            Destroy(VFX);
        }

    }


}
