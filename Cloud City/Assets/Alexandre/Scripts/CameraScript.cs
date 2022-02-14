using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Camera cam;//récupère la cméra
    public GameObject go;// sert à communiiquer avec les cases
    
    Vector3 point;

    Vector2 movement;
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;// caméra principale
    }

    // Update is called once per frame
    void Update()
    {
        point = cam.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, cam.nearClipPlane));//permet de récupéré la position de la souris dans l'espace
        
        rayCasting(); //tire un raycast qui référencie du permier objet touché

        Onclick();//quand on click

        Moving();
    }

    private void rayCasting()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, point - transform.position, out hit)) //le raycast touche quelque chose
        {
            if (hit.collider.gameObject.tag == "case" && hit.collider.GetComponent<GridScript>().BoolB == true) //ce que le raycast touche est une case
            {
                go = hit.collider.gameObject;//recupère la case touchée en référence 
                go.GetComponent<GridScript>().Overlapping(true);//indique à la case qu'elle est touché
            }
        }
        else //si la case ne touche rien
        {
            if ( go != null) // et qu'une case est déjà prise en référence
            {
                go.GetComponent<GridScript>().Overlapping(false);//indique à la case qu'elle n'est plus touché
                go = null;// retire la référence de la case            
            }
        }
    }

    void Onclick()
    {
        if (go!=null && Input.GetButtonDown("Fire1") && go.GetComponent<GridScript>().BoolB == true)//quand on survole une case et que l'on appuie sur le clickdroit
        {
            go.GetComponent<GridScript>().Exist = true;//permet de faire apparaitre les cases autours
            go.GetComponent<ile_Poids>().b_applyrot = true;
        }
    }

    void Moving()
    {
        movement.x= Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        transform.position = new Vector3(transform.position.x + (movement.x*speed), transform.position.y , transform.position.z + (movement.y * speed));
    }

    


}
