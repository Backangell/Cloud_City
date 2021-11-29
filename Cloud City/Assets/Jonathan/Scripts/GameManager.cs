using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Starter
    public GameObject gm_TileMaps;

    public Collider Col_Title;

    //Liste des iles totales
    public List<GameObject> lst_Chaine =new List<GameObject>();

    public List<Collider> Lst_Colliders = new List<Collider>();

    public int i_ListSize;

    public bool b_setupIle=true;

    // Start is called before the first frame update
    void Start()
    {
        gm_TileMaps = GameObject.Find("Centreville");

        Lst_Colliders = new List<Collider>();

        i_ListSize = lst_Chaine.Count;
    }

    void Update()
    {
        if (b_setupIle)
        {
            lst_Chaine.Clear();
            vd_actualisationIle();

        }
            

        i_ListSize = lst_Chaine.Count;
        Debug.Log(i_ListSize);
    }


    void vd_actualisationIle()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Ile"))
        {
            
            lst_Chaine.Add(go);
        }
        b_setupIle = false;
        
    }

    void AddTilmaps(int i_lsttilemaps)
    {
        //STEP1:Check la list

        i_ListSize = i_lsttilemaps;


        //STEP2:FeedBack



        //STEP3:



        //prendre tout les colliders puis leurs appliquer le Raycast de "X" forward.

    }



}

