using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Singleton
    static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<GameManager>();
            return instance;
        }
    }
    #endregion



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
    float f_startX;
    float f_startZ;


    void Start()
    {
        Starter = GameObject.Find(name);
    }

    void Update()
    {
        f_startX = go_start.transform.rotation.eulerAngles.x;
        f_startZ = go_start.transform.rotation.eulerAngles.z;

        if(b_DoOnce)
        {
            vd_refreshList();
        }
    }

    public void vd_MyRot(float x, float z)
    {
        //Remettre le bon sens de rotations des Axes.
        //Modulo est là pour délimiter que la rotation soirs compris entre 
        float f_finalonZ = (f_startZ - x + 180f) % 360f - 180f;
        float f_finalonX = (f_startX + z + 180f ) % 360f - 180f;

        if (Mathf.Abs(f_finalonX) <= 1f)
            f_finalonX = 0f;
        if (Mathf.Abs(f_finalonZ) <= 1f)
            f_finalonZ = 0f;

        go_start.transform.eulerAngles = new Vector3(f_finalonX , 0, f_finalonZ);
        //Debug.Log("f_OnX:  "+x + "     " + "f_OnZ:  " + z);
        //print("Rotate en X:   " + f_finalonX + "      " + "Rotate en Z:   " + f_finalonZ);
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




}
