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
    [Header("Bool")]

    public bool b_DoOnce = true;

    [Space]
    [Header("Rotation")]

    public bool b_ApplyRota = false;

    [Space]
    [Header("Tableau Hit")]
    
    public List<GameObject> hit_voisins = new List<GameObject>();

    [Space,Space]

    public GameObject go_start;
    public GameObject go_RotX;
    public GameObject go_RotZ;

    void Start()
    {
        Starter = GameObject.Find(name);
        go_RotX = GameObject.Find("RotX");
        go_RotZ = GameObject.Find("RotZ");
    }

    void Update()
    {
        if(b_DoOnce)
        {
            vd_refreshList();
        }
    }

    public void vd_MyRot(float x, float z)
    {
        //go_start.transform.eulerAngles = new Vector3(x, 0, z);
        //go_RotX.transform.eulerAngles = new Vector3(x, 0, 0);
        //go_RotZ.transform.eulerAngles = new Vector3(0, 0, z);
        //Debug.Log(x + ("     ") + z);

        go_start = go_RotX.transform.position.z;

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
