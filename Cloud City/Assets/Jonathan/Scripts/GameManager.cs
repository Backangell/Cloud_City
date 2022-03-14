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

    public int i_difficulty = 1;
    public bool b_ApplyRota = false;
    public bool b_bomber = false;

    [Space]
    [Header("Tableau Hit")]
    
    public List<GameObject> hit_voisins = new List<GameObject>();

    [Space,Space]

    public GameObject go_start;
    float f_startX;
    float f_startZ;

    [Space, Space]

    private float f_applyonX;
    private float f_applyonZ;

    [Space, Space]

    private ile_multiplicateur sc_mult;

    void Start()
    {
        Starter = GameObject.Find(name);
        sc_mult = gameObject.GetComponent<ile_multiplicateur>();

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
       // float f_smoothtime = 0.8f;

       // Vector3 v3_target = new Vector3(x, 0, z);
        //Vector3 v3_velocity = new Vector3(100, 0, 100);

        //Vector3 v3_start = new Vector3(go_start.transform.position.x, 0, go_start.transform.position.z);

        //Appel coroutine
        //StartCoroutine(nm_smoothrot(v3_start, v3_target, v3_velocity, f_smoothtime));
    }

    public void vd_rot(float x,float z)
    {
        print("vd_rot");
        Vector3 v3_start = new Vector3(transform.position.x,0,transform.position.z);
        Vector3 v3_target = new Vector3(x, 0, z);

        if (Mathf.Abs(x) <= i_difficulty)
            x = 0f;
        if (Mathf.Abs(z) <= i_difficulty)
            z = 0f;

        go_start.transform.eulerAngles = Vector3.Lerp(v3_start,v3_target,2);
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

    public void vd_retirerpoids( float x, float z)
    {
        float f_finalonZ = (f_startZ + x + 180f) % 360f - 180f;
        float f_finalonX = (f_startX - z + 180f) % 360f - 180f;

        if (Mathf.Abs(f_finalonX) <= i_difficulty)
            f_finalonX = 0f;
        if (Mathf.Abs(f_finalonZ) <= i_difficulty)
            f_finalonZ = 0f;

        go_start.transform.eulerAngles = new Vector3(f_finalonX, 0, f_finalonZ);

    }

    IEnumerator nm_smoothrot(Vector3 start ,Vector3 target , Vector3 velocity ,float time)
    {
        //Set de la rotation
        Vector3 v3_smooth = Vector3.SmoothDamp(start, target, ref velocity, time);

        //Application de la rotation
        go_start.transform.eulerAngles = v3_smooth;

        yield return new WaitForSeconds(time);

        //Debug
        print("Apply");

        while(time<0){
            yield return null;
        }
        print(time);
        print(b_ApplyRota);
        //Finition de la coroutine
        b_ApplyRota = false;

        StopAllCoroutines();
           
    }

}
