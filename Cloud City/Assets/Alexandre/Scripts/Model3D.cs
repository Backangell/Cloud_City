using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model3D : MonoBehaviour
{
    public GameObject usine, habitation, ferme;

    public Animator anim;
    // Start is called before the first frame update
    void OnEnable()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void modelselction(float X) //fais apparaitre un model 3D
    {
        
        if (X < 0.33f)
        {
            Instantiate(usine,transform);
        }
        else if (X<0.66f)
        {
            Instantiate(ferme,transform);
        }
        else
        {
            Instantiate(habitation,transform);
        }
        anim.SetBool("Bool", true);
    }
}
