using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScriptAlex : MonoBehaviour
{
    public Camera cam;
    Vector3 point;
    Vector2 mousePos;

    public GameManagerAlex GM;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        point = cam.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, cam.nearClipPlane));
        
        Raycast();        
    }

    public void Raycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, point - transform.position, out hit)) //le raycast touche quelque chose
        {
            if (hit.collider.gameObject.tag == "case" &&
                hit.collider.gameObject.GetComponent<Sc_CaseAlex>().Dead == false && //verifie que la case est vivante
                hit.collider.gameObject.GetComponent<Sc_CaseAlex>().IsOverlap == false &&//vérifie que la case n'est pas déjà sous la souris
                hit.collider.gameObject.GetComponent<Sc_CaseAlex>().OQP == false //vérifie que la case n'est pas déjà Occupé
                )
            {
                GM.Selection (hit.collider.gameObject);
            }            
        }
        else
        {
            GM.Selection(null);
        }
    }


}
