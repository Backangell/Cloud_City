using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float f_duration;
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
        if (Mathf.Abs(x) <= i_difficulty)
            x = 0f;

        if (Mathf.Abs(z) <= i_difficulty)
            z = 0f;

        //Remettre le bon sens de rotations des Axes.
        //Modulo est là pour délimiter que la rotation soirs compris entre 
        float f_finalonX = (f_startX + x) % 360f;
        float f_finalonZ = (f_startZ + z) % 360f;

        Vector3 v3_start = new Vector3(f_startX, 0, f_startZ);
        Vector3 v3_target = new Vector3(f_finalonX, 0, f_finalonZ);

       StartCoroutine(nm_smoothrot(Quaternion.Euler(v3_start), Quaternion.Euler(v3_target), f_duration));


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

    IEnumerator nm_smoothrot(Quaternion start, Quaternion target, float timeDuration)
    {
        float f_elapsedTime = 0f;

        while (f_elapsedTime < timeDuration)
        {

            f_elapsedTime += Time.deltaTime;

            float f_smoothTime = Mathf.SmoothStep(0, 1, f_elapsedTime / timeDuration);

            Quaternion v3_smoothRot = Quaternion.Lerp(start, target, f_smoothTime); 

            go_start.transform.rotation = v3_smoothRot;

            yield return null;

        }

        go_start.transform.rotation = target;

    }


}
