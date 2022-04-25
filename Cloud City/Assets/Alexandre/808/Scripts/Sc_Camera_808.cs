using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Camera_808 : MonoBehaviour
{
    
    public Camera cam;
    Vector3 point;

    RaycastHit hit;
    public GameObject cible;
    public Sc_GameManager_808 GM;

    bool play;

    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        point = cam.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, cam.nearClipPlane));
        if (!GM.lost)
        {
            if (GM.play) 
            {
                Raycast(true);
            }
            else
            {
                Raycast(false);
            }
        }
    }

    public void Raycast(bool play)
    {               
        if (Physics.Raycast(transform.position, point - transform.position, out hit) & play )
        {
            cible = hit.collider.gameObject;

            if (hit.collider.gameObject.CompareTag ("Case") &&
            hit.collider.gameObject.GetComponent<Sc_Case_808>().Dead == false && //verifie que la case est vivante
            hit.collider.gameObject.GetComponent<Sc_Case_808>().IsOverlap == false &&//vérifie que la case n'est pas déjà sous la souris
            hit.collider.gameObject.GetComponent<Sc_Case_808>().OQP == false) //vérifie que la case n'est pas déjà Occupé) //on active la nouvelle) //le raycast touche quelque chose        
            {
                GM.Selection(hit.collider.gameObject); //rajoute l'objet comme étant selectionné.
            }            
        }

        else
        {
            GM.Selection(null);//rajoute l'objet comme étant selectionné.
        }
    }

}
