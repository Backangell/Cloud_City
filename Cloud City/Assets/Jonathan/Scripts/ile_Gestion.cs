using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ile_Gestion : MonoBehaviour
{
    public GameObject gm_manager;
    public GameManager  gestion_manager;

    public Collider[] col_MyCollider;

    // Start is called before the first frame update
    void Start()
    {
       

        //Recherche du Game Manager
        gm_manager = GameObject.FindWithTag("Gamemanager");
        gestion_manager = gm_manager.GetComponent<GameManager>();
        gestion_manager.b_setupIle = true;

        col_MyCollider = GetComponentsInChildren<Collider>();

        foreach (Collider col in col_MyCollider)
        {
          addtolist(gm_manager.GetComponent<GameManager>(), col);
        }
    }



    //Ajout de l'île qui vient de spawn => GameManager
    void addtolist(GameManager sc_gamemanger, Collider gm_this)
    {
       // Debug.Log("ADD");
        gm_this.GetComponentInChildren<Collider>();
        sc_gamemanger.Lst_Colliders.Add(gm_this);
    }

  
}
