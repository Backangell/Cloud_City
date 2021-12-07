using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Starter;

    [Header("List")]

    public List<GameObject> lst_iles = new List<GameObject>();
    public GameObject gm_iles;

    [Space]

    public List<GameObject> lst_Grid = new List<GameObject>();
    public GameObject gm_grid;

    [Space]
    [Header("Pods")]
    public int i_currentIle;
    public int i_Pods = 1; //Poids
    public int i_MultyPods; //Multiplicateurs

    public RaycastHit ray;


    [Space]
    [Header("Bool")]

    public bool b_DoOnce = true;

    void Start()
    {
        Starter = GameObject.Find(name);
    }

    void Update()
    {
       i_currentIle = lst_iles.Count;
        
        if(b_DoOnce)
        {
            
            vd_refreshList();
        }

        

    }

    void vd_refreshList()
    {

        lst_Grid.Clear();
        lst_iles.Clear();


        GameObject.FindWithTag("Ile");
        foreach (GameObject iles in lst_iles)
        {

            lst_iles.Add(iles);
        }

        GameObject.FindWithTag("case");
        foreach (GameObject grid in lst_Grid)
        {
            lst_iles.Add(grid);
        }
        
        b_DoOnce = false;
    }

    void vd_ApplyPresison(List<GameObject> Grid,List<GameObject>Iles ,GameObject Start)
    {
        FindObjectsOfType<GameObject>();
    }



}
